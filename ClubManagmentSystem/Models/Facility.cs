using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace ClubManagmentSystem.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Facility
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, Range(1, 100)]
        public int Capacity { get; set; }
        [Required, Range(50, 10000)]
        public decimal HourlyPrice { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>(); 
    }
}
