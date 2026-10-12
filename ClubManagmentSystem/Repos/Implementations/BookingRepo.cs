using ClubManagmentSystem.Data;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubManagmentSystem.Repos.Implementations
{
    public class BookingRepo : GenericRepo<Booking>, IBookingRepo 
    {
        private readonly ClubContext _context;
        public BookingRepo(ClubContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Booking>> Pagination(int page, int pageSize)
        {
            return await _context.bookings
                .OrderBy(b => b.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
