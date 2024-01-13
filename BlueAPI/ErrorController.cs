using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlueAPI
{
    [Route("errors")]
    [ApiController]
    public class ErrorController : ControllerBase
    {

        [Route("{statusCode}")]
        public ObjectResult HnadleStatus(HttpStatusCode statusCode)
        { 
            APIResponse response = new()
            { 
                StatusCode = statusCode,
                Success = false
            };
        
            ObjectResult result = new(response)
            { 
                StatusCode = (int)statusCode
            };

            return result;
        }
    }
}
