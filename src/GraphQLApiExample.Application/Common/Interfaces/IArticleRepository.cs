using GraphQLApiExample.Domain.Entities;

namespace GraphQLApiExample.Application.Common.Interfaces
{
    public interface IArticleRepository
    {
        Task<Article?> FindById(Guid id);

        Task<List<Article>> FindAllArticles();

        Task<Article> Save(Article article);

        Task<Article> Update(Article article);

        Task Delete(Guid id);
    }
}
