using System;
using System.Collections.Generic;

namespace api_zachet.Models;

public partial class Sign
{
    public int SignId { get; set; }

    public int PersonId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Person PhoneNumberNavigation { get; set; } = null!;
}
