using System.ComponentModel.DataAnnotations;

namespace ClubManagmentSystem.Models
{
    public class MemberShip
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required, Range(100, 10000)]
        public decimal Price { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int MemberId { get; set; }
        public Member Member { get; set; }  
        public List<Payment> Payments { get; set; } = new List<Payment>();

    }
}
