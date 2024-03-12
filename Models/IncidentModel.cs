using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace incidentdbapi;

[Table("incident")]
public class IncidentModel
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Incidentid { get; set; }

    public string? IncidentName { get; set; }

    public string? IncidentAssignTo { get; set; }

    public string? IncidentStatus { get; set; }

    public string? IncidentCreateDate { get; set; }

    public string? IncidentCreateBy { get; set; }

    public string? IncidentDescription { get; set; }

    public string? IncidentModifyDate { get; set; }

    public string? IncidentModifyBy { get; set; }

    public string? IncidentComment { get; set; }
}