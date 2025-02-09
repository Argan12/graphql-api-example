using GraphQLApiExample.Application.Features.Articles.Handlers.Mutations;
using GraphQLApiExample.Application.Features.Articles.Types.Inputs;
using GraphQLApiExample.Application.Features.Articles.Types.Outputs;
using GraphQLApiExample.Application.Features.User;
using GraphQLApiExample.Application.Features.User.Handlers.Mutations;
using GraphQLApiExample.Application.Features.User.Types.Inputs;
using GraphQLApiExample.Application.Features.User.Types.Mappings;
using GraphQLApiExample.Application.Features.User.Types.Outputs;

namespace GraphQLApiExample.WebApp.GraphQL
{
    public class Mutation
    {
        #region User
        public async Task<UserDto> CreateUser([Service] UserMutationHandler handler, CreateUserInput input)
        {
            var user = await handler.Save(input);
            return user.ToOutput();
        }

        public async Task<bool> DeleteUser([Service] UserMutationHandler handler, DeleteUserInput input)
        {
            await handler.Remove(input);
            return true;
        }
        #endregion User

        #region Article
        public async Task<ArticleDto> CreateArticle([Service] ArticleMutationHandler handler, CreateArticleInput input) =>
            await handler.SaveArticle(input);

        public async Task<ArticleDto> UpdateArticle([Service] ArticleMutationHandler handler, UpdateArticleInput input) =>
            await handler.UpdateArticle(input);

        public async Task<bool> DeleteArticle([Service] ArticleMutationHandler handler, DeleteArticleInput input)
        {
            await handler.DeleteArticle(input);
            return true;
        }
        #endregion Article
    }
}
