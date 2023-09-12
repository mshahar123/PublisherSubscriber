using Microsoft.AspNetCore.Mvc;
using PublisherSubscriber.Models;

namespace PublisherSubscriber.Controllers
{
    public class HomeController : Controller
    {
        private readonly SU_DBContext context;

        public HomeController(SU_DBContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginTbl user)
        {
            var myUser = context.LoginTbls.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login failed...!!";
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("SucessfullyLogout");
            }
            return View();
        }

        public IActionResult SucessfullyLogout()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginTbl user)
        {
            if (ModelState.IsValid)
            {
                await context.LoginTbls.AddAsync(user);
                await context.SaveChangesAsync();
                TempData["Sucess"] = "Registered Sucessfully";
                return RedirectToAction("Login");
            }
            return View();
        }





        public IActionResult Privacy()
        {
            return View();
        }
    }
}
