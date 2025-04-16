using DomainLayer.TheMilesTours.Entities;
using Infrastructure.TheMilesTours.IRepository;
using Infrastructure.TheMilesTours.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TheMilesTours.Repository
{
    public class ReviewRepository:IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddReviews(Reviews reviews)
        {
           await _context.Reviews.AddAsync(reviews);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Reviews>> GetAll()
        {
            return await _context.Reviews.Include(x=>x.Tour).ToListAsync();
        }
    }
}
