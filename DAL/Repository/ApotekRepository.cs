using DAL.Context;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class ApotekRepository
{
    private readonly ReceptSystemContext _context;

    public ApotekRepository(ReceptSystemContext context)
    {
        _context = context;
    }

    public Apotek? GetApotek(Guid id)
    {
        return _context
            .Apoteker
            .Include(a => a.ReceptUdleveringer)
            .FirstOrDefault(a => a.ApotekId == id);

    }

    public List<Apotek> GetAllApoteker()
    {
        return _context
            .Apoteker
            .Include(a => a.ReceptUdleveringer)
            .ToList();
    }
}