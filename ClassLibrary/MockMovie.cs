using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MockMovie : IMovieService
    {

        public List<MoviesModel> callApi()
        {
            string url = "https://api.themoviedb.org/3/movie/now_playing?api_key=ced9bc018ee91f7fa4fc7f417d3af19c&language=en-US";

            //using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            //{
            //    if (response.IsSuccessStatusCode)
            //    {
            //        MoviesViewModel movies = await response.Content.ReadAsAsync<MoviesViewModel>();
            //        return movies;
            //    }
            //    else
            //    {
            //        throw new Exception(response.ReasonPhrase);
            //    }

            //}
            WebClient client = new WebClient();
            

            Stream stream = client.OpenRead(url);
            StreamReader reader = new StreamReader(stream);
            JObject jObject = JObject.Parse(reader.ReadLine());

            List<MoviesModel> movies =new List<MoviesModel>();
            int max = Int32.Parse(jObject["results"].Count().ToString());

            for (int i = 0; i < max ; i++)
            {
                MoviesModel movie = new MoviesModel()
                {
                    Id = jObject["results"][i]["id"].ToString(),
                    Popularity = jObject["results"][i]["popularity"].ToString(),
                    Title = jObject["results"][i]["title"].ToString()

                };
                movies.Add(movie);
            }
            return movies;
            
        }
    }
}
