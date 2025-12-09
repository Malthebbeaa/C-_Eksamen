using DAL.Context;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class LægehusRepository
{
    private readonly ReceptSystemContext _context;

    public LægehusRepository(ReceptSystemContext context)
    {
        _context = context;
    }

    public Lægehus? GetLægehus(Guid ydernummer)
    {
        return _context
            .Lægehuse
            .Include(l => l.Recepter)
            .ThenInclude(l => l.Ordinationer)
            .FirstOrDefault(l => l.Ydernummer == ydernummer);
    }

    public List<Lægehus> GetAllLægehuse()
    {
        return _context
            .Lægehuse
            .Include(l => l.Recepter)
            .ThenInclude(l => l.Ordinationer)
            .ToList();
    }
}