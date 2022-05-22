using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsModel> GetCastDetails(int castId)
        {
            var cast = await _castRepository.GetById(castId);
            var castDetails = new CastDetailsModel()
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.TmdbUrl,
                ProfilePath = cast.ProfilePath
            };

            foreach (var movie in cast.MovieCasts)
            {
                castDetails.MovieCards.Add(new MovieCardModel { Id = movie.MovieId, Title = movie.Movie.Title, PosterUrl = movie.Movie.PosterUrl});
            }

            return castDetails;


        }
    }
}
