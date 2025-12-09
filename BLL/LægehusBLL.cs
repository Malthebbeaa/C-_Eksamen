using DAL.Model;
using DAL.Repository;
using DTO;

namespace BLL;

public class LægehusBLL
{
    private readonly LægehusRepository _repository;

    public LægehusBLL(LægehusRepository repository)
    {
        _repository = repository;
    }

    public LægehusDTO? GetLægehus(Guid lægehusYdernummer)
    {
        var lægehus = _repository.GetLægehus(lægehusYdernummer);
        if (lægehus == null) return null;
        
        return Mapper.Map(lægehus);
    }

    public List<LægehusDTO> GetAllLægehuse()
    {
        var lægehuse = _repository.GetAllLægehuse();
        
        return lægehuse.Select(Mapper.Map).ToList();
    }
}