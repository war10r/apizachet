using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_zachet.Models;

public partial class Person
{
    [Key]
    public int PersonId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Email { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Sign> SignPeople { get; set; } = new List<Sign>();

    public virtual ICollection<Sign> SignPhoneNumberNavigations { get; set; } = new List<Sign>();
}
