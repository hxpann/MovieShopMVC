using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IFavoriteRepository:IRepository<Favorite>
    {
        Task<List<Favorite>> GetAllFavoritesForUser(int id);
        Task<Favorite> GetFavoriteById(int userid, int movieId);
    }
}
