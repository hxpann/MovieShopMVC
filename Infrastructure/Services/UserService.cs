using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        public UserService(IPurchaseRepository purchaseRepository, 
            IReviewRepository reviewRepository, IFavoriteRepository favoriteRepositroy)
        {
            _purchaseRepository = purchaseRepository;
            _reviewRepository = reviewRepository;
            _favoriteRepository = favoriteRepositroy;
        }

        


        //Reviews
       
        public async Task<ReviewRequestModel> GetReviewsByUser(int userId,int movieId)
        {
           var reviews = await _reviewRepository.GetReviewsByUser(userId, movieId);
           var reviewsRequest = new ReviewRequestModel
           {
                MovieId = movieId,
                UserId = userId,
                Rating = reviews.Rating,
                ReviewText = reviews.ReviewText
           };

           return reviewsRequest;
        }
        public async Task<bool> AddMovieReview(ReviewRequestModel reviewRequest)
        {
            var review = new Review
            {
                MovieId = reviewRequest.MovieId,
                UserId = reviewRequest.UserId,
                Rating = reviewRequest.Rating,
                ReviewText = reviewRequest.ReviewText
            };

            var createdReview = await _reviewRepository.Add(review);
            //save the user object to User Table
            if (createdReview.UserId > 0 && createdReview.MovieId > 0)
            {
                return true;
            }
            return false;
        }

        public Task<bool> DeleteMovieReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }


        //Favorite

        public async Task<bool> AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            var favorite = new Favorite
            {
                MovieId = favoriteRequest.MovieId,
                UserId = favoriteRequest.UserId,
            };

            var createdfavorite = await _favoriteRepository.Add(favorite);
            //save the user object to User Table
            if (createdfavorite.Id > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> FavoriteExists(int id, int movieId)
        {
            var favorite = await _favoriteRepository.GetFavoriteById(id, movieId);
            if (favorite == null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<MovieCardModel>> GetAllFavoritesForUser(int id)
        {
            var favorite = await _favoriteRepository.GetAllFavoritesForUser(id);
            var movieCards = new List<MovieCardModel>();

            foreach (var movie in favorite)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.Movie.PosterUrl,
                    Title = movie.Movie.Title
                });
            }

            return movieCards;
        }
        public Task<bool> RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        
        //Purchase

        public async Task<List<MovieCardModel>> GetAllPurchasesForUser(int userId)
        {
            var purchases = await _purchaseRepository.GetMoviesPurchasedByUser(userId);
            var movieCards = new List<MovieCardModel>();

            foreach (var purchase in purchases)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = purchase.Id,
                    PosterUrl = purchase.Movie.PosterUrl,
                    Title = purchase.Movie.Title
                });
            }

            return movieCards;
        }


        public async Task<PurchaseRequestModel> GetPurchasesDetails(int userId, int movieId)
        {
            var purchase = await _purchaseRepository.GetPurchaseDetails(userId, movieId);
            var purchaseDetails = new PurchaseRequestModel
            {
                UserId = userId,
                MovieId = movieId,
                Price = purchase.TotalPrice,
                PurchaseDate = purchase.PurchaseDateTime,
                PurchaseNumber = purchase.PurchaseNumber
            };
            return purchaseDetails;

        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            var purchase = await _purchaseRepository.GetPurchaseDetails(purchaseRequest.MovieId, userId);
            if (purchase == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {
            var purchase = new Purchase
            {
                MovieId = purchaseRequest.MovieId,
                UserId = userId,
                TotalPrice = purchaseRequest.Price,
                PurchaseDateTime = purchaseRequest.PurchaseDate,
                PurchaseNumber = purchaseRequest.PurchaseNumber
            };

            var createdPurchase = await _purchaseRepository.Add(purchase);
            //save the user object to User Table
            if (createdPurchase.Id > 0)
            {
                return true;
            }
            return false;

        }

        
    }
}
