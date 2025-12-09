using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using DTO;
namespace MVC_Application.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetRecepter(string cpr, Guid apotekId)
    {
        Console.WriteLine(cpr);
        var recepter = await GetRecepterByCpr(cpr);
        ViewBag.Apotek = await GetApotek(apotekId);
        ViewBag.Cpr = cpr;
        return View("ReceptSearch", recepter);
    }

    [HttpPost]
    public async Task<IActionResult> ForetagUdlevering(string cpr, Guid apotekId, Guid receptId, Guid ordinationId)
    {
        HttpClient client = new HttpClient();
        var response = await client.PostAsync(
            $"http://localhost:5027/api/Apoteks/recepter/{receptId}/ordinationer/{ordinationId}/apotek/{apotekId}",
            new StringContent("", Encoding.UTF8, "application/json")
        );
        
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Fejl i POST");
        }

        var recepter = await GetRecepterByCpr(cpr);
        var apotek = await GetApotek(apotekId);
        
        ViewBag.Apotek = apotek;
        var cprInput = cpr;
        //return View("ReceptSearch", recepter);
        return RedirectToAction("GetRecepter", new { cpr = cprInput, apotekId = apotek.ApotekId });
    }
    public IActionResult Index()
    {
        HttpClient client = new HttpClient();
        Task<string> response = client.GetStringAsync("http://localhost:5027/api/ReceptSystem/apoteker");
        
        string json = response.Result;

        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
        
        var apoteker = JsonSerializer.Deserialize<List<ApotekDTO>>(json, options);
        ViewBag.Apoteker = apoteker;
        return View("Index");
    }

    public async Task<IActionResult> ReceptSearch(Guid apotekId)
    {
        var apotek = await GetApotek(apotekId);
        ViewBag.Apotek = apotek;
        return View("ReceptSearch");
    }

    public async Task<ApotekDTO?> GetApotek(Guid apotekId)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync($"http://localhost:5027/api/ReceptSystem/apoteker/{apotekId}");
        
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        string json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        var apotek = JsonSerializer.Deserialize<ApotekDTO>(json, options);
        return apotek;
    }

    public async Task<List<ReceptDTO>> GetRecepterByCpr(string cpr)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync($"http://localhost:5027/api/Apoteks/recepter/{cpr}");
        
        if (!response.IsSuccessStatusCode)
        {
            return new List<ReceptDTO>();
        }
        
        string json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        var recepter = JsonSerializer.Deserialize<List<ReceptDTO>>(json, options);
        return recepter;
    }
}