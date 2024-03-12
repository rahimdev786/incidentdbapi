
namespace incidentdbapi;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("login")]
public class RegistrationModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? UserEmail { get; set; }
    public string? UserPassword { get; set; }
    public string? UserRole { get; set; }
    public string? UserCreateDate { get; set; }
    public string? UserCompany { get; set; }

}
