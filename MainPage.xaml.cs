namespace MauiArcade_LazarDaria_MagureanPatricia;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnActivitiesClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Info", "Activities page coming soon", "OK");
    }

    private async void OnPricesClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Info", "Prices page coming soon", "OK");
    }

    private async void OnCreateReservationClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Info", "Create Reservation page coming soon 🕹️", "OK");
    }

}
