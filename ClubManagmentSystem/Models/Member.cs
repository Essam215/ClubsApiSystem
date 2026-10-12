using System.ComponentModel.DataAnnotations;

namespace ClubManagmentSystem.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        public DateTime DateOfBirth     { get; set; }

        public MemberShip MemberShip { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
