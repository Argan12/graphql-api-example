namespace GraphQLApiExample.Domain.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User Author { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreationDate { get; set; }
    }
}
