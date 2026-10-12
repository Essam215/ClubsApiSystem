using System.ComponentModel.DataAnnotations;

namespace ClubManagmentSystem.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required, Range(100, 10000)]
        public decimal Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public int MemberShipId { get; set; }
        public MemberShip MemberShip { get; set; }
    }
}
