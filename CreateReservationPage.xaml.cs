using MauiArcade_LazarDaria_MagureanPatricia;

namespace MauiArcade_LazarDaria_MagureanPatricia;

public partial class CreateReservationPage : ContentPage
{
    public CreateReservationPage()
    {
        InitializeComponent();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        ErrorLabel.IsVisible = false;

        
        if (ActivityPicker.SelectedItem == null)
        {
            ShowError("Please select an activity.");
            return;
        }

        if (!int.TryParse(DurationEntry.Text, out int duration) ||
            duration < 30 || duration > 120)
        {
            ShowError("Duration must be between 30 and 120 minutes.");
            return;
        }

        var reservation = new Reservation
        {
            ActivityName = ActivityPicker.SelectedItem.ToString(),
            Date = DatePicker.Date,
            StartTime = StartTimePicker.Time,
            DurationMinutes = duration
        };

        // save simulation
        await DisplayAlert(
            "Reservation Saved",
            $"Activity: {reservation.ActivityName}\n" +
            $"Date: {reservation.Date:d}\n" +
            $"Start: {reservation.StartTime}\n" +
            $"Duration: {reservation.DurationMinutes} minutes",
            "OK"
        );

        // Reset form
        ActivityPicker.SelectedItem = null;
        DurationEntry.Text = string.Empty;
    }

    private void ShowError(string message)
    {
        ErrorLabel.Text = message;
        ErrorLabel.IsVisible = true;
    }
}
