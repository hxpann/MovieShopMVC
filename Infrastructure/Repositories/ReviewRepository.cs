using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Review> GetReviewsByUser(int userId, int movieId)
        {
            var reviews = await _dbContext.Reviews.FirstOrDefaultAsync(r => r.UserId == userId && r.MovieId==movieId);
            return reviews;
        }
    }
}
