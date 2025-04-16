using ApplicationLayer.TheMilesTours.IService;
using DomainLayer.TheMilesTours.Entities;
using Infrastructure.TheMilesTours.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.TheMilesTours.Service
{
    public class ReviewService:IReviewsService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewsRepository)
        {
            _reviewRepository = reviewsRepository;

        }

        public async Task<bool> AddReviews(Reviews reviews)
        {
            return await _reviewRepository.AddReviews(reviews); 
        }

        public async Task<IEnumerable<Reviews>> GetAll()
        {
           return await _reviewRepository.GetAll();
        }
    }
}
