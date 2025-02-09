using GraphQLApiExample.Application.Features.Articles.Types.Inputs;
using GraphQLApiExample.Application.Features.Articles.Types.Outputs;
using GraphQLApiExample.Application.Features.User.Types.Outputs;
using GraphQLApiExample.Domain.Entities;
using UserDomain = GraphQLApiExample.Domain.Entities.User;

namespace GraphQLApiExample.Application.Features.Articles.Types.Mappings
{
    public static class ArticleMapping
    {
        public static Article CreateArticleInputToDomain(this CreateArticleInput input)
        {
            return new Article
            {
                UserId = input.UserId,
                Title = input.Title,
                Content = input.Content
            };
        }

        public static Article UpdateArticleInputToDomain(this UpdateArticleInput input)
        {
            return new Article
            {
                Id = input.Id,
                UserId = input.UserId,
                Title = input.Title,
                Content = input.Content
            };
        }

        public static ArticleDto ToDto(this Article article)
        {
            return new ArticleDto
            {
                Id = article.Id,
                Author = new UserDto
                {
                    Id = article.Author.Id,
                    Pseudo = article.Author.Pseudo,
                    Mail = article.Author.Mail,
                    RegistrationDate = article.Author.RegistrationDate
                },
                Title = article.Title,
                Content = article.Content,
                CreationDate = article.CreationDate
            };
        }

        public static List<ArticleDto> FromListToDto(this List<Article> articles)
        {
            return articles.Select(item => new ArticleDto
            {
                Id = item.Id,
                Author = new UserDto
                {
                    Id = item.Author.Id,
                    Pseudo = item.Author.Pseudo,
                    Mail = item.Author.Mail,
                    RegistrationDate = item.Author.RegistrationDate
                },
                Title = item.Title,
                Content = item.Content,
                CreationDate = item.CreationDate
            }).ToList();
        }
    }
}
