using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    //deal with Entity classes:Entity is the data
    public interface IMovieRepository : IRepository<Movie>
    {
        List<Movie> GetTop30GrossingMovies();
    }
}
