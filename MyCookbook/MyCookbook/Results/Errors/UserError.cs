namespace MyCookbook.Results.Errors
{
    public static class UserError
    {
        public static readonly Error Unauthorized = new Error("User.Unauthorized", "Nemáte oprávnění k této akci");
    }
}
