using ClubManagmentSystem.Data;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubManagmentSystem.Repos.Implementations
{
    public class FacilityRepo : GenericRepo<Facility>, IFacilityRepo
    {
        private readonly ClubContext _context;
        public FacilityRepo(ClubContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Facility>> OrderByCapacity()
        {
            return await _context.facilities.OrderByDescending(f => f.Capacity).ToListAsync();
        }
    }
}
