using ClubManagmentSystem.DTO_s;
using ClubManagmentSystem.Models;

namespace ClubManagmentSystem.Repos.Interfaces
{
    public interface IMemberShipRepo : IGenericRepo<MemberShip>
    {
        Task<List<MemberShip>> GetActiveMemberShips();
        Task<MemberShip> GetMemberShipById(int id, PatchMemberShipDto dto);
    }
}
