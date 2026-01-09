using Plugin.LocalNotification;


namespace MauiArcade_LazarDaria_MagureanPatricia;

public partial class CreateReservationPage : ContentPage
{
    public CreateReservationPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await LocalNotificationCenter.Current.RequestNotificationPermission();
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

        DataStore.Reservations.Add(reservation);

        var total = DataStore.CalculateTotal(
            reservation.ActivityName,
            reservation.DurationMinutes
        );

        var notification = new NotificationRequest
        {
            NotificationId = new Random().Next(1000, 9999),
            Title = "Reservation Reminder",
            Description =
                $"You reserved {reservation.ActivityName}\n" +
                $"Duration: {reservation.DurationMinutes} min\n" +
                $"Total: {total} RON",
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(30)
            }
        };

        await LocalNotificationCenter.Current.Show(notification);

        await DisplayAlert(
            "Reservation Saved",
            $"Activity: {reservation.ActivityName}\n" +
            $"Total price: {total} RON\n\n" +
            $" You will be notified in 30 seconds.",
            "OK"
        );

        ActivityPicker.SelectedItem = null;
        DurationEntry.Text = string.Empty;
    }


    private void ShowError(string message)
    {
        ErrorLabel.Text = message;
        ErrorLabel.IsVisible = true;
    }

}
