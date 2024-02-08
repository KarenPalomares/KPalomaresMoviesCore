using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static Dictionary<string, object> Add(ML.Usuario usuario)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exception", "" }, { "Resultado", false } };
            try
            {
                using (DL.KpalomaresMoviesContext context = new DL.KpalomaresMoviesContext())
                {
                    var filasAfectadas = context.Database.ExecuteSqlRaw($"USUARIOAdd'{usuario.Nombre}','{usuario.ApellidoPaterno}','{usuario.ApellidoMaterno}','{usuario.UserName}','{usuario.Email}','{usuario.Password}'");
                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    
                }

            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"] = ex.Message;
            }
            return diccionario;
        }

        public static Dictionary<string, object> GetByEmail(string Email)
        {

            Dictionary<string, object> result = new Dictionary<string, object> { { "Excepcion", "" }, { "Resultado", false } };
            try
            {
                using (DL.KpalomaresMoviesContext context = new DL.KpalomaresMoviesContext())
                {
                    var objeto = context.Database.ExecuteSqlRaw($"UsuarioGetByEmail{Email}");

                    if (objeto != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        result["Resultado"] = true;
                        result["Usuario"] = usuario;
                    }
                    else
                    {
                        result["Resultado"] = false;
                    }

                }
            }

            catch (Exception ex)
            {
               result["Resultado"] = false;
                result["Usuario"] = ex.Message;
            }
            return result;
        }
    }

}

