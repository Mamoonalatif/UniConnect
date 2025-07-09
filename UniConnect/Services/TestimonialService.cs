using UniConnect.Modals;
using UniConnect.Data;
using Microsoft.EntityFrameworkCore;

namespace UniConnect.Services
{
    public class TestimonialService
    {
        private readonly AppDbContext _context;

        public TestimonialService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Testimonial>> GetTestimonialsAsync()
        {
            return await _context.Testimonials
                .OrderByDescending(t => t.SubmittedAt)
                .ToListAsync();
        }

        public async Task AddTestimonialAsync(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();
        }
    }

   
}
