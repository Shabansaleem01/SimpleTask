using Microsoft.AspNetCore.Mvc;
using SimpleProject.Models;

namespace SimpleProject.Controllers
{
    public class UserController : Controller
    {
        // Hardcoded user credentials
        private static readonly User HardcodedUser = new User
        {
            Username = "admin",
            Password = "password123"
        };

        // GET: /User/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == HardcodedUser.Username && password == HardcodedUser.Password)
            {
                // Redirect to Dashboard after successful login without using session
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.Message = "Invalid username or password.";
            return View();
        }

        // GET: /User/Signup
        public IActionResult Signup()
        {
            return View();
        }

        // POST: /User/Signup
        [HttpPost]
        public IActionResult Signup(string username, string password)
        {
            if (username == HardcodedUser.Username)
            {
                ViewBag.Message = "Username already taken.";
                return View();
            }

            ViewBag.Message = "Signup successful!";
            return RedirectToAction("Login");
        }
    }
}