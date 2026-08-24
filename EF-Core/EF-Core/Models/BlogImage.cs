using System;
using System.Collections.Generic;

namespace EF_Core1;

public partial class BlogImage
{
    public int Id { get; set; }

    public string Image { get; set; } = null!;

    public string Caption { get; set; } = null!;

    public int BlogForeignKey { get; set; }

    public int BlogId { get; set; }

    public virtual Blog Blog { get; set; } = null!;
}
