using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MockMovie : IMovieService
    {

        public async Task<MoviesViewModel> callApi()
        {
            string url = "https://api.themoviedb.org/3/movie/now_playing?api_key=ced9bc018ee91f7fa4fc7f417d3af19c&language=en-US";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    MoviesViewModel movies = await response.Content.ReadAsAsync<MoviesViewModel>();
                    return movies;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
           
        }
    }
}
