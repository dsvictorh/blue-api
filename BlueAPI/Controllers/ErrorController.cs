using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlueAPI.Controllers
{
    [Route("errors")]
    [ApiController]
    public class ErrorController : ControllerBase
    {

        [Route("{statusCode}")]
        public ObjectResult HandleStatus(HttpStatusCode statusCode)
        {
            APIResponse response = new()
            {
                StatusCode = statusCode,
                Success = false
            };

            //SWITCH DE STATUS CODE

            ObjectResult result = new(response)
            {
                StatusCode = (int)statusCode
            };

            return result;
        }
    }
}
