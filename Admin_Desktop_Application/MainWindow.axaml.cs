using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Admin_Desktop_Application;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void LukUdløbneBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        HttpClient client = new HttpClient();
        var response = await client.PostAsync(
            $"http://localhost:5027/api/admins/recepter/lukUdløbne",
            new StringContent("", Encoding.UTF8, "application/json")
        );
        
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Fejl i POST");
        }
        
        string json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var lukkeResponse = JsonSerializer.Deserialize<LukkeResponse>(json, options);
        
        AntalLukkede.Text = $"Der blev lukket: {lukkeResponse.AntalLukket} recept(er)";
        AntalLukkede.IsVisible = true;
    }
}
public class LukkeResponse()
{
    public int AntalLukket {get;set;}
}