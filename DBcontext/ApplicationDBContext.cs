
using incidentdbapi;
using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
    public DbSet<RegistrationModel> RegisterDBSet { get; set; }
    public DbSet<IncidentModel> IncidentsDBSet { get; set; }
}

