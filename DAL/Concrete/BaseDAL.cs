using Microsoft.Practices.EnterpriseLibrary.Data;

namespace HomeTaxer.DAL.Concrete
{
    public class BaseDAL
    {
        private Database _db;

        public BaseDAL()
        {
        }

        public Database Db
        {
            get
            {
                if (null == _db)
                {
                    _db = DatabaseFactory.CreateDatabase("HomeTaxesConnection");
                }
                return _db;
            }
        }
    }
}
