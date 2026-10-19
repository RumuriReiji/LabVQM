using Lab4_TuLam.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_TuLam.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            var hotProducts = new List<Product>
            {
                new Product { Id = 4, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", ImageUrl = "/images/NoiCom.jpg", Price = 1500000 },
                new Product { Id = 5, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", ImageUrl = "/images/NoiCom.jpg", Price = 1600000 },
                new Product { Id = 6, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", ImageUrl = "/images/NoiCom.jpg", Price = 1700000 }
            };

            return View(hotProducts);
        }
    }
}
