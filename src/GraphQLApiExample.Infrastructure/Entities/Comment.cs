using System;
using System.Collections.Generic;

namespace GraphQLApiExample.Infrastructure.Entities;

public partial class Comment
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ArticleId { get; set; }

    public byte[] Content { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public virtual Article Article { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
