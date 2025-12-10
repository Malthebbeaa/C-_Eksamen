using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class ReceptSystemContextInitalizer
{
    public static void Seed(ReceptSystemContext context)
    {

        context.Database.EnsureDeleted();
        context.Database.Migrate();
        if (!context.Lægehuse.Any())
        {
            context.Lægehuse.AddRange(
                new Lægehus(){Ydernummer = 100001, Navn = "Viby Lægehus"},
                new Lægehus(){Ydernummer = 100002, Navn = "Aarhus Lægehus"},
                new Lægehus(){Ydernummer = 100003, Navn = "Højbjerg Lægehus"},
                new Lægehus(){Ydernummer = 100004, Navn = "Risskov Lægehus"}
                );
            
            context.SaveChanges();
        }

        if (!context.Apoteker.Any())
        {
            context.Apoteker.AddRange(
                new Apotek(){ApotekId = Guid.NewGuid(), Navn = "Viby Apotek"},
                new Apotek(){ApotekId = Guid.NewGuid(), Navn = "Aarhus Apotek"},
                new Apotek(){ApotekId = Guid.NewGuid(), Navn = "Bruuns Apotek"},
                new Apotek(){ApotekId = Guid.NewGuid(), Navn = "Højbjerg Apotek"}
                );
            context.SaveChanges();
        }
        
        var allLægehuse = context.Lægehuse.ToList();

        if (!context.Recepter.Any())
        {
            context.Recepter.AddRange(
                new Recept()
                {
                    LægehusYdernummer = allLægehuse[0].Ydernummer,
                    OprettelsesDato = DateTime.Now,
                    Lukket = false,
                    ReceptUdleveringer = new List<ReceptUdlevering>(),
                    PatientCpr = "2010035647",
                    Ordinationer = new List<Ordination>()
                    {
                        new Ordination(){AntalUdleveringer = 3, OrdinationId = Guid.NewGuid(), AntalForetagneUdleveringer = 0, Lægemiddel = "Panodil",Dosis = "2 tabletter 3 gange dagligt"},
                        new Ordination(){AntalUdleveringer = 5, OrdinationId = Guid.NewGuid(), AntalForetagneUdleveringer = 0, Lægemiddel = "Penicillin",Dosis = "3 tabletter 1 gange dagligt"}

                    }
                },
                new Recept()
                {
                    LægehusYdernummer = allLægehuse[0].Ydernummer,
                    OprettelsesDato = DateTime.Now.AddDays(4),
                    Lukket = false,
                    ReceptUdleveringer = new List<ReceptUdlevering>(),
                    PatientCpr = "2010035647",
                    Ordinationer = new List<Ordination>()
                    {
                        new Ordination(){AntalUdleveringer = 3, OrdinationId = Guid.NewGuid(), AntalForetagneUdleveringer = 0, Lægemiddel = "Panodil", Dosis = "3 tabletter 2 gange dagligt"}
                    }
                },
                new Recept()
                {
                    LægehusYdernummer = allLægehuse[2].Ydernummer,
                    OprettelsesDato = DateTime.Now.AddYears(-2).AddDays(-4),
                    Lukket = false,
                    ReceptUdleveringer = new List<ReceptUdlevering>(),
                    PatientCpr = "3005035643",
                    Ordinationer = new List<Ordination>()
                    {
                        new Ordination(){AntalUdleveringer = 3, OrdinationId = Guid.NewGuid(), AntalForetagneUdleveringer = 0, Lægemiddel = "Pinex",Dosis = "1 tabletter 5 gange dagligt"}
                    }
                }
                );
            context.SaveChanges();
        }
        
        
    }
}