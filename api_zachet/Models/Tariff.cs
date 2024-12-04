using System;
using System.Collections.Generic;

namespace api_zachet.Models;

public partial class Tariff
{
    public int TariffId { get; set; }

    public decimal Price { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
