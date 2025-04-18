using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class ProductstoreController : Controller
    {
        private readonly ApplicationDbContext _contect;

        public ProductstoreController(ApplicationDbContext context)
        {
            _contect = context;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _contect.products.Add(product);
            _contect.SaveChanges();
            return View(); 
        }

        [HttpGet]
        public IActionResult Get()
        {
            var prodlist=_contect.products.ToList();
            return View(prodlist);
        }
       


    }
}
