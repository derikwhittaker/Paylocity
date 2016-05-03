namespace Paylocity.Core
{
    public class ResultStatus
    {
        public ResultStatus()
        {

        }

        public ResultStatus(string errorMessage)
        {
            Message = errorMessage;
        }

        public string Message { get; set; }
        public bool HasError => !string.IsNullOrEmpty(Message);
    }
}