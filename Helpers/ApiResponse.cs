using Microsoft.AspNetCore.Mvc;

namespace APARTMENT_API.Helpers
{
    public static class ApiResponse
    {
        public static IActionResult Success(object data, string message = "Success")
        {
           return new OkObjectResult(new
           {
                Success = true,
                StatusCode = 200,
                Message = message,
                Data = data
           });
        }
    }
}