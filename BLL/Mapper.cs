using DAL.Model;
using DTO;

namespace BLL;

public class Mapper
{
    public static LægehusDTO Map(Lægehus lægehus)
    {
        return new LægehusDTO()
        {
            Ydernummer = lægehus.Ydernummer,
            Navn = lægehus.Navn,
            Recepter = lægehus.Recepter.Select(r => Map(r)).ToList()
        };
    }
    
    public static Lægehus Map(LægehusDTO lægehusDto)
    {
        return new Lægehus()
        {
            Ydernummer = lægehusDto.Ydernummer,
            Navn = lægehusDto.Navn,
            Recepter = lægehusDto.Recepter.Select(r => Map(r)).ToList()
        };
    }

    public static ApotekDTO Map(Apotek apotek)
    {
        return new ApotekDTO()
        {
            ApotekId = apotek.ApotekId,
            Navn = apotek.Navn,
            ReceptUdlevering = apotek.ReceptUdleveringer.Select(r => Map(r)).ToList()
        };
    }

    public static Apotek Map(ApotekDTO apotekDto)
    {
        return new Apotek()
        {
            ApotekId = apotekDto.ApotekId,
            Navn = apotekDto.Navn,
            ReceptUdleveringer = apotekDto.ReceptUdlevering.Select(r => Map(r)).ToList()
        };
    }

    public static ReceptDTO Map(Recept recept)
    {
        return new ReceptDTO()
        {
            ReceptId = recept.ReceptId,
            PatientCpr = recept.PatientCpr,
            OprettelsesDato = recept.OprettelsesDato,
            Lukket = recept.Lukket,
            LægehusId = recept.LægehusYdernummer,
            Ordinationer = recept.Ordinationer.Select(o => Map(o)).ToList(),
            ReceptUdleveringer = recept.ReceptUdleveringer.Select(r => Map(r)).ToList()
        };
    }
    
    public static Recept Map(ReceptDTO receptDto)
    {
        return new Recept()
        {
            ReceptId = receptDto.ReceptId,
            PatientCpr = receptDto.PatientCpr,
            OprettelsesDato = receptDto.OprettelsesDato,
            Lukket = receptDto.Lukket,
            LægehusYdernummer = receptDto.LægehusId,
            Ordinationer = receptDto.Ordinationer.Select(o => Map(o)).ToList(),
            ReceptUdleveringer = receptDto.ReceptUdleveringer.Select(r => Map(r)).ToList()
        };
    }
    
    public static OrdinationDTO Map(Ordination ordination)
    {
        return new OrdinationDTO()
        {
            OrdinationId = ordination.OrdinationId,
            Lægemiddel = ordination.Lægemiddel,
            AntalUdleveringer = ordination.AntalUdleveringer,
            AntalForetagedeUdleveringer = ordination.AntalForetagedeUdleveringer
        };
    }
    public static Ordination Map(OrdinationDTO ordinationDto)
    {
        return new Ordination()
        {
            OrdinationId = ordinationDto.OrdinationId,
            Lægemiddel = ordinationDto.Lægemiddel,
            AntalUdleveringer = ordinationDto.AntalUdleveringer,
            AntalForetagedeUdleveringer = ordinationDto.AntalForetagedeUdleveringer
        };
    }

    public static ReceptUdleveringDTO Map(ReceptUdlevering receptUdlevering)
    {
        return new ReceptUdleveringDTO()
        {
            ReceptUdleveringId = receptUdlevering.ReceptUdleveringId,
            ApotekId = receptUdlevering.ApotekId,
            ReceptId = receptUdlevering.ReceptId,
            UdleveringsDato = receptUdlevering.UdleveringsDato
        };
    }

    public static ReceptUdlevering Map(ReceptUdleveringDTO receptUdleveringDto)
    {
        return new ReceptUdlevering()
        {
            ReceptId = receptUdleveringDto.ReceptId,
            ApotekId = receptUdleveringDto.ApotekId,
            ReceptUdleveringId = receptUdleveringDto.ReceptUdleveringId,
            UdleveringsDato = receptUdleveringDto.UdleveringsDato
        };
    }
    
}