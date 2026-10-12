using System.ComponentModel.DataAnnotations;

namespace ClubManagmentSystem.DTO_s
{
    public class CreateMemberShipDto
    {
        
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
    }
    public class UpdateMemberShipDto
    {
        
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
    }
    public class GetMemberShipDto
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
    }
    public class PatchMemberShipDto
    {
        
        public DateTime EndDate { get; set; }
        
    }
}
