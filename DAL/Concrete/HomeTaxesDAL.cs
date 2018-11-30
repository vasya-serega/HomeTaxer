using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HomeTaxer.Common.Enums;
using HomeTaxer.Common.Schemas;
using HomeTaxer.DAL.Interfaces;

namespace HomeTaxer.DAL.Concrete
{
    public class HomeTaxesDAL: BaseDAL, IHomeTaxesDAL
    {
        public Dictionary<int, string> GetAccountNames(int userId)
        {
            var select = "select id, [name] " +
                         "from Account " +
                         $"where UserId = {userId}";
            var reader = Db.ExecuteReader(CommandType.Text, select);

            var accountNames = new Dictionary<int, string>();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                accountNames.Add(id, name);
            }

            return accountNames;
        }

        public Dictionary<int, string> GetCurrencies()
        {
            var select = "SELECT [CurrencyId],[Name],[Code] " +
                         "FROM Currency";
            var command = new SqlCommand();
            //command.CommandTimeout = 90;
            command.CommandText = select;
            command.CommandType = CommandType.Text;
            var reader = Db.ExecuteReader(command);
            
            var dict = new Dictionary<int, string>();
            while(reader.Read())
            { 
                var id = reader.GetInt32(0);
                var name = reader.GetString(1);
                dict.Add(id, name);
            }

            return dict;
        }

        public int GetUserId(string login, string password)
        {
            var select = "SELECT [UserId],[Name],[Password] " +
                         "FROM Users";
            var reader = Db.ExecuteReader(CommandType.Text, select);

            while (reader.Read())
            {
                var id = (int)reader.GetByte(0);
                var name = reader.GetString(1);
                var pass = reader.GetValue(2).GetType() != typeof(DBNull) ? reader.GetString(2) : null;

                if (name.Equals(login, StringComparison.Ordinal))
                {
                    if (pass == null && string.IsNullOrEmpty(password))
                    {
                        return id;
                    }

                    if (pass != null && pass.Equals(password, StringComparison.OrdinalIgnoreCase))
                    {
                        return id;
                    }
                }
            }

            return -1;
        }

        public DateTime?[] GetBeginAndEndDate(int userId, int direction)
        {
            var select = "select min(OborotDate), max(OborotDate) from Oborot " + 
                        $"where Direction = {direction}  and UserId = {userId}";

            var reader = Db.ExecuteReader(CommandType.Text, select);

            var period = new DateTime?[2];
            if (reader.Read())
            {
                if (reader.GetValue(0).GetType() != typeof (DBNull))
                {
                    period[0] = reader.GetDateTime(0);
                }
                if (reader.GetValue(1).GetType() != typeof(DBNull))
                {
                    period[1] = reader.GetDateTime(1);
                }
            }

            return period;
        }

        public IEnumerable<Oborot> GetOborots(
            DateTime beginDate, DateTime endDate, int accountNameId, int userId, int direction)
        {
            var command = Db.GetStoredProcCommand("dbo.GetOborots");
            command.CommandType = CommandType.StoredProcedure;
            var beginDateParam = new SqlParameter("beginDate", SqlDbType.DateTime);
            beginDateParam.Value = beginDate;
            var endDateParam = new SqlParameter("endDate", SqlDbType.DateTime);
            endDateParam.Value = endDate;
            var accountNameIdParam = new SqlParameter("accountNameId", SqlDbType.Int);
            accountNameIdParam.Value = accountNameId;
            var userIdParam = new SqlParameter("userId", SqlDbType.Int);
            userIdParam.Value = userId;
            var directionParam = new SqlParameter("direction", SqlDbType.Int);
            directionParam.Value = direction;
            command.Parameters.AddRange(new[]
            {
                beginDateParam, endDateParam, accountNameIdParam, userIdParam, directionParam
            });

            var reader = Db.ExecuteReader(command);
            var oborots = new List<Oborot>();
            while (reader.Read())
            {
                var oborot = new Oborot()
                {
                    OborotId = reader.GetInt32(0),
                    Date = reader.GetDateTime(1),
                    CategoryId = reader.GetInt32(2),
                    Category = reader.GetString(3),
                    SubCategoryId = reader.GetValue(4).GetType() != typeof(DBNull) ? reader.GetInt32(4) : (int?) null,
                    SubCategory = reader.GetValue(5).GetType() != typeof (DBNull) ? reader.GetString(5) : null,
                    Count = reader.GetDouble(6),
                    Summa = reader.GetDecimal(7),
                    CurrencyId = reader.GetInt32(8),
                    Currency = reader.GetString(9),
                    Note = reader.GetValue(10).GetType() != typeof(DBNull) ? reader.GetString(10) : null
                };
                oborots.Add(oborot);
            }

            return oborots;
        }

        public IEnumerable<Tuple<int, string, int, string>> GetAllCategories()
        {
            var select = "select " +
                         "SubCategoryId, SubCategory.Name as SubCategoryName, Category.Id, Category.Name as CategoryName " +
                         "from SubCategory " +
                         "inner join Category on SubCategory.CategoryId = Category.Id " +
                         "order by CategoryId";
            var reader = Db.ExecuteReader(CommandType.Text, select);

            var data = new List<Tuple<int, string, int, string>>();
            while (reader.Read())
            {
                if (reader.GetValue(1) is DBNull ||
                    reader.GetValue(3) is DBNull)
                {
                    continue;
                }

                var subCatId = reader.GetInt32(0);
                var subCatName = reader.GetString(1);
                var catId = reader.GetInt32(2);
                var catName = reader.GetString(3);
                data.Add(new Tuple<int, string, int, string>(subCatId, subCatName, catId, catName));
            }

            return data;
        }

        public int InsertOborot(int userId, OborotDirection direction, Oborot newOborot)
        {
            var command = Db.GetStoredProcCommand("dbo.InsertOborot");
            command.CommandType = CommandType.StoredProcedure;

            var dateParam = new SqlParameter("oborotDate", SqlDbType.DateTime);
            dateParam.Value = newOborot.Date;
            var accountNameIdParam = new SqlParameter("accountNameId", SqlDbType.Int);
            accountNameIdParam.Value = newOborot.AccountNameId;
            var categoryIdParam = new SqlParameter("categoryId", SqlDbType.Int);
            categoryIdParam.Value = newOborot.CategoryId;
            var subCategoryIdParam = new SqlParameter("subCategoryId", SqlDbType.Int);
            subCategoryIdParam.Value = newOborot.SubCategoryId;
            var countParam = new SqlParameter("count", SqlDbType.Float);
            countParam.Value = newOborot.Count;
            var amountParam = new SqlParameter("amount", SqlDbType.Decimal);
            amountParam.Value = newOborot.Summa;
            var currencyIdParam = new SqlParameter("currencyId", SqlDbType.Int);
            currencyIdParam.Value = newOborot.CurrencyId;
            var noteParam = new SqlParameter("note", SqlDbType.NVarChar);
            noteParam.Value = newOborot.Note;
            var userIdParam = new SqlParameter("userId", SqlDbType.Int);
            userIdParam.Value = userId;
            var directionParam = new SqlParameter("direction", SqlDbType.Int);
            directionParam.Value = direction;
            command.Parameters.AddRange(new[]
            {
                dateParam,
                accountNameIdParam,
                categoryIdParam,
                subCategoryIdParam,
                countParam, 
                amountParam,
                currencyIdParam,
                noteParam,
                directionParam,
                userIdParam
            });

            var identity = Db.ExecuteScalar(command);

            return Convert.ToInt32(identity);
        }

        public void UpdateOborot(Oborot updOborot)
        {
            var command = Db.GetStoredProcCommand("dbo.UpdateOborot");
            command.CommandType = CommandType.StoredProcedure;

            var oborotIdParam = new SqlParameter("oborotId", SqlDbType.Int);
            oborotIdParam.Value = updOborot.OborotId;
            var dateParam = new SqlParameter("oborotDate", SqlDbType.DateTime);
            dateParam.Value = updOborot.Date;
            var accountNameIdParam = new SqlParameter("accountNameId", SqlDbType.Int);
            accountNameIdParam.Value = updOborot.AccountNameId;
            var categoryIdParam = new SqlParameter("categoryId", SqlDbType.Int);
            categoryIdParam.Value = updOborot.CategoryId;
            var subCategoryIdParam = new SqlParameter("subCategoryId", SqlDbType.Int);
            subCategoryIdParam.Value = updOborot.SubCategoryId;
            var countParam = new SqlParameter("count", SqlDbType.Float);
            countParam.Value = updOborot.Count;
            var amountParam = new SqlParameter("amount", SqlDbType.Decimal);
            amountParam.Value = updOborot.Summa;
            var currencyIdParam = new SqlParameter("currencyId", SqlDbType.Int);
            currencyIdParam.Value = updOborot.CurrencyId;
            var noteParam = new SqlParameter("note", SqlDbType.NVarChar);
            noteParam.Value = updOborot.Note;
            
            command.Parameters.AddRange(new[]
            {
                oborotIdParam,
                dateParam,
                accountNameIdParam,
                categoryIdParam,
                subCategoryIdParam,
                countParam,
                amountParam,
                currencyIdParam,
                noteParam
            });

            Db.ExecuteNonQuery(command);
        }

        public void DeleteOborot(int oborotId)
        {
            var query = "delete " + 
                        "from Oborot " + 
                        $"where Oborot.OborotId = {oborotId}";
            var reader = Db.ExecuteNonQuery(CommandType.Text, query);
        }

        public int InsertAccount(int userId, string accountName)
        {
            var commandText = "insert into Account " +
                              "([Name], UserId) " +
                              "values (@accountName, @userId); " +
                              "SELECT SCOPE_IDENTITY()";
            var command = Db.GetSqlStringCommand(commandText);

            var accountNameParam = new SqlParameter("accountName", SqlDbType.NVarChar);
            accountNameParam.Value = accountName;
            var userIdParam = new SqlParameter("userId", SqlDbType.Int);
            userIdParam.Value = userId;
            command.Parameters.AddRange(new[]
            {
                accountNameParam, userIdParam
            });
            
            var identity = Db.ExecuteScalar(command);

            return Convert.ToInt32(identity);
        }

        public void UpdateAccount(int accountId, string accountName)
        {
            var commandText = "update Account " +
                              "set [Name] = @accountName " +
                              "where Id = @accountId";
            var command = Db.GetSqlStringCommand(commandText);

            var accountNameParam = new SqlParameter("accountName", SqlDbType.NVarChar);
            accountNameParam.Value = accountName;
            var accountIdParam = new SqlParameter("accountId", SqlDbType.Int);
            accountIdParam.Value = accountId;
            command.Parameters.AddRange(new[]
            {
                accountNameParam, accountIdParam
            });

            Db.ExecuteNonQuery(command);
        }

        public void DeleteAccount(int accountId)
        {
            var commandText = "delete Account " +
                              "where Id = @accountId";
            var command = Db.GetSqlStringCommand(commandText);

            var accountIdParam = new SqlParameter("accountId", SqlDbType.Int);
            accountIdParam.Value = accountId;
            command.Parameters.Add(accountIdParam);

            Db.ExecuteNonQuery(command);
        }
    }
}
