namespace DTO;

public class LægehusDTO
{
    public Guid Ydernummer { get; set; }
    public string Navn { get; set; }
    public List<ReceptDTO> Recepter { get; set; }
}