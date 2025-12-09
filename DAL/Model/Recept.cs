using System.ComponentModel.DataAnnotations;

namespace DAL.Model;

public class Recept
{
    [Key]
    public Guid ReceptId { get; set; }
    public string PatientCpr { get; set; }
    public DateTime OprettelsesDato { get; set; }
    public bool Lukket { get; set; }
    public Guid LægehusYdernummer { get; set; }
    public Lægehus Lægehus { get; set; }
    public List<Ordination> Ordinationer { get; set; } = new List<Ordination>();
    public List<ReceptUdlevering> ReceptUdleveringer { get; set; } = new List<ReceptUdlevering>();
    
    public Recept(){}
}