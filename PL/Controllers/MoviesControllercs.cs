using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using PL.Models;
using static System.Net.WebRequestMethods;

namespace PL.Controllers
{
    public class MoviesControllercs : Controller
    {
        [HttpGet]
        public IActionResult GetMoviePopular()
        {
            Models.Movie movie = new Models.Movie();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                var resTask = client.GetAsync("movie/popular?api_key=4e453a7d1016a2f4fcda3c417de8442e");
                resTask.Wait();
                var respuesta = resTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var readTask = respuesta.Content.ReadAsStringAsync();
                    readTask.Wait();
                    movie.Movies = new List<object>();
                    dynamic JsonOb = JObject.Parse(readTask.Result);
                    foreach (var registro in JsonOb.results)
                    {
                        Models.Movie movies = new Models.Movie();
                        movies.IdMovie = registro.id;
                        movies.Titulo = registro.title;
                        movies.Popularidad = registro.popularity;
                        movies.Resumen = registro.overview;
                        movies.VotoPromedio = registro.vote_average;
                        movies.Imagen = "https://image.tmdb.org/t/p/w1280" + registro.poster_path;
                        movie.Movies.Add(movies);
                    }
                }
                else
                {
                    return View(movie);
                }

            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult AddFavoritos(int IdMovie)
        {
            Models.Movie movie = new Models.Movie();
            using (HttpClient client = new HttpClient())
            {
                var objetoAnonimo = new
                {
                    media_type = "movie",
                    media_id = IdMovie,
                    favorite = true

                };
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                var responseTask = client.PostAsJsonAsync("account/20961205/favorite?api_key=4e453a7d1016a2f4fcda3c417de8442e&session_id=62e18c82650b85b6b60b32199ad4b7dd869c870d", objetoAnonimo);
                responseTask.Wait();
                var respuesta = responseTask.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var readTask = respuesta.Content.ReadAsAsync<dynamic>();
                    readTask.Wait();
                    var result = readTask.Result;
                    ViewBag.Mensaje = result.success;
                    if (result.success = true)
                    {

                        ViewBag.Mensaje = ("Se elimino de tus favoritos ");

                    }
                    else
                    {
                        ViewBag.Mensaje = ("Ocurrio un Error");
                    }
                }
                return View("Modal");

            }



        }

        [HttpGet]
        public IActionResult GetFavoritos()
        {
            Models.Movie movie = new Models.Movie();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                var resTask = client.GetAsync("account/20961205/favorite/movies?api_key=4e453a7d1016a2f4fcda3c417de8442e&session_id=62e18c82650b85b6b60b32199ad4b7dd869c870d");
                resTask.Wait();
                var respuesta = resTask.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var readTask = respuesta.Content.ReadAsStringAsync();
                    readTask.Wait();
                    movie.Movies = new List<object>();
                    dynamic JsonOb = JObject.Parse(readTask.Result);
                    foreach (var registro in JsonOb.results)
                    {
                        Models.Movie movies = new Models.Movie();
                        movies.IdMovie = registro.id;
                        movies.Titulo = registro.title;
                        movies.Popularidad = registro.popularity;
                        movies.Resumen = registro.overview;
                        movies.VotoPromedio = registro.vote_average;
                        movies.Imagen = "https://image.tmdb.org/t/p/w1280" + registro.poster_path;
                        movie.Movies.Add(movies);
                    }
                }
                else
                {
                    return View(movie);
                }

            }
            return View(movie);


        }

        [HttpGet]
        public IActionResult DeleteFavoritos(int IdMovie)
        {
            Models.Movie movie = new Models.Movie();
            using (HttpClient client = new HttpClient())
            {
                var objetoAnonimo = new
                {
                    media_type = "movie",
                    media_id = IdMovie,
                    favorite = false

                };
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
                var responseTask = client.PostAsJsonAsync("account/20961205/favorite?api_key=4e453a7d1016a2f4fcda3c417de8442e&session_id=62e18c82650b85b6b60b32199ad4b7dd869c870d", objetoAnonimo);
                responseTask.Wait();
                var respuesta = responseTask.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var readTask = respuesta.Content.ReadAsAsync<dynamic>();
                    readTask.Wait();
                    var result = readTask.Result;
                    ViewBag.Mensaje = result.success;
                    

                    if (result.success = true)
                    {

                        ViewBag.Mensaje = ("Se elimino de tus favoritos ");

                    }
                    else
                    {
                        ViewBag.Mensaje = ("Ocurrio un Error");
                    }



                }
                return View("Modal");

            }





        }



    }
}
