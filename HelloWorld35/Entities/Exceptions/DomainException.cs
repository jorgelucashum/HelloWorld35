using System;


namespace HelloWorld35.Entities.Exceptions
{
    // Exceção personalizada: 'DomainException'.
    class DomainException : ApplicationException // subclasse de 'ApplicationException' para tratar exceções personalizadas.
    {
        public DomainException(string message) : base(message)
        {

        }

    }
}
