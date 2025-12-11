using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using DTO;
namespace MVC_Application.Controllers;

public class HomeController : Controller
{
    public HomeController() { }

    [HttpGet]
    public async Task<IActionResult> GetRecepter(string cpr, Guid apotekId)
    {
        var recepter = await GetRecepterByCpr(cpr);
        var apotek = await GetApotek(apotekId);

        if (TempData.ContainsKey("LukketReceptMessage"))
        {
            ViewBag.LukketReceptMessage = TempData["LukketReceptMessage"];
            TempData.Remove("LukketReceptMessage");
        }
        
        ViewBag.Apotek = apotek;
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
        
        var updatedRecept = await GetReceptById(receptId);
        if (updatedRecept != null && updatedRecept.Lukket)
        {
            TempData["LukketReceptMessage"] = $"Recept({receptId}) er lukket";
        } 

        var apotek = await GetApotek(apotekId);
        
        ViewBag.Apotek = apotek;
        var cprInput = cpr;
        
        return RedirectToAction("GetRecepter", new { cpr = cprInput, apotekId = apotek.ApotekId });
    }

    private async Task<ReceptDTO?> GetReceptById(Guid receptId)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(
            $"http://localhost:5027/api/ReceptSystems/recepter/{receptId}");

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        string json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        var recept = JsonSerializer.Deserialize<ReceptDTO>(json, options);
        return recept;
    }
    
    public async Task<IActionResult> Index()
    {
        var apoteker = new List<ApotekDTO>();
        
        HttpClient client = new HttpClient();
        var response = await client.GetAsync("http://localhost:5027/api/ReceptSystems/apoteker");
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Fejl i GET");
            ViewBag.Apoteker = apoteker;
        }
        
        string json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
        
        apoteker = JsonSerializer.Deserialize<List<ApotekDTO>>(json, options);
        //ViewBag.Apoteker = apoteker;
        return View("Index",  apoteker);
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
        var response = await client.GetAsync($"http://localhost:5027/api/ReceptSystems/apoteker/{apotekId}");
        
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