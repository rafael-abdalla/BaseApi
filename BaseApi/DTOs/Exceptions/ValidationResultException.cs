namespace BaseApi.DTOs
{
    public class ValidationResultException : Exception
    {
        public ValidationResultException()
        {

        }

        public ValidationResultException(string message) : base(message)
        {

        }
    }
}
