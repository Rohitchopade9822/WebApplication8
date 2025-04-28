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
        public IActionResult Create()   //action 
        {
            return View();
        } 
        [HttpPost] 
        public IActionResult Create(Product product)
        {
            _contect.products.Add(product);
            _contect.SaveChanges();
            return RedirectToAction("Get");

        }

        [HttpGet]
        public IActionResult Get()
        {
            var prodlist=_contect.products.ToList();
            return View(prodlist);
        }

        [HttpGet]
        public IActionResult GetbyId(int id)
        {
            var Products = _contect.products.FirstOrDefault(p => p.Id == id);
                
            return View(Products);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Products = _contect.products.FirstOrDefault(p => p.Id==id);

            _contect.products.Remove(Products);
            _contect.SaveChanges();

            return RedirectToAction("Get");
           
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var Products = _contect.products.FirstOrDefault(p => p.Id == id);

            return View(Products);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            var producUpdate=_contect.products.FirstOrDefault(p=>p.Id==product.Id);

            producUpdate.Name= product.Name;
            producUpdate.Description = product.Description;
            product.Category= product.Category;

            _contect.SaveChanges();

            return RedirectToAction("Get");

            
        }

    }

}
