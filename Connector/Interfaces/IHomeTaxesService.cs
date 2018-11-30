using System;
using System.Collections.Generic;
using System.ServiceModel;
using HomeTaxer.Common.Enums;
using HomeTaxer.Common.Schemas;

namespace HomeTaxer.Connector.Interfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IHomeTaxesService
    {
        [OperationContract]
        int GetUserId(string login, string pass);

        [OperationContract]
        DictOptions GetDictOptions(int userId);

        [OperationContract]
        IEnumerable<Oborot> GetOborots(int userId, DateTime? beginDate, DateTime? endDate, OborotDirection direction);

        [OperationContract]
        IEnumerable<Oborot> GetAllOborots(int accountNameId, int userId, OborotDirection direction);

        [OperationContract]
        int InsertOborot(int userId, OborotDirection direction, Oborot newOborot);

        [OperationContract]
        void UpdateOborot(Oborot updOborot);

        [OperationContract]
        void DeleteOborot(int oborotId);

        [OperationContract]
        int InsertAccount(int userId, string accountName);

        [OperationContract]
        void UpdateAccount(int accountId, string accountName);

        [OperationContract]
        void DeleteAccount(int accountId);
    }
}
