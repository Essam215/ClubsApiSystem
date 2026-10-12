using ClubManagmentSystem.Models;

namespace ClubManagmentSystem.Repos.Interfaces
{
    public interface IBookingRepo : IGenericRepo<Booking>
    {
        Task<List<Booking>> Pagination(int page, int pageSize);
    }
}
