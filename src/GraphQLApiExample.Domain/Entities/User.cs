namespace GraphQLApiExample.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Pseudo { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public DateTime RegistrationDate {  get; set; }
    }
}
