namespace Gp1.model
{
    public class APIResponseModel
    {
        public string Status { get; set; }
        public object? Data { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
    public enum APIStatus
    {
        Failed,
        Succeeded
    }
}
