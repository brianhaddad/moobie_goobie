using System;

namespace MoobieGoobie.DependencyInjection
{
    public class RegistrationException : Exception
    {
        public RegistrationException(string msg) : base(msg)
        {
        }
    }
}
