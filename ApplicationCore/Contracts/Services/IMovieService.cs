using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    //deal with Model classes: model is the data need for the view
    public interface IMovieService
    {
        // home/index action method
        List<MovieCardModel> GetTop30GrossingMovies();
    }   
}
