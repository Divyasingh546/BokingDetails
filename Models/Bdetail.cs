using System;
using System.Collections.Generic;

namespace BookingDetails.Models;

public partial class Bdetail
{
    public int Bid { get; set; }

    public string Bname { get; set; } = null!;

    public string Blocation { get; set; } = null!;

    public DateTime BdateTime { get; set; }

    public int Benergy { get; set; }
}
