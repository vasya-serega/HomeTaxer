using System;
using System.Collections.Generic;
using HomeTaxer.Common.Enums;
using HomeTaxer.Common.Model;
using HomeTaxer.Common.Schemas;
using HomeTaxer.Connector.Interfaces;
using HomeTaxer.DAL.Concrete;
using HomeTaxer.DAL.Interfaces;

namespace HomeTaxer.Connector
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class HomeTaxesService : IHomeTaxesService
    {
        private IHomeTaxesDAL _dataAccess { get; }

        public HomeTaxesService()
        {
            _dataAccess = new HomeTaxesDAL();
        }

        public int GetUserId(string login, string pass)
        {
            return _dataAccess.GetUserId(login, pass);
        }

        public DictOptions GetDictOptions(int userId)
        {
            var dict = new DictOptions()
            {
                AccountNames = _dataAccess.GetAccountNames(userId),
                Categories = GetCategories(),
                Currencies = _dataAccess.GetCurrencies(),
            };

            return dict;
        }

        public IEnumerable<Oborot> GetOborots(int userId, DateTime? beginDate, DateTime? endDate, OborotDirection direction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Oborot> GetAllOborots(int accountNameId, int userId, OborotDirection direction)
        {
            var pediodDates = _dataAccess.GetBeginAndEndDate(userId, (int) direction);
            var beginDate = pediodDates[0];
            var endDate = pediodDates[1];
            if (beginDate == null && endDate == null)
            {
                return null;
            }

            return _dataAccess.GetOborots(beginDate.Value, endDate.Value, accountNameId, userId, (int)direction);
        }

        private List<Category> GetCategories()
        {
            var categories = new List<Category>();
            var data = _dataAccess.GetAllCategories();
            var alreadyCreatedCats = new HashSet<int>();
            foreach (var tuple in data)
            {
                if (!alreadyCreatedCats.Contains(tuple.Item3))
                {
                    categories.Add(new Category(tuple.Item3, tuple.Item4));
                    alreadyCreatedCats.Add(tuple.Item3);
                }
                categories[categories.Count - 1].AddSubCatLocally(tuple.Item1, tuple.Item2);
            }

            return categories;
        }

        public int InsertOborot(int userId, OborotDirection direction, Oborot newOborot)
        {
            return _dataAccess.InsertOborot(userId, direction, newOborot);
        }

        public void UpdateOborot(Oborot updOborot)
        {
            _dataAccess.UpdateOborot(updOborot);
        }

        public void DeleteOborot(int oborotId)
        {
            _dataAccess.DeleteOborot(oborotId);
        }

        public int InsertAccount(int userId, string accountName)
        {
            return _dataAccess.InsertAccount(userId, accountName);
        }

        public void UpdateAccount(int accountId, string accountName)
        {
            _dataAccess.UpdateAccount(accountId, accountName);
        }

        public void DeleteAccount(int accountId)
        {
            _dataAccess.DeleteAccount(accountId);
        }
    }
}
