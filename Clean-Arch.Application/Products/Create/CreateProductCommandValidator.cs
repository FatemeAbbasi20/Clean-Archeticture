using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Application.Products.Create
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(r => r.Description).NotEmpty().WithMessage("توضیحات را وارد کنید").MinimumLength(10).WithMessage("توضیحات باید حداقل 10 کارکتر باشد");
            RuleFor(r => r.Price).GreaterThanOrEqualTo(0).WithMessage(" مبلغ نامعتبر است");
        }



    }
}
