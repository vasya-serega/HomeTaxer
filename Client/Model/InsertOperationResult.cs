using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTaxer.Client.Model
{
    public class InsertOperationResult : OperationResult
    {
        public InsertOperationResult(int insertedId, bool isSuccess, string message = null, Exception ex = null) : 
            base(isSuccess, message, ex)
        {
            InsertedId = insertedId;
        }

        public InsertOperationResult(bool isSuccess, string message = null, Exception ex = null) :
            base(isSuccess, message, ex)
        {
        }

        public int InsertedId { get; set; }
    }
}
