namespace SerialsOnlineService.BLL.Exceptions
{
    public class InvalidFilterParametersException : Exception
    {
        public int StatusCode { get; } = 400;

        public InvalidFilterParametersException() { }

        public InvalidFilterParametersException(string message, Exception innerException) : base(message, innerException) { }

        public InvalidFilterParametersException(string message) : base(message) { }

    }
}
