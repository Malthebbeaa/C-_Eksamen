using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DTO;

namespace Desktop_Application;

public partial class OpretOrdinationWindow : Window
{
    public event EventHandler<OrdinationDTO>? Tilføjet;

    public OpretOrdinationWindow()
    {
        InitializeComponent();
    }

    private void TilføjOrdinationBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var ordination = new OrdinationDTO()
        {
            OrdinationId = Guid.NewGuid(),
            Lægemiddel = Lægemiddel.Text,
            Dosis = Dosis.Text,
            AntalUdleveringer = int.Parse(AntalUdleveringer.Text),
            AntalForetagneUdleveringer = 0
        };

        Tilføjet?.Invoke(this, ordination);
        this.Close();
    }

    private void Lægemiddel_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var lægemiddelUdfyldt = Lægemiddel.Text != null;
        var dosisUdfyldt = Dosis.Text != null;
        var antalUdfyldt = AntalUdleveringer.Text != null;

        TilføjOrdinationBtn.IsEnabled = lægemiddelUdfyldt && dosisUdfyldt && antalUdfyldt;
    }

    private void Dosis_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var lægemiddelUdfyldt = Lægemiddel.Text != null;
        var dosisUdfyldt = Dosis.Text != null;
        var antalUdfyldt = AntalUdleveringer.Text != null;

        TilføjOrdinationBtn.IsEnabled = lægemiddelUdfyldt && dosisUdfyldt && antalUdfyldt;
    }

    private void AntalUdleveringer_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        var lægemiddelUdfyldt = Lægemiddel.Text != null;
        var dosisUdfyldt = Dosis.Text != null;
        var antalUdfyldt = AntalUdleveringer.Text != null;

        TilføjOrdinationBtn.IsEnabled = lægemiddelUdfyldt && dosisUdfyldt && antalUdfyldt;
    }
}