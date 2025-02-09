using GraphQLApiExample.Application.Common.Interfaces;
using GraphQLApiExample.Infrastructure.Entities;
using GraphQLApiExample.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using ArticleDomain = GraphQLApiExample.Domain.Entities.Article;

namespace GraphQLApiExample.Infrastructure.Repositories
{
    public class ArticleRepository(GraphQLApiExampleDbContext context) : IArticleRepository
    {
        private readonly GraphQLApiExampleDbContext _context = context;

        /// <summary>
        /// Find article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of articles</returns>
        public async Task<ArticleDomain?> FindById(Guid id)
        {
            var article = await _context.Article
                .SingleOrDefaultAsync(x => x.Id == id);
            return article?.ToDomain();
        }

        /// <summary>
        /// Fetch all articles
        /// </summary>
        /// <returns>Articles</returns>
        public async Task<List<ArticleDomain>> FindAllArticles()
        {
            return await _context.Article
                .Include(x => x.User)
                .Select(x => x.ToDomain())
                .ToListAsync();
        }

        /// <summary>
        /// Save new article
        /// </summary>
        /// <param name="article">Domain object</param>
        /// <returns>Domain object</returns>
        public async Task<ArticleDomain> Save(ArticleDomain article)
        {
            var articleDbo = article.ToDbo();
            
            var user = _context.User.Single(x => x.Id == article.UserId);
            articleDbo.User = user;
             
            _context.Article.Add(articleDbo);
            await _context.SaveChangesAsync();

            return articleDbo.ToDomain();
        }

        /// <summary>
        /// Update an article
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public async Task<ArticleDomain> Update(ArticleDomain article)
        {
            var articleDbo = await _context.Article.SingleAsync(x => x.Id == article.Id);
            var user = await _context.User.SingleAsync(x => x.Id == article.UserId);

            articleDbo.Title = article.Title;
            articleDbo.Content = article.Content;
            articleDbo.User = user;

            await _context.SaveChangesAsync();

            return articleDbo.ToDomain();
        }

        /// <summary>
        /// Remove an article
        /// </summary>
        /// <param name="id"></param>
        public async Task Delete(Guid id)
        {
            var article = await _context.Article.SingleAsync(x => x.Id == id);
            _context.Remove(article);
            await _context.SaveChangesAsync();
        }
    }
}
