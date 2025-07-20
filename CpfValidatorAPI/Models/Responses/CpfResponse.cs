namespace CpfValidatorAPI.Models.Responses
{
    public class CpfResponse
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public CpfResponse(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }
}
