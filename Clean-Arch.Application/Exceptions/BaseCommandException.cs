using Clean_Arch.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Application.Exceptions
{
    public class BaseCommandException: BaseDomainException
    {
        public BaseCommandException()
        {

        }
        public BaseCommandException(string message) : base(message)
        {

        }
        public class InvalidCommandException : BaseCommandException
        {
            public InvalidCommandException()
            {
            }

            public InvalidCommandException(string message) : base(message)
            {
            }
        }
    }
}
