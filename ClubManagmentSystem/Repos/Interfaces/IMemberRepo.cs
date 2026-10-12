using ClubManagmentSystem.Models;

namespace ClubManagmentSystem.Repos.Interfaces
{
    public interface IMemberRepo : IGenericRepo<Member>
    {
        Task<List<Member>> Pagination(int page, int pageSize);
        Task<List<Member>> Search(string name);
    }
}
