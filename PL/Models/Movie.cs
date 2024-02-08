using Microsoft.VisualBasic;

namespace PL.Models
{
    public class Movie
    {
        public int IdMovie { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public int Popularidad { get; set; }
        public int VotoPromedio { get; set; }
        public DateFormat Fecha { get; set; }
        public string Imagen { get; set; }
        public List<object> Movies { get; set; }

    

    }
}
