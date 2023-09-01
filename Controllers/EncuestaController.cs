
using encuesta.Models;
using encuesta.Services.Implement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using encuensta.Services.Implement;

namespace encuesta.Controllers
{
    [Authorize]
    public class EncuestaController : Controller
    {

        private readonly IEncuestaService _context;

        public EncuestaController(IEncuestaService context)
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
        public async Task<IActionResult> Index(List<Encuesta> encuestas)
        {
            if (encuestas is not null)
            {
                List<Encuesta> encuestas_found = await _context.GetListEncuesta();
                encuestas = encuestas_found;
                
            }

            return View(encuestas);
        }


        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Encuesta encuesta)
        {
            string link = "http://localhost:32034/Encuesta/DetallesEncuesta/";
            encuesta.Enlace = link;

            Encuesta encuesta_created = await _context.SaveEncuesta(encuesta);



         

            if (encuesta_created.Id > 0) {
                string encriptId = EncryptId(encuesta_created.Id);

                encuesta_created.Enlace = link + encriptId;
                await _context.UpdateEncuesta(encuesta_created);

                return RedirectToAction("Index", "Encuesta");
            } else
            {
                ViewData["Mensaje"] = "No se pudo crear la encuesta";
                return View();
            }
        }

        public async Task<IActionResult> Editar(int id)
        {
            Encuesta encuesta = await _context.GetEncuestaById(id);
            if (encuesta == null)
            {
                return NotFound();
            }
            return View(encuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Encuesta encuesta)
        {
            if (ModelState.IsValid)
            {

                await _context.UpdateEncuesta(encuesta);
                return RedirectToAction("Index", "Encuesta");
            }

            return View(encuesta);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            Encuesta encuesta = await _context.GetEncuestaById(id);
            if (encuesta == null)
            {
                return NotFound();
            }
            return View(encuesta);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            Encuesta encuesta = await _context.GetEncuestaById(id);
            if (encuesta != null)
            {

                await _context.DeleteEncuesta(id);
            }
            return RedirectToAction("Index", "Encuesta");
        }

        [HttpPost]
        public async Task<IActionResult> GetEncuestaById(int id)
        {
           var encuesta = await _context.GetEncuestaById(id);
            
            return View(encuesta);
        }

        public static string EncryptId(int id)
        {
            byte[] idBytes = BitConverter.GetBytes(id);
            return Convert.ToBase64String(idBytes);
        }


        [AllowAnonymous]
        public async Task<IActionResult> DetallesEncuesta(string id)
        {
            try
            {
                byte[] idBytes = Convert.FromBase64String(id);
                int encuestaId = BitConverter.ToInt32(idBytes, 0);




                // Lógica para buscar la encuesta por su ID
                EncuestaDTO encuesta = await _context.GetEncuestaDTOByIdNewResponse(encuestaId);

                if (encuesta == null)
                {
                    // Manejo si la encuesta no se encuentra
                    return RedirectToAction("Index");
                }

                return View(encuesta);
            }
            catch (Exception)
            {
                // Manejo si ocurre algún error
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Historial(string id)
        {
            try
            {
                byte[] idBytes = Convert.FromBase64String(id);
                int encuestaId = BitConverter.ToInt32(idBytes, 0);




                // Lógica para buscar la encuesta por su ID
                EncuestaDTO encuesta = await _context.GetEncuestaDTOById(encuestaId);

                if (encuesta == null)
                {
                    // Manejo si la encuesta no se encuentra
                    return RedirectToAction("Index");
                }

                return View(encuesta);
            }
            catch (Exception)
            {
                // Manejo si ocurre algún error
                return RedirectToAction("Index");
            }
        }

        [AllowAnonymous]
		public IActionResult Success()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> DetallesEncuesta(ResponseEncuesta respuesta)
        {
                    await _context.SaveRespuesta(respuesta);
                    EncuestaDTO encuesta = await _context.GetEncuestaDTOByIdNewResponse(respuesta.EncuestaId);
                    return View(encuesta);

        }



    }
}
