namespace DTO;

public class ApotekDTO
{
    public Guid ApotekId { get; set; }
    public string Navn { get; set; }
    public List<ReceptUdleveringDTO> ReceptUdlevering { get; set; }
}