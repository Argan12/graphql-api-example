using GraphQLApiExample.Application.Features.Articles.Types.Inputs.Base;

namespace GraphQLApiExample.Application.Features.Articles.Types.Inputs
{
    public class UpdateArticleInput : BaseArticleInput
    {
        public Guid Id { get; set; }
    }
}
