using GraphQLApiExample.Application.Common.Exceptions;
using GraphQLApiExample.Application.Common.Interfaces;
using GraphQLApiExample.Application.Features.Articles.Types.Inputs;
using GraphQLApiExample.Application.Features.Articles.Types.Mappings;
using GraphQLApiExample.Application.Features.Articles.Types.Outputs;

namespace GraphQLApiExample.Application.Features.Articles.Handlers.Mutations
{
    public class ArticleMutationHandler(IArticleRepository articleRepository, IUserRepository userRepository)
    {
        private readonly IArticleRepository _articleRepository = articleRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<ArticleDto> SaveArticle(CreateArticleInput input)
        {
            _ = await _userRepository.GetUserById(input.UserId) ?? throw new NotFoundException(Constants.ERR_USER_NOT_FOUND);
            var article = await _articleRepository.Save(input.CreateArticleInputToDomain());

            return article.ToDto();
        }

        public async Task<ArticleDto> UpdateArticle(UpdateArticleInput input)
        {
            _ = await _userRepository.GetUserById(input.UserId) ?? throw new NotFoundException(Constants.ERR_USER_NOT_FOUND);
            var article = await _articleRepository.FindById(input.Id) ?? throw new NotFoundException(Constants.ERR_ARTICLE_NOT_FOUND);

            if (article.Id != input.UserId)
            {
                throw new UnauthorizedException(Constants.ERR_UPDATE_ARTICLE_UNAUTHORIZED);
            }

            var updatedArticle = await _articleRepository.Update(input.UpdateArticleInputToDomain());
            
            return updatedArticle.ToDto();
        }

        public async Task DeleteArticle(DeleteArticleInput input)
        {
            _ = await _userRepository.GetUserById(input.UserId) ?? throw new NotFoundException(Constants.ERR_USER_NOT_FOUND);
            var article = await _articleRepository.FindById(input.Id) ?? throw new NotFoundException(Constants.ERR_ARTICLE_NOT_FOUND);

            if (article.UserId != input.UserId)
            {
                throw new UnauthorizedException(Constants.ERR_UPDATE_ARTICLE_UNAUTHORIZED);
            }

            await _articleRepository.Delete(input.Id);
        }
    }
}
