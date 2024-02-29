using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.2")]
    [ApiVersion("1.9")]

    [Route("api/[controller]")]
  //  [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-test-data"),MapToApiVersion("1.0")]
        public IActionResult Getv1()
        {
            return Ok("This is test controller V1");
        }
        [HttpGet("get-test-data"), MapToApiVersion("1.2")]
        public IActionResult Getv12()
        {
            return Ok("This is test controller V1.2");
        }
        [HttpGet("get-test-data"), MapToApiVersion("1.9")]
        public IActionResult Getv19()
        {
            return Ok("This is test controller V1.9");
        }
    }
}
