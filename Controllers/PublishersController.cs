using BooksStore.ActionResult;
using BooksStore.Data.Service;
using BooksStore.Data.ViewModels;
using BooksStore.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using Serilog;
using Microsoft.Extensions.Logging;

namespace BooksStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {

        private Data.Service.PublishersController _publishersService;

        private readonly ILogger<PublishersController> _logger;

        public PublishersController(Data.Service.PublishersController publishersService, ILogger<PublishersController> logger)
        {
            _publishersService = publishersService;
            _logger = logger;
        }



        //[HttpPost("add-publisher")]
        //public IActionResult AddPublisher([FromBody]PublishersVM publisher)
        //{
        //        _publishersService.AddPublisher(publisher);
        //        return Ok();
        //}


        //To Check Status Code

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublishersVM publisher)
        {
            try
            {
                var result = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), result);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, PublisherName:{ex.PublisherName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }







        //to get publisherById

        //[HttpGet("get-publisher-by-id/{PublisherId}")]
        //public IActionResult GetPublisherById(int PublisherId)
        //{

        //     //throw new Exception("handled by gloabl exception");  --hides the code,not to go for flow for the next statement.
        //    // ---comment for checking ---global handle----var result = _publishersService.GetPublisherId(PublisherId);



        //    var result = _publishersService.GetPublisherId(PublisherId);

        //    if (result != null) 
        //    { 
        //        return Ok(result);
        //    }
        //    return NotFound();
        //}



        [HttpGet("get-publisher-by-id/{PublisherId}")]
        public IActionResult GetPublisherById(int PublisherId)
        {

            //throw new Exception("handled by gloabl exception");  --hides the code,not to go for flow for the next statement.
            // ---comment for checking ---global handle----var result = _publishersService.GetPublisherId(PublisherId);



            var result = _publishersService.GetPublisherId(PublisherId);

            if (result != null)
            {
                //return Ok(result);


                //viewmodel of actionresult
                var _responseobj = new CustomActionResult()
                {
                    publisher = result
                };
                return new CustomPublisherActionResult(_responseobj);

             }
            else {
                //viewmodel of actionresult
                var _responseobj = new CustomActionResult()
                {
                    Exception = new Exception("This is the Custom Action Result")
                };
                return new CustomPublisherActionResult(_responseobj);
             }
        }






        [HttpGet("GetPublishBookAuthorsData/{PublisherId}")]
        public IActionResult GetPublishBookAuthorsData(int PublisherId)
        {
            var _response = _publishersService.getPublisherBookAuthorsData(PublisherId);
            return Ok(_response);
        }

        [HttpDelete("DeletePublisherjoinbyId/{PublisherId}")]
        public IActionResult DeletePublisherjoinbyId(int PublisherId)
        {

            try {
                _publishersService.deletePublisherjoinbyId(PublisherId);
                return Ok();
            } 
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
             }
            
            
        }



        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortby,string searchField,int pageNumber)
        {
            try
            {
                _logger.LogInformation("this logs get all publishers");   
               var response= _publishersService.GetAllPublishers(sortby,searchField,pageNumber);
                return Ok(response);
            }
            catch(Exception)
            {
                return BadRequest("this is not availble");
            }
        }


    }
}
