using System;
using System.Collections.Generic;

namespace EF_Core1;

public partial class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
