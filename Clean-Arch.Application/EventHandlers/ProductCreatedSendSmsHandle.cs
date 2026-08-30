using Clean_Arch.Contracts;
using Clean_Arch.Domain.ProductsAgg.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Application.EventHandlers
{
    public class ProductCreatedSendSmsHandle:INotificationHandler<ProductCreated>
    {
        private readonly ISmsService _smsService;
        public ProductCreatedSendSmsHandle(ISmsService smsService)
        {
            _smsService=smsService;
        }
        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            _smsService.SendSms(new SmsBody());
            await  Task.CompletedTask;
        }
    }
}
