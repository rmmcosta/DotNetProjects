using System.Web.Mvc;

namespace ProductsWebApi.Areas.ProductArea
{
    public class ProductAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProductArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Product_default",
                "Product/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}