using DTO;
using Microsoft.AspNetCore.Mvc;

namespace ReceptSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ReceptSystemController : ControllerBase
{
    private readonly BLL.LægehusBLL _lægehusBll;
    private readonly BLL.ApotekBLL _apotekBll;
    private readonly BLL.ReceptBLL _receptBll;
    private readonly BLL.OrdinationBLL _ordinationBll;
    private readonly BLL.ReceptUdleveringBLL _receptUdleveringBll;

    public ReceptSystemController(BLL.LægehusBLL lægehusBll, BLL.ApotekBLL apotekBll, BLL.ReceptBLL receptBll,
        BLL.OrdinationBLL ordinationBll, BLL.ReceptUdleveringBLL receptUdleveringBll)
    {
        _lægehusBll = lægehusBll;
        _apotekBll = apotekBll;
        _receptBll = receptBll;
        _ordinationBll = ordinationBll;
        _receptUdleveringBll = receptUdleveringBll;
    }

    [HttpGet("laegehuse")]
    public IActionResult GetAllLægehuse()
    {
        var lægehuse = _lægehusBll.GetAllLægehuse();
        return Ok(lægehuse);
    }

    [HttpGet("laegehuse/{ydernummer}")]
    public IActionResult GetLægehus(int ydernummer)
    {
        var lægehus = _lægehusBll.GetLægehus(ydernummer);
        if (lægehus == null)
        {
            return NotFound($"Intet lægehus med dette ydernummer:{ydernummer}");
        }

        return Ok(lægehus);
    }

    [HttpGet("apoteker")]
    public IActionResult GetAllApoteker()
    {
        var apoteker = _apotekBll.GetAllApoteker();
        return Ok(apoteker);
    }

    [HttpGet("apoteker/{id}")]
    public IActionResult GetApotek(Guid id)
    {
        var apotek = _apotekBll.GetApotek(id);
        if (apotek == null)
        {
            return NotFound($"Intet apotek med dette id:{id}");
        }

        return Ok(apotek);
    }

    [HttpGet("recepter")]
    public IActionResult GetAllRecepter()
    {
        var recepter = _receptBll.GetAllRecepter();
        return Ok(recepter);
    }

    [HttpGet("recepter/{id}")]
    public IActionResult GetRecept(Guid id)
    {
        var recept = _receptBll.GetRecept(id);
        if (recept == null)
        {
            return NotFound($"Ingen recept med dette id:{id}");
        }

        return Ok(recept);
    }

    [HttpPost("recepter")]
    public IActionResult CreateRecept([FromBody] ReceptDTO recept)
    {
        var cpr = recept.PatientCpr;
        var kunTal = cpr.ToList().TrueForAll(char.IsDigit);
        var korrektLængde = cpr.Length == 10;

        if (!kunTal && !korrektLængde)
        {
            return BadRequest("Forkert format på Cpr");
        }
        
        var newRecept = _receptBll.CreateRecept(recept);
        return Ok(newRecept);
    }

    [HttpGet("ordinationer")]
    public IActionResult GetAllOrdinationer()
    {
        var ordinationer = _ordinationBll.GetAllOrdinationer();
        return Ok(ordinationer);
    }

    [HttpGet("ordinationer/{id}")]
    public IActionResult GetOrdination(Guid id)
    {
        var ordination = _ordinationBll.GetOrdination(id);
        if (ordination == null)
        {
            return NotFound($"Ingen ordination med dette id:{id}");
        }

        return Ok(ordination);
    }

    [HttpGet("receptUdleveringer")]
    public IActionResult GetAllReceptUdleveringer()
    {
        var receptUdleveringer = _receptUdleveringBll.GetAllReceptUdleveringer();
        return Ok(receptUdleveringer);
    }

    [HttpGet("receptUdleveringer/{id}")]
    public IActionResult GetReceptUdlevering(Guid id)
    {
        var receptUdlevering = _receptUdleveringBll.GetReceptUdlevering(id);
        if (receptUdlevering == null)
        {
            return NotFound($"Ingen recept med dette id:{id}");
        }
        
        return Ok(receptUdlevering);
    }
}