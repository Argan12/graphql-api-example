using GraphQLApiExample.Application.Common.Interfaces;
using GraphQLApiExample.Application.Features.Articles.Types.Inputs;
using GraphQLApiExample.Application.Features.Articles.Types.Mappings;
using GraphQLApiExample.Application.Features.Articles.Types.Outputs;
using GraphQLApiExample.Domain.Entities;

namespace GraphQLApiExample.Application.Features.Articles.Handlers.Queries
{
    public class ArticleQueryHandler(IArticleRepository articleRepository)
    {
        private readonly IArticleRepository _articleRepository = articleRepository;

        public async Task<List<ArticleDto>> GetAllArticles(GetArticleInput input)
        {
            var articles = await _articleRepository.FindAllArticles();
            var filteredArticles = new List<Article>();

            if (input.UserId.HasValue)
            {
                filteredArticles = articles.Where(x => x.UserId == input.UserId).ToList();
            }

            if (input.Id.HasValue)
            {
                filteredArticles = articles.Where(x => x.Id == input.Id).ToList();
            }

            return filteredArticles.FromListToDto();
        }
    }
}
