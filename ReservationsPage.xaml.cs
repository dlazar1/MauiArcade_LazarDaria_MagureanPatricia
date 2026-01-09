using System.Linq;

namespace MauiArcade_LazarDaria_MagureanPatricia;

public partial class ReservationsPage : ContentPage
{
    public ReservationsPage()
    {
        InitializeComponent();
        RefreshList();
    }

    private void RefreshList()
    {
        foreach (var r in DataStore.Reservations)
            r.TotalPrice = DataStore.CalculateTotal(r.ActivityName, r.DurationMinutes);

        ReservationsCollection.ItemsSource = null;
        ReservationsCollection.ItemsSource = DataStore.Reservations;
    }

    private async void OnReservationSelected(object sender, SelectionChangedEventArgs e)
    {
        var selected = e.CurrentSelection?.FirstOrDefault() as Reservation;
        if (selected == null) return;

        ReservationsCollection.SelectedItem = null;

        await Navigation.PushAsync(new ReservationDetailsPage(selected));
    }

    private void OnAddSampleClicked(object sender, EventArgs e)
    {
        DataStore.Reservations.Add(new Reservation
        {
            ActivityName = "Bowling",
            Date = DateTime.Today.AddDays(1),
            StartTime = new TimeSpan(18, 0, 0),
            DurationMinutes = 90
        });

        RefreshList();
    }
}
