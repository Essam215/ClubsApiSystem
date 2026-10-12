using System.ComponentModel.DataAnnotations;

namespace ClubManagmentSystem.DTO_s
{
    public class CreateFacilityDto
    {
       
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, Range(1, 100)]
        public int Capacity { get; set; }
        [Required, Range(50, 10000)]
        public decimal HourlyPrice { get; set; }
    }
    public class UpdateFacilityDto
    {
        
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, Range(1, 100)]
        public int Capacity { get; set; }
        [Required, Range(50, 10000)]
        public decimal HourlyPrice { get; set; }
    }
    public class GetFacilityDto
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, Range(1, 100)]
        public int Capacity { get; set; }
        [Required, Range(50, 10000)]
        public decimal HourlyPrice { get; set; }
    }
}
