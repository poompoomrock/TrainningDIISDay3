using System;
using System.Collections.Generic;

namespace PersonApp.Shared.Entities;

public partial class Person
{
    public int PersonId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }
}
