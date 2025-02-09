namespace GraphQLApiExample.Application.Features.Articles.Types.Inputs
{
    public class GetArticleInput
    {
        public Guid? Id { get; set; } = null;
        public Guid? UserId { get; set; } = null;
    }
}
