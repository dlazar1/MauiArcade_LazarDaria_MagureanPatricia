using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MauiArcade_LazarDaria_MagureanPatricia;

public class Reservation
{
    [Required]
    public string ActivityName { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Range(30, 120)]
    public int DurationMinutes { get; set; }
}
