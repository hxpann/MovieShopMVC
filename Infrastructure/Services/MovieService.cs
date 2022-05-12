﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public List<MovieCardModel> GetTop30GrossingMovies()
        {
            // call the movierepository class
            // get the entity class data and map them in to model class data
            // var movieRepo = new MovieRepository();
            // var movies = movieRepo.GetTop30GrossingMovies();
            var movies = _movieRepository.GetTop30GrossingMovies();
            var movieCards = new List<MovieCardModel>();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title
                });
            }

            return movieCards;
        }
    }
}
