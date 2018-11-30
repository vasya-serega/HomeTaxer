using System;
using System.Collections.Generic;
using HomeTaxer.Common.Enums;
using HomeTaxer.Common.Schemas;

namespace HomeTaxer.DAL.Interfaces
{
    public interface IHomeTaxesDAL
    {
        Dictionary<int, string> GetAccountNames(int userid);

        Dictionary<int, string> GetCurrencies();

        int GetUserId(string login, string pass);

        DateTime?[] GetBeginAndEndDate(int userId, int direction);

        IEnumerable<Oborot> GetOborots(DateTime beginDate, DateTime endDate, int accountNameId, int userId, int direction);

        IEnumerable<Tuple<int, string, int, string>> GetAllCategories();

        int InsertOborot(int userId, OborotDirection direction, Oborot newOborot);

        void UpdateOborot(Oborot updOborot);

        void DeleteOborot(int oborotId);

        int InsertAccount(int userId, string accountName);

        void UpdateAccount(int accountId, string accountName);

        void DeleteAccount(int accountId);
    }
}
