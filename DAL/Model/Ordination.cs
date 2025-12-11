using System.ComponentModel.DataAnnotations;

namespace DAL.Model;

public class Ordination
{
    [Key] public Guid OrdinationId { get; set; }
    public string Lægemiddel { get; set; }
    public string Dosis { get; set; }
    public int AntalUdleveringer { get; set; }
    public int AntalForetagneUdleveringer { get; set; }

    public Ordination() { }

    public void ForetagUdlevering()
    {
        AntalForetagneUdleveringer++;
        if (AntalForetagneUdleveringer > AntalUdleveringer)
        { 
            AntalForetagneUdleveringer =  AntalUdleveringer;
        }
    }
}