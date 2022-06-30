using Microsoft.AspNetCore.Identity;
using ListBuilderMovies.Models;
using ListBuilderMovies.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ListBuilderMovies.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        //private RoleManager<User> _roleManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager /*, RoleManager<User> roleManager*/)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            //_roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "List");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel _loginview)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(_loginview.UserName, _loginview.Password, _loginview.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "List");
                }
            }
            ModelState.AddModelError("", "Failed to login");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel _registerview)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    FirstName = _registerview.FirstName,
                    LastName = _registerview.LastName,
                    Email = _registerview.Email,
                    UserName = _registerview.UserName,
                    PhoneNumber = _registerview.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, _registerview.Password);
                if (result.Succeeded)
                {
                    var addedUser = await _userManager.FindByNameAsync(user.UserName);
                    if (addedUser.UserName == "Admin")
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    return RedirectToAction("Login", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
