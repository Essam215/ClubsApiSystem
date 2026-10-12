using ClubManagmentSystem.Data;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repos.Interfaces;

namespace ClubManagmentSystem.Repos.Implementations
{
    public class FacilityRepo : GenericRepo<Facility>, IFacilityRepo
    {
        public FacilityRepo(ClubContext context) : base(context)
        {
        }
    }
}
