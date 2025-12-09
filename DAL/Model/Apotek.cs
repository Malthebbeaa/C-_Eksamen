using System.ComponentModel.DataAnnotations;

namespace DAL.Model;

public class Apotek
{
    [Key]
    public Guid ApotekId { get; set; }
    public string Navn { get; set; }
    public List<ReceptUdlevering> ReceptUdleveringer { get; set; } =  new List<ReceptUdlevering>();
    
    public Apotek(){}
}