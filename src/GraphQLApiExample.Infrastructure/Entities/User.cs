using System;
using System.Collections.Generic;

namespace GraphQLApiExample.Infrastructure.Entities;

public partial class UserDbo
{
    public Guid Id { get; set; }

    public string Pseudo { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public virtual ICollection<Article> Article { get; set; } = new List<Article>();

    public virtual ICollection<Comment> Comment { get; set; } = new List<Comment>();
}
