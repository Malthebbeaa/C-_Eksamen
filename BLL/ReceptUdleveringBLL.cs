using DAL.Repository;
using DTO;

namespace BLL;

public class ReceptUdleveringBLL
{
    private readonly ReceptUdleveringRepository _repository;

    public ReceptUdleveringBLL(ReceptUdleveringRepository repository)
    {
        _repository = repository;
    }

    public ReceptUdleveringDTO? GetReceptUdlevering(Guid receptUdleveringId)
    {
        var receptUdlevering = _repository.GetReceptUdlevering(receptUdleveringId);
        if (receptUdlevering == null) return null;
        return Mapper.Map(receptUdlevering);
    }

    public List<ReceptUdleveringDTO> GetAllReceptUdleveringer()
    {
        return _repository.GetAllReceptUdleveringer().Select(Mapper.Map).ToList();
    }
}