using APARTMENT_API.Exceptions;
using System.Net;
using System.Text.Json;

namespace APARTMENT_API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _request;
        public ExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }
        private static async Task HandleExeption(HttpContext context,HttpStatusCode statusCode,string message)
        {
            //context.Response.ContentType = "";​​
            context.Response.ContentType = "application/json";  //បញ្ជាក់ថា response នេះមានទ្រង់ទ្រាយជា JSON
            context.Response.StatusCode = (int)statusCode;  //Convert enum → integer
            var response = new
            {
                Status = false,
                StatusCode = statusCode,
                Message = message,
                Data = new { }
            };
            var json = JsonSerializer.Serialize(response);  //បម្លែង object → JSON string
            await context.Response.WriteAsync(json); //ផ្ញើ JSON ទៅ frontend / Postman / mobile app

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (BadRequestException ex)
            {
                await HandleExeption(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (UnauthorizeException ex)
            {
                await HandleExeption(context, HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (NotFoundException ex)
            {
                await HandleExeption(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (ValidationException ex)
            {
                //await HandleExeption(context, HttpStatusCode.BadRequest, string.Join(", ", ex.Errors));

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 400;
                var response = new
                {
                    Success = false,
                    StatusCodes = 400,
                    Message = ex.Message,
                    Errors = ex.Errors
                };
            }
            catch (Exception ex)
            {
                await HandleExeption(context, HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

