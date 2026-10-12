using System.ComponentModel.DataAnnotations;

namespace ClubManagmentSystem.DTO_s;
    public class GetMemberDto
    {
    [Key]
    public int Id { get; set; }
    [Required, MinLength(3), MaxLength(100)]
    public string FullName { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required, Phone]
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
}
public class UpdateMemberDto
{
   
    [Required, MinLength(3), MaxLength(100)]
    public string FullName { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required, Phone]
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
}
public class CreateMemberDto
{
   
    [Required, MinLength(3), MaxLength(100)]
    public string FullName { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required, Phone]
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
}

