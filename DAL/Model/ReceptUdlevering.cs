using System.ComponentModel.DataAnnotations;

namespace DAL.Model;

public class ReceptUdlevering
{
    [Key]
    public Guid ReceptUdleveringId { get; set; }
    public Guid ApotekId { get; set; }
    public Apotek Apotek { get; set; }
    public Guid ReceptId { get; set; }
    public Recept Recept { get; set; }
    public DateTime UdleveringsDato { get; set; }
    
    public ReceptUdlevering(){}
}