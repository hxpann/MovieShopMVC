using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IPurchaseRepository : IRepository<Purchase>
    {
        public Task<Purchase> GetPurchaseDetails(int userId, int movieId);
        public Task<List<Purchase>> GetMoviesPurchasedByUser(int userId);
    }
}
