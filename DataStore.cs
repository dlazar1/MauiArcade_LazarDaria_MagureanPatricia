using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiArcade_LazarDaria_MagureanPatricia;

public static class DataStore
{
    public static List<Price> Prices { get; } = new()
    {
        new Price { ActivityName = "Bowling", PricePerHour = 30m },
        new Price { ActivityName = "Billiard", PricePerHour = 20m },
        new Price { ActivityName = "Table Tennis", PricePerHour = 15m },
        new Price { ActivityName = "Air Hockey", PricePerHour = 25m },
        new Price { ActivityName = "Dance Machine", PricePerHour = 18m },
        new Price { ActivityName = "Indoor Paintball", PricePerHour = 60m },
    };

    public static List<Reservation> Reservations { get; } = new();

    public static decimal CalculateTotal(string activityName, int minutes)
    {
        var price = Prices.FirstOrDefault(p => p.ActivityName == activityName);
        if (price == null) return 0m;

        decimal hours = minutes / 60m;
        return Math.Round(hours * price.PricePerHour, 2);
    }
}
