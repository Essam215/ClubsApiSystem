using ClubManagmentSystem.Data;
using ClubManagmentSystem.DTO_s;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubManagmentSystem.Repos.Implementations
{
    public class MemberShipRepo : GenericRepo<MemberShip>, IMemberShipRepo
    {
        private readonly ClubContext _context;
        public MemberShipRepo(ClubContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<MemberShip>> GetActiveMemberShips()
        {
            return await _context.memberShips.Where(ms => ms.Status == "Active").ToListAsync();
        }

        public async Task<MemberShip> GetMemberShipById(int id, PatchMemberShipDto dto)
        {
            var data = await _context.memberShips.FindAsync(id);
            if(data != null)
            {
                data.EndDate = dto.EndDate;
                data.Status = "Active";
            }
            return data;

        }
    }
}
