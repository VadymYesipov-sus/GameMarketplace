using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Exceptions;

namespace MVCProject.Filters
{
    public class GlobalExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is NotFoundException ex)
            {
                context.Result = new NotFoundObjectResult(new { message = ex.Message });
                context.ExceptionHandled = true;
            }
            else
            {
                context.Result = new ObjectResult(new { message = "An error occurred." })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }

            _logger.LogError(context.Exception, "An error occurred");
        }
    }
}
