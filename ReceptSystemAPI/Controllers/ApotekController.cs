using BLL;
using Microsoft.AspNetCore.Mvc;

namespace ReceptSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class ApotekController: ControllerBase
{
    private readonly ReceptBLL _receptBll;
    private readonly OrdinationBLL _ordinationBll;

    public ApotekController(ReceptBLL receptBll, OrdinationBLL ordinationBll)
    {
        _receptBll = receptBll;
        _ordinationBll = ordinationBll;
    }

    [HttpGet("recepter/{cpr}")]
    public IActionResult GetRecepterByCpr(string cpr)
    {
        var recepter = _receptBll.GetRecepterByCpr(cpr); 
        return Ok(recepter);
    }

    [HttpPost("recepter/{receptId}/ordinationer/{id}/apotek/{apotekId}")]
    public IActionResult ForetagReceptUdlevering(Guid receptId, Guid id, Guid apotekId)
    {
        var foretaget = _receptBll.ForetagReceptUdlevering(receptId, id, apotekId);
        if (foretaget == false) return NotFound();
        return Ok("Foretaget udlevering");
    }
}