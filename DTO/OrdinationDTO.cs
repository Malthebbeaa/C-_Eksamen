namespace DTO;

public class OrdinationDTO
{
    public Guid OrdinationId { get; set; }
    public string Lægemiddel { get; set; }
    public int AntalUdleveringer { get; set; }
    public int AntalForetagedeUdleveringer { get; set; }
}