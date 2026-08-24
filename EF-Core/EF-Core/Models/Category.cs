using System;
using System.Collections.Generic;

namespace EF_Core1;

public partial class Category
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;
}
