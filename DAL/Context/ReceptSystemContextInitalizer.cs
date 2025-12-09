using DAL.Model;

namespace DAL.Context;

public class ReceptSystemContextInitalizer
{
    public static void Seed(ReceptSystemContext context)
    {

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        /*
         * public DbSet<Recept> Recepter {get;set;}
           public DbSet<Apotek> Apoteker { get; set; }
           public DbSet<Ordination> Ordinationer { get; set; }
           public DbSet<ReceptUdlevering> ReceptUdleveringer { get; set; }
         */
        if (!context.Lægehuse.Any())
        {
            context.Lægehuse.AddRange(
                new Lægehus(){Ydernummer = Guid.NewGuid(), Navn = "Viby Lægehus"},
                new Lægehus(){Ydernummer = Guid.NewGuid(), Navn = "Aarhus Lægehus"},
                new Lægehus(){Ydernummer = Guid.NewGuid(), Navn = "Højbjerg Lægehus"}
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
                        new Ordination(){AntalUdleveringer = 3, OrdinationId = Guid.NewGuid(), AntalForetagedeUdleveringer = 0, Lægemiddel = "2 tabletter 3 gange dagligt"}
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
                        new Ordination(){AntalUdleveringer = 3, OrdinationId = Guid.NewGuid(), AntalForetagedeUdleveringer = 0, Lægemiddel = "3 tabletter 2 gange dagligt"}
                    }
                },
                new Recept()
                {
                    LægehusYdernummer = allLægehuse[2].Ydernummer,
                    OprettelsesDato = DateTime.Now.AddDays(1),
                    Lukket = false,
                    ReceptUdleveringer = new List<ReceptUdlevering>(),
                    PatientCpr = "3050035643",
                    Ordinationer = new List<Ordination>()
                    {
                        new Ordination(){AntalUdleveringer = 3, OrdinationId = Guid.NewGuid(), AntalForetagedeUdleveringer = 0, Lægemiddel = "1 tabletter 5 gange dagligt"}
                    }
                }
                );
            context.SaveChanges();
        }
        
        
    }
}