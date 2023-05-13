using Microsoft.AspNetCore.Mvc;

namespace PruebaDiego.Utils
{
    public static class HttpResponseHelper
    {
        public static IActionResult SuccessfulObjectResult(object response)
        {
            return new OkObjectResult(response);
        }

        public static IActionResult BadRequestObjectResult(object response)
        {
            return new BadRequestObjectResult(response);
        }

        public static IActionResult HttpExplicitNoContent()
        {
            return new NoContentResult();
        }

        public static ObjectResult Response(int code, object value)
        {
            var result = new ObjectResult(value);
            result.StatusCode = code;
            return result;
        }
    }
}