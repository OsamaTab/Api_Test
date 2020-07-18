using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComanderApi.Controllers
{
    [Route("")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<MoviesModel>> GetAllMovie()
        {
            var movie = _movieService.callApi();
            return Ok(movie);
        }


    }
}
