using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnviroment, HttpContext httpContext)
        {
            if(!hostEnviroment.IsDevelopment())
            {
                return NotFound();
            }
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return Problem(detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);

        }
        [Route("Error")]
        public IActionResult HandleError()
        {
            return Problem();
        }

        [HttpGet("Throw")]
        public IActionResult Throw() 
        {
            throw new Exception("Sample Exception");
        }
    }

}
