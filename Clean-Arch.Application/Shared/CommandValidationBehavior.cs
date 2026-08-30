using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clean_Arch.Application.Exceptions.BaseCommandException;

namespace Clean_Arch.Application.Shared
{
    public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;

        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var errors = _validators.Select(e => e.Validate(request)).SelectMany(result => result.Errors).Where(s => s != null);
            if (errors.Any())
            {
                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }
                throw new InvalidCommandException(stringBuilder.ToString());
            }
                var response = await next();
                return response;
           
        }
    }
    
    
}
