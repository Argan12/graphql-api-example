namespace GraphQLApiExample.Application.Features.User.Types.Inputs
{
    public class CreateUserInput
    {
        public string Pseudo { get; set; } = null!;
        public string Mail { get; set; } = null!;
    }
}
