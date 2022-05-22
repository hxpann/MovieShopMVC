using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Favorite>> GetAllFavoritesForUser(int id)
        {
            var favorite = await _dbContext.Favorites.Where(f => f.UserId == id).Include(m => m.Movie).ToListAsync();
            return favorite;
        }

        public async Task<Favorite> GetFavoriteById(int userId, int movieId)
        {
            var favorite = await _dbContext.Favorites.FirstOrDefaultAsync(f => f.UserId == userId && f.MovieId == movieId);
            return favorite;
        }
    }
}
