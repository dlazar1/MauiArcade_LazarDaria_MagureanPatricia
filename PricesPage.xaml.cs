namespace MauiArcade_LazarDaria_MagureanPatricia;

public partial class PricesPage : ContentPage
{
    public PricesPage()
    {
        InitializeComponent();
        PricesCollection.ItemsSource = DataStore.Prices;

    }
}

public class PriceView
{
    public string ActivityName { get; set; }
    public string PriceText { get; set; }
}
