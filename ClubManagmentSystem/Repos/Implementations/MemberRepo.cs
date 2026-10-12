using ClubManagmentSystem.Data;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubManagmentSystem.Repos.Implementations
{
    public class MemberRepo : GenericRepo<Member>, IMemberRepo
    {
        private readonly ClubContext _context;
        public MemberRepo(ClubContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Member>> Pagination(int page, int pageSize)
        {
            return await _context.members.Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Member>> Search(string name)
        {
            return await _context.members.Where(m => m.FullName.ToLower().Contains(name.ToLower())).ToListAsync();
        }
    }
}
