using Microsoft.AspNetCore.Mvc;
using Models;

namespace StockApp.ViewComponents
{
    public class SelectedStockViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CompanyDetails companyDetails)
        {

            return View("StockDetails",companyDetails);
        }
    }
}
