using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class LoginController : Controller
    {

        [HttpPost]
        public ActionResult Login(string Email, byte[] Password)
        {
            Dictionary<string, object> resultado = BL.Usuario.GetByEmail(Email);
            bool result = (bool)resultado["Resultado"];
            if (result == true)
            {
                ML.Usuario usuario = (ML.Usuario)resultado["Usuario"];
                if (usuario.Email != "")
                {
                    if (usuario.Password == Password)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "El Email no es Valido";
                return PartialView("Modal");
            }
            return View();




        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}
