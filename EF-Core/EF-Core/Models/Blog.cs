using System;
using System.Collections.Generic;

namespace EF_Core1;

public partial class Blog
{
    public int Id { get; set; }

    public string Url { get; set; } = null!;

    public virtual ICollection<BlogImage> BlogImages { get; set; } = new List<BlogImage>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
