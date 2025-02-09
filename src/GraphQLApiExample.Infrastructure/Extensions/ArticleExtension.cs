using ArticleDomain = GraphQLApiExample.Domain.Entities.Article;
using ArticleDbo = GraphQLApiExample.Infrastructure.Entities.Article;

namespace GraphQLApiExample.Infrastructure.Extensions
{
    public static class ArticleExtension
    {
        public static ArticleDbo ToDbo(this ArticleDomain article)
        {
            return new ArticleDbo
            {
                Id = Guid.NewGuid(),
                UserId = article.UserId,
                Title = article.Title,
                Content = article.Content,
                CreationDate = DateTime.Now
            };
        }

        public static ArticleDomain ToDomain(this ArticleDbo article)
        {
            return new ArticleDomain
            {
                Id = article.Id,
                UserId = article.UserId,
                Author = new Domain.Entities.User
                {
                    Pseudo = article.User.Pseudo,
                    Mail = article.User.Mail
                },
                Title = article.Title,
                Content = article.Content,
                CreationDate = article.CreationDate
            };
        }
    }
}
