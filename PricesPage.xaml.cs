namespace MauiArcade_LazarDaria_MagureanPatricia;

public partial class PricesPage : ContentPage
{
    public PricesPage()
    {
        InitializeComponent();

        PricesCollection.ItemsSource = new List<PriceView>
        {
            new PriceView { ActivityName = "Bowling", PriceText = "30 lei / hour" },
            new PriceView { ActivityName = "Billiard", PriceText = "20 lei / hour" },
            new PriceView { ActivityName = "Table Tennis", PriceText = "15 lei / hour" },
            new PriceView { ActivityName = "Air Hockey", PriceText = "25 lei / hour" }
        };
    }
}

public class PriceView
{
    public string ActivityName { get; set; }
    public string PriceText { get; set; }
}
