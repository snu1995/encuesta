using System.Security.Claims;
using encuesta.Models;
using encuesta.Services.Implement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace encuesta.Controllers
{
    [Authorize]
    public class CampoController : Controller
    {

        private readonly ICampoService _context;


        public CampoController(ICampoService context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimuser = HttpContext.User;

            if (!claimuser.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "Login");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewData["encuestaId"] = id;

            List<Campo> campos_found = await _context.GetListCampo(id);
            
            return View(campos_found);
        }



        public IActionResult Crear(int encuestaId)
        {
            ViewBag.EncuestaId = encuestaId;
            // Resto de tu código
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Crear(Campo modelo)
        {
            Campo campo_created = await _context.SaveCampo(modelo);

            if (campo_created.Id > 0)
                return RedirectToAction("Index", "Campo", new { id = modelo.EncuestaId });

            ViewData["Mensaje"] = "No se pudo crear el campo";
            return View();
        }

        public async Task<IActionResult> Editar(int id)
        {
            Campo modelo = await _context.GetCampoById(id);
            if (modelo == null)
            {
                return NotFound();
            }
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Campo modelo)
        {
            if (ModelState.IsValid)
            {

                await _context.UpdateCampo(modelo);
                return RedirectToAction("Index", "Campo", new { id = modelo.EncuestaId });
              
            }

            return View(modelo);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            Campo modelo = await _context.GetCampoById(id);
            if (modelo == null)
            {
                return NotFound();
            }
            return View(modelo);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            Campo modelo = await _context.GetCampoById(id);
            if (modelo != null)
            {

                await _context.DeleteCampo(id);
            }
            return RedirectToAction("Index", "Campo", new { id = modelo.EncuestaId });

        }
    }
}
