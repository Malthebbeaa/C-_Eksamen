using DAL.Repository;
using DTO;

namespace BLL;

public class OrdinationBLL
{
    private readonly OrdinationRepository _repository;

    public OrdinationBLL(OrdinationRepository repository)
    {
        _repository = repository;
    }

    public OrdinationDTO GetOrdination(Guid id)
    {
        var ordination = _repository.GetOrdination(id);
        if (ordination == null) return null;
        
        return Mapper.Map(ordination);
    }

    public List<OrdinationDTO> GetAllOrdinationer()
    {
        return _repository.GetAllOrdinationer().Select(Mapper.Map).ToList();
    }
}