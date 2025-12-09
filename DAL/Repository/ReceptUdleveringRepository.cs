using DAL.Context;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class ReceptUdleveringRepository
{
    private readonly ReceptSystemContext _context;

    public ReceptUdleveringRepository(ReceptSystemContext context)
    {
        _context = context;
    }

    public ReceptUdlevering? GetReceptUdlevering(Guid receptUdleveringId)
    {
        return _context
            .ReceptUdleveringer
            .Include(ru => ru.Apotek)
            .Include(ru => ru.Recept)
            .FirstOrDefault(ru => ru.ReceptUdleveringId == receptUdleveringId);
    }

    public List<ReceptUdlevering> GetAllReceptUdleveringer()
    {
        return _context.ReceptUdleveringer.ToList();
    }

    public ReceptUdlevering CreateReceptUdlevering(ReceptUdlevering receptUdlevering)
    {
        _context.ReceptUdleveringer.Add(receptUdlevering);
        _context.SaveChanges();
        return receptUdlevering;
    }
}