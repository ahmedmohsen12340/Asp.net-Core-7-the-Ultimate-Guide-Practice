using ModelBindingTraining.Custom_model_Binding;
using ModelBindingTraining.CustomModelBinding;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(op =>
{
    op.ModelBinderProviders.Insert(0, new ModelBinderProvider());
});
//builder.Services.AddControllers().AddXmlSerializerFormatters();
var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.Run();
