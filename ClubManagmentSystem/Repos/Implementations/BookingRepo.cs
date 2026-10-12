using ClubManagmentSystem.Data;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repos.Interfaces;

namespace ClubManagmentSystem.Repos.Implementations
{
    public class BookingRepo : GenericRepo<Booking>, IBookingRepo 
    {
        public BookingRepo(ClubContext context) : base(context)
        {
        }
    }
}
