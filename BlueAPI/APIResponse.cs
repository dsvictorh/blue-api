using System.Net;

namespace BlueAPI
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public List<string> Messages { get; set; }
        public object? Data { get; set; }

        public APIResponse() 
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Success = true;
            this.Messages = new List<string>();
        }
    }
}
