using System;
using System.Collections.Generic;

namespace EF_Core1;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int BlogId { get; set; }

    public virtual Blog Blog { get; set; } = null!;
}
