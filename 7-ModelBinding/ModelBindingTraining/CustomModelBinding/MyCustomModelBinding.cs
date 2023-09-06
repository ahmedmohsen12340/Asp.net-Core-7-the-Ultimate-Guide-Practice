using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBindingTraining.Models;

namespace ModelBindingTraining.Custom_model_Binding
{
    public class MyCustomModelBinding : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();
            if (bindingContext.ValueProvider.GetValue("FirstName").FirstValue.Length>0)
            {
                person.Name = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
            }
            if (bindingContext.ValueProvider.GetValue("LastName").FirstValue.Length>0)
            {
                person.Name += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
            }
            person.Id = Convert.ToInt32(bindingContext.ValueProvider.GetValue("Id").FirstValue);
            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}
