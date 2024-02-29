using BooksStore.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.ActionResult
{
    public class CustomPublisherActionResult : IActionResult

    {

        //creating the prop for viewmodel

        private readonly CustomActionResult _customresult;
        public CustomPublisherActionResult(CustomActionResult customresult)
        {
            _customresult = customresult;   
        }

       public  async Task ExecuteResultAsync(ActionContext context)
        {
            var objectresult = new ObjectResult(_customresult.Exception ?? _customresult.publisher as object)
            {
                StatusCode = _customresult.Exception != null ? StatusCodes.Status500InternalServerError : StatusCodes.Status200OK
            };


            await objectresult.ExecuteResultAsync(context);
        }
    }
}
