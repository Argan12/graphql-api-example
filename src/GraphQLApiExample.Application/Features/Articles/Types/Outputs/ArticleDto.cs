using GraphQLApiExample.Application.Features.User.Types.Outputs;

namespace GraphQLApiExample.Application.Features.Articles.Types.Outputs
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public UserDto Author { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreationDate { get; set; }
    }
}
