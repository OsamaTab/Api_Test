using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IMovieService
    {
        public Task<MoviesViewModel> callApi();
    }
}
