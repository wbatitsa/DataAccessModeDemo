using System;
using System.Collections.Generic;

namespace EFCoreDatabaseFirstDemo.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
