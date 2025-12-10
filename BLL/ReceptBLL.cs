using DAL.Model;
using DAL.Repository;
using DTO;

namespace BLL;

public class ReceptBLL
{
    private readonly ReceptRepository _repository;
    private readonly ReceptUdleveringRepository _udleveringRepository;
    private readonly ApotekRepository _apotekRepository;

    public ReceptBLL(ReceptRepository repository,  ReceptUdleveringRepository udleveringRepository,  ApotekRepository apotekRepository)
    {
        _repository = repository;
        _udleveringRepository = udleveringRepository;
        _apotekRepository = apotekRepository;
    }

    public ReceptDTO? GetRecept(Guid id)
    {
        var recept = _repository.GetRecept(id);
        if (recept == null) return null;
        return Mapper.Map(recept);
    }

    public List<ReceptDTO> GetAllRecepter()
    {
        var recepter = _repository.GetAllRecepts();
        return recepter.Select(Mapper.Map).ToList();
    }

    public List<ReceptDTO> GetRecepterByCpr(string cpr)
    {
        var recepter = _repository.GetReceptByCpr(cpr);
        return recepter.Select(Mapper.Map).ToList();
    }

    public ReceptDTO CreateRecept(ReceptDTO recept)
    {
        var mappedReceptDto = Mapper.Map(recept);
        var newRecept = _repository.CreateRecept(mappedReceptDto);
        return Mapper.Map(newRecept);
    }

    public bool ForetagReceptUdlevering(Guid receptId, Guid ordinationId, Guid apotekNr)
    {
        var recept = _repository.GetRecept(receptId);
        if (recept == null) return false;
        
        var ordinationToUpdate = recept.Ordinationer.FirstOrDefault(o => o.OrdinationId == ordinationId);
        if (ordinationToUpdate == null) return false;
        
        var apotek = _apotekRepository.GetApotek(apotekNr);
        if (apotek == null) return false;
        
        ordinationToUpdate.AntalForetagneUdleveringer++;
        
        if (recept.Ordinationer.TrueForAll(o => o.AntalUdleveringer == o.AntalForetagneUdleveringer))
        {
            recept.Lukket = true;
        }

        var receptUdlevering = new ReceptUdleveringDTO()
        {
            ApotekId = apotek.ApotekId,
            ReceptUdleveringId = Guid.NewGuid(),
            ReceptId = receptId,
            UdleveringsDato = DateTime.Now,
        };
        
        _udleveringRepository.CreateReceptUdlevering(Mapper.Map(receptUdlevering));
        
        return _repository.UpdateRecept(recept);
    }

    public int LukAlleUdløbneRecepter()
    {
        return _repository.LukAlleUdløbneRecepter();
    }
}