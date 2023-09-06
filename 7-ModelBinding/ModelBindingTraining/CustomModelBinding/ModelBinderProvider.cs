using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ModelBindingTraining.Custom_model_Binding;
using ModelBindingTraining.Models;
using System.Reflection.Metadata.Ecma335;

namespace ModelBindingTraining.CustomModelBinding
{
    public class ModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Person))
                return new BinderTypeModelBinder(typeof(MyCustomModelBinding)); 
            return null;
        }
        
    }
}
