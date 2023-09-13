using Assignment16Redo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment20.ViewComponents
{
    [ViewComponent]
    public class CityViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Cityweather? x)
        {
            return View(x);
        } 
    }
}
