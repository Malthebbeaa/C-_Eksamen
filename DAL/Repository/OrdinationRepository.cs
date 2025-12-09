using DAL.Context;
using DAL.Model;

namespace DAL.Repository;

public class OrdinationRepository
{
    private readonly ReceptSystemContext _context;

    public OrdinationRepository(ReceptSystemContext context)
    {
        _context = context;
    }

    public Ordination? GetOrdination(Guid id)
    {
        return _context.Ordinationer.FirstOrDefault(o => o.OrdinationId == id);
    }

    public List<Ordination> GetAllOrdinationer()
    {
        return _context.Ordinationer.ToList();
    }
}