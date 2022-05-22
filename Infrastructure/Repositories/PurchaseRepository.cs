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
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Purchase> GetPurchaseDetails(int userId, int movieId)
        {
            var purchase = await _dbContext.Purchases.FirstOrDefaultAsync(p => p.UserId == userId && p.MovieId == movieId);
            return purchase;
        }
        public async Task<List<Purchase>> GetMoviesPurchasedByUser(int userId)
        {
            var movies = await _dbContext.Purchases.Where(p => p.UserId == userId).Include(m => m.Movie).ToListAsync();

            return movies;
        }

    }
}
