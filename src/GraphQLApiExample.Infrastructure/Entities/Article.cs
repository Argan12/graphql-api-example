using System;
using System.Collections.Generic;

namespace GraphQLApiExample.Infrastructure.Entities;

public partial class Article
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public virtual ICollection<Comment> Comment { get; set; } = new List<Comment>();

    public virtual UserDbo User { get; set; } = null!;
}
