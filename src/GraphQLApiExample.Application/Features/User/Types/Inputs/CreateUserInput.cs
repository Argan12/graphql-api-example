using System.ComponentModel.DataAnnotations;

namespace GraphQLApiExample.Application.Features.User.Types.Inputs
{
    public class CreateUserInput
    {
        [Required]
        [MaxLength(100)]
        public string Pseudo { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Mail { get; set; } = null!;
    }
}
