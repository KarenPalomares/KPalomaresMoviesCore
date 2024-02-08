using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
                Dictionary<string, object> result = BL.Usuario.Add(usuario);
                bool resultado = (bool)result["Resultado"];

                if (resultado == true)
                {
                    ViewBag.Mensaje = "El usuario se ha registrado";
                    return View(usuario);
                }
                else
                {
                    string exepcion = (string)result["Excepcion"];
                    ViewBag.Mensaje = "El usuario no se ha podido registrar " + exepcion;
                    return View(usuario);
                }
            
            return View(usuario);
        }
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }


    }
}
