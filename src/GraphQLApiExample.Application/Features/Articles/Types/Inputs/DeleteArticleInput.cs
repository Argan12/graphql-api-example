namespace GraphQLApiExample.Application.Features.Articles.Types.Inputs
{
    public class DeleteArticleInput
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
