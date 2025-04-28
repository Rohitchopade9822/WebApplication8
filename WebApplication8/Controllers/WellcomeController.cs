using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class WellcomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WellcomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {

            _context.users.Add(user);
            _context.SaveChanges();
            return View();

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var result = _context.users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if(result!=null)
            {
                return RedirectToAction("Get", "Productstore");
            }
            else
            {
                return RedirectToAction("Login");
            }

            return View();
        }

    }
}
