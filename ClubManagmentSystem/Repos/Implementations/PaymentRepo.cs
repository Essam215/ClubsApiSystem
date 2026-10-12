using ClubManagmentSystem.Data;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.Repos.Interfaces;

namespace ClubManagmentSystem.Repos.Implementations
{
    public class PaymentRepo : GenericRepo<Payment>, IPaymentRepo
    {
        private readonly ClubContext _context;
        public PaymentRepo(ClubContext context) : base(context)
        {
            _context = context;
        }
    }
}
