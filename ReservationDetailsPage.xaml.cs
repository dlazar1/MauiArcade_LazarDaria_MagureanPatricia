namespace MauiArcade_LazarDaria_MagureanPatricia;

public partial class ReservationDetailsPage : ContentPage
{
    private readonly Reservation _reservation;

    public ReservationDetailsPage(Reservation reservation)
    {
        InitializeComponent();
        _reservation = reservation;
        BindingContext = _reservation;

        var p = DataStore.Prices.FirstOrDefault(x => x.ActivityName == _reservation.ActivityName);
        var perHour = p?.PricePerHour ?? 0m;

        var hours = _reservation.DurationMinutes / 60m;
        var total = DataStore.CalculateTotal(_reservation.ActivityName, _reservation.DurationMinutes);

        PriceBreakdownLabel.Text = $"{perHour} lei / hour × {hours:0.##} hours";
        TotalLabel.Text = $"Total: {total} lei";
    }
}
