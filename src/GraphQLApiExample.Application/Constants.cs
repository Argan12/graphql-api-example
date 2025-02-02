namespace GraphQLApiExample.Application
{
    public static class Constants
    {
        // Errors labels
        public static readonly string ERR_USER_NOT_FOUND = "No user has been found.";
        public static readonly string ERR_MAIL_ALREADY_EXISTS = "A user with this mail address aldready exist.";

        // Errors code
        public static readonly string VALIDATION_ERRORS = "VALIDATION_ERRORS";
        public static readonly string RESOURCE_NOT_FOUND = "RESOURCE_NOT_FOUND";
        public static readonly string BAD_REQUEST = "BAD_REQUEST";
    }
}
