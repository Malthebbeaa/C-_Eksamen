using System.ComponentModel.DataAnnotations;

namespace DAL.Model;

public class Ordination
{
    [Key]
    public Guid OrdinationId { get; set; }
    public string Lægemiddel { get; set; }
    public int AntalUdleveringer { get; set; }
    public int AntalForetagedeUdleveringer { get; set; }
    
    public Ordination(){}
}