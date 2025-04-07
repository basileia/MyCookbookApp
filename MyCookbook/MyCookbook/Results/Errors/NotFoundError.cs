namespace MyCookbook.Results.Errors
{
    public record NotFoundError : Error
    {        public NotFoundError(string code, string message) : base(code, message) { }
    }
}
