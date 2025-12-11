using Admin_Desktop_Application;
using BLL;
using Microsoft.AspNetCore.Mvc;

namespace ReceptSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class AdminController: ControllerBase
{
    private readonly ReceptBLL _receptBll;

    public AdminController(ReceptBLL receptBll)
    {
        _receptBll = receptBll;
    }
    
    [HttpPost("recepter/lukUdløbne")]
    public IActionResult LukAlleUdløbenRecepter()
    {
        var antalLukkedeRecepter = _receptBll.LukAlleUdløbneRecepter();
        var response = new LukkeResponse()
        {
            AntalLukket = antalLukkedeRecepter,
        };
        
        return Ok(response);
    }
}
