using BooksStore.Data.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private LogsService _logsService;

        public LogsController(LogsService logsService)
        {
            _logsService = logsService;   
        }
        [HttpGet("get-all-logs-from-db")]
        public IActionResult GetAllLogsFromDb()
        {
            try
            {
                var alllogs = _logsService.GetAllLogsFromDb();
                return Ok(alllogs);
            }
            catch (Exception) {
                return BadRequest("Could Not Load Logs From DB");

            }
        }
    }
}
