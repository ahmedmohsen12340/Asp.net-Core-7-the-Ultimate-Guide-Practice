using Microsoft.AspNetCore.Mvc;
using ModelBindingTraining.Custom_model_Binding;
using ModelBindingTraining.Models;

namespace ModelBindingTraining.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/home")]
        public IActionResult HOME()
        {
            return Content("<h1>Welcome To Our Firm</h1>", "text/html");
        }
        [Route("/Employees")]
        public IActionResult
            Index(/*[FromBody][Bind(nameof(Person.Id),nameof(Person.Name))]*/
            /*[ModelBinder(BinderType = typeof(MyCustomModelBinding))]*/ Person person)
        {
            if (!ModelState.IsValid)
            {

                #region foreach
                //List<string> errorsList = new List<string>();
                //foreach(var value in ModelState.Values)
                //{
                //    foreach (var item in value.Errors)
                //    {
                //        errorsList.Add(item.ErrorMessage);
                //    }
                //}
                #endregion

                List<string> errorsList = ModelState.Values
                    .SelectMany(value=> value.Errors)
                    .Select(error=>error.ErrorMessage).ToList();


                string? errors = string.Join("\n", errorsList);
                return BadRequest(errors);
            }
            return Content($"{person}","plain/text");
        }
    }
}
