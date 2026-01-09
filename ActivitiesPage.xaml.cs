namespace MauiArcade_LazarDaria_MagureanPatricia;



public partial class ActivitiesPage : ContentPage
{
    public ActivitiesPage()
    {
        InitializeComponent();

        ActivitiesCollection.ItemsSource = new List<Activity>
        {
            new Activity { Name = "Bowling" },
            new Activity { Name = "Billiard" },
            new Activity { Name = "Ping-Pong" },
            new Activity { Name = "Air Hockey" },
            new Activity { Name = "Dance Machine" }
        };
    }
}
