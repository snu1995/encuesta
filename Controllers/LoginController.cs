using Microsoft.AspNetCore.Mvc;

using encuesta.Models;
using encuesta.Resources;


using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using encuesta.Resources.Utilities;
using encuesta.Services.Implement;
using System.Diagnostics;

namespace encuesta.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult SingUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SingUp(Usuario modelo)
        {
            modelo.ClaveUsuario = Utilities.EncriptPassword(modelo.ClaveUsuario);

            Usuario user_created = await _userService.SaveUser(modelo);

            if (user_created.idUsuario > 0)
                return RedirectToAction("SingIn", "Login");

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        public IActionResult SingIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SingIn(string email, string passwordUser)
        {

            Usuario user_found = await _userService.GetUser(email, Utilities.EncriptPassword(passwordUser));

            if (user_found == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, user_found.NombreUsuario)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }
    }
}
