using ClubManagmentSystem.Repos.Implementations;
using ClubManagmentSystem.Repos.Interfaces;

namespace ClubManagmentSystem.UOW
{
    public interface IUnitOfWork 
    {
        public IBookingRepo bookingRepo { get; }
        public IFacilityRepo facilityRepo { get; }
        public IMemberRepo memberRepo { get; }
        public IMemberShipRepo  memberShipRepo { get; }
        public IPaymentRepo paymentRepo { get; }

        public Task<int> SaveChanges();
    }
}
