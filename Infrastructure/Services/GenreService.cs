using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class GenreService : Repository<Genre>, IGenreService
    {
        public GenreService(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            var genres = await GetAll();
            var genresList = new List<Genre>();

            foreach (var genre in genres)
            {
                genresList.Add(new Genre
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }

            return genresList;
        }
    }
}
