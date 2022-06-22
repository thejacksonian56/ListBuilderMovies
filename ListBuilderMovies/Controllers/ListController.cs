using Microsoft.AspNetCore.Mvc;
using ListBuilderMovies.Services;
using ListBuilderMovies.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System;

namespace ListBuilderMovies.Controllers
{
    public class ListController : Controller
    {
        IHttpClientFactory _httpClientFactory;
        IMovieListData _tempdata;
        public ListController(IHttpClientFactory httpClientFactory, IMovieListData tempdata)
        {
            _httpClientFactory = httpClientFactory;
            _tempdata = tempdata;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.movieLists = _tempdata.ReadAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieList obj)
        {
            _tempdata.newMovieList(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            MovieList obj = _tempdata.getMovieListById(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            MovieList obj = _tempdata.getMovieListById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Delete(MovieList obj)
        {
            _tempdata.deleteMovieList(obj.id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            MovieList obj = _tempdata.getMovieListById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(MovieList movieList)
        {
            _tempdata.editMovieList(movieList);
            return View(movieList);
        }

        [HttpGet]
        public IActionResult AddMovie(int? id, string query, string t, string d, string p, string i)
        {
            if (t != null && id != null && d != null && p != null && i != null)
            {
                Movie tester = new Movie()
                {
                    Name = t,
                    Description = d,
                    ImageLocation = p,
                    Url = i,
                    Id = id
                };
                _tempdata.addMovie(tester);
                return View(tester);
            }
            else
            {
                Movie movie = new Movie();
                movie.Id = (int)id;
                if (query != null)
                {
                    HttpClient httpClient = _httpClientFactory.CreateClient();
                    httpClient.BaseAddress = new Uri("https://api.themoviedb.org/");
                    var response = httpClient.GetFromJsonAsync<APICall>("https://api.themoviedb.org/3/search/movie?api_key=7ad68cf18a0e19092db7f4afdc463c23&language=en-US&query=" + query + "&page=1&include_adult=false");
                    APICall call = response.Result;
                    ViewBag.Query = call;
                }
                return View(movie); 
            }
        }

        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (movie != null)
            {
                _tempdata.addMovie(movie);
                return View(movie);
            }
            return View();
        }
    }
}
