namespace SalesWebMvc7.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        public IntegrityException(string message) : base(message) 
        { 
        }
        // exceção personalizada de serviço, para erros de integridade referencial
    }
}
