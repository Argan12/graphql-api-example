using FluentValidation;
using GraphQLApiExample.Application.Features.Articles.Types.Inputs.Base;

namespace GraphQLApiExample.Application.Features.User.Types.Validators
{
    public class ArticleInputValidator : AbstractValidator<BaseArticleInput>
    {
        public ArticleInputValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required");
        }
    }
}
