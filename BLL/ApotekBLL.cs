using DAL.Repository;
using DTO;

namespace BLL;

public class ApotekBLL
{
    private readonly ApotekRepository _repository;

    public ApotekBLL(ApotekRepository repository)
    {
        _repository = repository;
    }

    public ApotekDTO? GetApotek(Guid id)
    {
        var apotek = _repository.GetApotek(id);
        if (apotek == null) return null;
        return Mapper.Map(apotek);
    }

    public List<ApotekDTO> GetAllApoteker()
    {
        var apoteker = _repository.GetAllApoteker();
        
        return apoteker.Select(Mapper.Map).ToList();
    }
}