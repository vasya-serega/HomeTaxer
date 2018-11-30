using System;

namespace HomeTaxer.Client.Model
{
    public class OperationResult
    {
        public OperationResult(bool isSuccess, string message = null, Exception ex = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Exception = ex;
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }
    }
}
