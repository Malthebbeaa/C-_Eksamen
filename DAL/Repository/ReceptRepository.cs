using DAL.Context;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class ReceptRepository
{
    private readonly ReceptSystemContext _context;

    public ReceptRepository(ReceptSystemContext context)
    {
        _context = context;
    }

    public Recept? GetRecept(Guid id)
    {
        return _context
            .Recepter
            .Include(r => r.Ordinationer)
            .Include(r => r.ReceptUdleveringer)
            .Include(r => r.Lægehus)
            .FirstOrDefault(r => r.ReceptId == id); 
    }

    public List<Recept> GetAllRecepts()
    {
        return _context.Recepter
            .Include(r => r.Ordinationer)
            .Include(r => r.ReceptUdleveringer)
            .Include(r => r.Lægehus)
            .ToList();
    }

    public List<Recept> GetReceptByCpr(string cpr)
    {
        return _context
            .Recepter
            .Include(r => r.Ordinationer)
            .Include(r => r.ReceptUdleveringer)
            .Include(r => r.Lægehus)
            .Where(r => r.PatientCpr == cpr && r.Lukket == false)
            .ToList();
    }

    public bool Update(Recept recept)
    {
        _context.Recepter.Update(recept);
        _context.SaveChanges();
        return true;
    }
}