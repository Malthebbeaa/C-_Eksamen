using DAL.Model;

namespace DTO;

public class ReceptDTO
{
    public Guid ReceptId { get; set; }
    public string PatientCpr { get; set; }
    public DateTime OprettelsesDato { get; set; }
    public bool Lukket { get; set; }
    public Guid LægehusId { get; set; }
    public List<OrdinationDTO> Ordinationer { get; set; }
    public List<ReceptUdleveringDTO> ReceptUdleveringer { get; set; }
}