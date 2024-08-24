using Microsoft.AspNetCore.Mvc;
using ProjetoDemo.Domain.Interfaces;
using ProjetoDemo.WebUI.ViewModel;
using System.Threading.Tasks;

namespace ProjetoDemo.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;

        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl) 
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) 
        {
             var result = await _authenticate.AuthenticateAsync(model.Email, model.Password);
            if (result)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
                }
                return Redirect(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Indalid login attempt.(password must be strong).");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegisterViewModel model) 
        {
            var result = await _authenticate.RegisterAsync(model.Email, model.Password);
            if (result) return Redirect("/");
            ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong).");
            return View(model);
        }

        public async Task<IActionResult> Logout() 
        {
            await _authenticate.Logout();
            return Redirect("/Account/Login");
        }
    }
}
