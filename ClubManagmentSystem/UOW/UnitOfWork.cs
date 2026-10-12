using ClubManagmentSystem.Data;
using ClubManagmentSystem.Repos.Implementations;
using ClubManagmentSystem.Repos.Interfaces;

namespace ClubManagmentSystem.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClubContext _context;

        public UnitOfWork(ClubContext context, IBookingRepo bookingRepo, IFacilityRepo facilityRepo, IMemberRepo memberRepo, IMemberShipRepo memberShipRepo, IPaymentRepo paymentRepo)
        {
            _context = context;
            this.bookingRepo = bookingRepo;
            this.facilityRepo = facilityRepo;
            this.memberRepo = memberRepo;
            this.memberShipRepo = memberShipRepo;
            this.paymentRepo = paymentRepo;
        }

        public IBookingRepo bookingRepo { get; }
        public IFacilityRepo facilityRepo { get; }
        public IMemberRepo memberRepo { get; }
        public IMemberShipRepo memberShipRepo { get; }
        public IPaymentRepo paymentRepo { get; }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
