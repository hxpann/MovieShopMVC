using ApplicationCore.Entities;
using ApplicationCore.Models;
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
        Task<List<Movie>> GetTop30GrossingMovies();

        // need to return totalcount, pagesize, pagenumber,totalpages
        // create a new class PageModel
        // Or Tuple
        //Task<(IEnumerable<Movie>, int totalCount, int totalPages)> GetMoviesByGenres(int genreId, int pageSize =30, int page = 1);
        Task<PagedResultSet<Movie>> GetMoviesByGenres(int genreId, int pageSize = 30, int page = 1);

    }
}
