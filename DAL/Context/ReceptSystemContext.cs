using DAL.Model;
using Microsoft.EntityFrameworkCore;
namespace DAL.Context;

public class ReceptSystemContext: DbContext
{
    public ReceptSystemContext (DbContextOptions<ReceptSystemContext> options): base(options){}
    
    public DbSet<Recept> Recepter {get;set;}
    public DbSet<Apotek> Apoteker { get; set; }
    public DbSet<Lægehus> Lægehuse { get; set; }
    public DbSet<Ordination> Ordinationer { get; set; }
    public DbSet<ReceptUdlevering> ReceptUdleveringer { get; set; }
}