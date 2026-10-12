using System.ComponentModel.DataAnnotations;

namespace ClubManagmentSystem.DTO_s;
    public class GetBookingDto
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime BookingDate { get; set; }
    [Required]
    public TimeSpan StartTime { get; set; }
    [Required]
    public TimeSpan EndTime { get; set; }
    [Required, Range(1, 100)]
    public int GroupSize { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public int MemberId { get; set; }
    [Required]
    public int FacilityId { get; set; }
}
public class CreateBookingDto
{
  
    [Required]
    public DateTime BookingDate { get; set; }
    [Required]
    public TimeSpan StartTime { get; set; }
    [Required]
    public TimeSpan EndTime { get; set; }
    [Required, Range(1, 100)]
    public int GroupSize { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public int MemberId { get; set; }
    [Required]
    public int FacilityId { get; set; }
}
public class UpdateBookingDto
{
 
    [Required]
    public DateTime BookingDate { get; set; }
    [Required]
    public TimeSpan StartTime { get; set; }
    [Required]
    public TimeSpan EndTime { get; set; }
    [Required, Range(1, 100)]
    public int GroupSize { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public int MemberId { get; set; }
    [Required]
    public int FacilityId { get; set; }
}
