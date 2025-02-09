namespace GraphQLApiExample.Application.Features.Articles.Types.Inputs.Base
{
    public abstract class BaseArticleInput
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
