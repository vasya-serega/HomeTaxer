using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using HomeTaxer.Client.HomeTaxesReference;
using HomeTaxer.Client.Model;

namespace HomeTaxer.Client.Services
{
    public class HtService
    {
        private readonly int _userId;
        private readonly HomeTaxesServiceClient _client;
        private DictOptions _dictOptions = new DictOptions();

        public HtService(string userName, string password)
        {
            _client = new HomeTaxesServiceClient();
            _userId = _client.GetUserId(userName, password);
            IsDictOptionsLoaded = false;
            AccountNameId = -1; // default unassigned value to indicate loading data is needed
        }

        public int AccountNameId { get; set; }

        public List<Category> Сategories => _dictOptions.Categories;

        public Dictionary<int, string> Currencies => _dictOptions.Currencies;

        public Dictionary<int, string> Accounts => _dictOptions.AccountNames;

        public bool EnableToConnect => _userId != -1;

        public bool IsDictOptionsLoaded { get; private set; }

        public string GetCategoryNameById(int id)
        {
            var cat = _dictOptions.Categories.Find(c => c.Id == id);
            if (cat == null)
            {
                throw  new KeyNotFoundException($"Category with Id='{id}' is not found");
            }

            return cat.Name;
        }

        public string GetSubcategoryNameById(int categoryId, int? subcategoryId)
        {
            if (subcategoryId == null)
            {
                return null;
            }

            var cat = _dictOptions.Categories.Find(c => c.Id == categoryId);
            if (cat == null)
            {
                throw new KeyNotFoundException($"Category with Id='{categoryId}' is not found");
            }

            if (!cat.SubCategories.ContainsKey(subcategoryId.Value))
            {
                throw new KeyNotFoundException($"SubCategory with Id='{subcategoryId}' is not found");
            }

            return cat.SubCategories[subcategoryId.Value];
        }

        public Task LoadOptions()
        {
            return Task.Run(() =>
            {
                _dictOptions = _client.GetDictOptions(_userId);
                IsDictOptionsLoaded = true;
            });
        }

        public Task<List<Oborot>> GetAllOborots(OborotDirection direction)
        {
            if (AccountNameId == -1)
            {
                throw new ApplicationException("AccountNameId is not set");
            }

            return Task.Run(() =>
            {
                //Thread.Sleep(3000);
                return _client.GetAllOborots(AccountNameId,_userId, direction);
            });
        }

        public Task<InsertOperationResult> InsertOborot(Oborot newOborot)
        {
            return Task.Run(() =>
            {
                try
                {
                    var insertedId = _client.InsertOborot(_userId, OborotDirection.Costs, newOborot);
                    return new InsertOperationResult(insertedId, true);
                }
                catch (Exception ex)
                {
                    return new InsertOperationResult(false, "Неможливо зберегти дані. ", ex);   
                }
            });
        }

        public Task<OperationResult> UpdateOborot(Oborot updOborot)
        {
            return Task.Run(() =>
            {
                try
                {
                    _client.UpdateOborot(updOborot);
                    return new OperationResult(true);
                }
                catch (Exception ex)
                {
                    return new OperationResult(false, "Неможливо зберегти дані. ", ex);
                }
            });
        }

        public Task<OperationResult> DeleteOborot(int oborotId)
        {
            return RunDelete(_client.DeleteOborot, oborotId);
        }

        public Task<InsertOperationResult> InsertAccount(string accountName)
        {
            return RunInsert(_client.InsertAccount, accountName);
        }

        public Task<OperationResult> UpdateAccount(int accountId, string accountName)
        {
            return RunUpdate(_client.UpdateAccount, accountId, accountName);
        }

        public Task<OperationResult> DeleteAccount(int accountId)
        {
            return RunDelete(_client.DeleteAccount, accountId);
        }

        private Task<OperationResult> RunUpdate(Action<int, string> action, int id, string name)
        {
            return Task.Run(() =>
            {
                try
                {
                    action(id, name);
                    return new OperationResult(true); 
                }
                catch (Exception ex)
                {
                    return new OperationResult(false, "Неможливо зберегти дані. ", ex);
                }
            });
        }

        private Task<OperationResult> RunDelete(Action<int> action, int id)
        {
            return Task.Run(() =>
            {
                try
                {
                    action(id);
                    return new OperationResult(true);
                }
                catch (Exception ex)
                {
                    return new OperationResult(false, "Неможливо зберегти дані. ", ex);
                }
            });
        }

        private Task<InsertOperationResult> RunInsert(Func<int, string, int> action, string name)
        {
            return Task.Run(() =>
            {
                try
                {
                    var insertedId = action(_userId, name);
                    return new InsertOperationResult(insertedId, true);

                }
                catch (Exception ex)
                {
                    return new InsertOperationResult(false, "Неможливо зберегти дані. ", ex);
                }
            });
        }

    }
}