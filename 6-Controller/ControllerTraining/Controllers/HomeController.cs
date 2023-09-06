using ControllerTraining.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.IO;

namespace ControllerTraining.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/Home")]
        public IActionResult Home()
        {
            return Content("<h1>HEllo Welcome To Our Store</h1>","text/html");
        }
        [Route("outside")]
        public IActionResult outside()
        {
            return Content("\"id\":5,\"Name\":\"Mohsen\"", "application/json");
        }
        [Route("json")]
        public IActionResult Json()
        {
            Book book = new Book() { Id=Guid.NewGuid(),Name="harry potter",Desc="--"};
            return new JsonResult(book);
        }
        [Route("/books/{Name}")]
        public IActionResult Books()
        {
            var Name = Request.RouteValues["name"];
            return new ContentResult()
            {Content= $"The book name is: {Name}\n ",ContentType="Text/plain" };
        }
        [Route("file")]
        public IActionResult File()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"E:\MBA-Brochure.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
            //return new VirtualFileResult("/MBA-Brochure.pdf", "application/pdf");
        }
        [Route("result")]
        public IActionResult Result()
        {
            //return new UnauthorizedObjectResult("bad!!!!!!!");  
            //return Unauthorized();
            //return StatusCode(400);
            //return BadRequest();
            //return NotFound();
            return Redirect("google.com");
        }
    }
}
