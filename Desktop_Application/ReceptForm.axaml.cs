using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DTO;

namespace Desktop_Application;

public partial class ReceptForm : Window
{
    private LægehusDTO _lægehus;
    private ObservableCollection<OrdinationDTO> _ordinationer = new();

    public ReceptForm(LægehusDTO lægehus)
    {
        InitializeComponent();
        _lægehus = lægehus;
        Lægehus.Text = _lægehus.ToString();
        Ordinationer.ItemsSource = _ordinationer;
    }


    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private async void OpretReceptBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var date = Cpr.Text.Substring(0, 6);
        Console.WriteLine(date);
        var validDate = DateTime.TryParseExact(date, "ddMMyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var dateParsed);
        Console.WriteLine(dateParsed.ToString());
        if (!validDate)
        {
            CprFejlBesked.Text = "*Ugyldigt Cpr";
            CprFejlBesked.IsVisible = true;
            return;
        }
        var recept = new ReceptDTO()
        {
            ReceptId = Guid.NewGuid(),
            PatientCpr = Cpr.Text,
            OprettelsesDato = DateTime.Now,
            Lukket = false,
            LægehusId = _lægehus.Ydernummer,
            Ordinationer = _ordinationer.ToList(),
            ReceptUdleveringer = new List<ReceptUdleveringDTO>()
        };

        HttpClient client = new HttpClient();

        var json = JsonSerializer.Serialize(recept);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(
            $"http://localhost:5027/api/ReceptSystems/recepter",
            content
        );

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Fejl i POST");
        }

        var mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

    private void TilføjOrdinationBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var ordinationWindow = new OpretOrdinationWindow();
        ordinationWindow.Tilføjet += HandleNewOrdination;
        ordinationWindow.Show();
    }

    private void HandleNewOrdination(object? sender, OrdinationDTO e)
    {
        _ordinationer.Add(e);
        Console.WriteLine(e);
        Console.WriteLine(_ordinationer.Count);
    }

    private void Cpr_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var tb = sender as TextBox;

        if (tb == null)
            return;

        string digitsOnly = new string(tb.Text.Where(char.IsDigit).ToArray());

        if (tb.Text != digitsOnly)
        {
            int caret = tb.CaretIndex;
            tb.Text = digitsOnly;
            tb.CaretIndex = Math.Min(caret, tb.Text.Length); // Behold cursorposition
        }


        if (Cpr.Text.Length == 10)
        {
            CprFejlBesked.IsVisible = false;
        }
        else
        {
            CprFejlBesked.Text = "*CPR skal være 10 cifre";
            CprFejlBesked.IsVisible = true;
        }

        OpretReceptBtn.IsEnabled = Cpr.Text.Length == 10 && _ordinationer.Count > 0;
    }


    private void Ordinationer_OnSizeChanged(object? sender, SizeChangedEventArgs e)
    {
        if (_ordinationer.Count == 0)
        {
            ListFejlBesked.IsVisible = true;
        }
        else if (_ordinationer.Count > 0)
        {
            ListFejlBesked.IsVisible = false;
        }

        OpretReceptBtn.IsEnabled = _ordinationer.Count > 0 && Cpr.Text.Length == 10;
    }
}