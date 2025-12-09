using Microsoft.AspNetCore.Mvc;

namespace ReceptSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceptSystemController: ControllerBase
{
    private readonly BLL.LægehusBLL _lægehusBll;
    private readonly BLL.ApotekBLL _apotekBll;
    private readonly BLL.ReceptBLL _receptBll;
    private readonly BLL.OrdinationBLL _ordinationBll;
    private readonly BLL.ReceptUdleveringBLL _receptUdleveringBll;

    public ReceptSystemController(BLL.LægehusBLL lægehusBll,  BLL.ApotekBLL apotekBll, BLL.ReceptBLL receptBll,  BLL.OrdinationBLL ordinationBll, BLL.ReceptUdleveringBLL receptUdleveringBll)
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
    public IActionResult GetLægehus(Guid ydernummer)
    {
        var lægehus = _lægehusBll.GetLægehus(ydernummer);
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
        return Ok(recept);
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
        return Ok(receptUdlevering);
    }
    
    
}