
using Clean_Arch.Application.Products;
using Clean_Arch.Application.Products.Create;
using Clean_Arch.Application.Shared;
using Clean_Arch.Application.Users;
using Clean_Arch.Contracts;
using Clean_Arch.Domain.Orders.Repository;
using Clean_Arch.Domain.OrdersAgg.Services;
using Clean_Arch.Domain.Products.Repository;
using Clean_Arch.Domain.Users.Repository;
using Clean_Arch.Domain.UsersAgg.Services;
using Clean_Arch.Infrastructure;
using Clean_Arch.Infrastructure.Persistent.EF.Users;
using Clean_Arch.Infrastructure.Persistent.Memory;
using Clean_Arch.Infrastructure.Persistent.Memory.Orders;
using Clean_Arch.Infrastructure.Persistent.Memory.Products;
using Clean_Arch.Query.Models;
using Clean_Arch.Query.Models.Products.Repository;
using Clean_Arch.Query.Models.Users.Repository;
using Clean_Arch.Query.Products.GetProductById;
using Clean_Arch.Query.Shared.BaseRepository;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SharpCompress.Common.Tar;


namespace Clean_Arch.Bootstrapper
{
    public class ProjectBootstrapper
    {
        public static void Init(IServiceCollection service, string connectionString)
        {
            //service.AddScoped<ISmsService, SmsService>();

            service.AddTransient<IOrderDomainService, OrderDomainService>();
            service.AddTransient<ISmsService, SmsService>();
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IProductReadRepository, ProductReadRepository>();
            service.AddTransient<IUserReadRepository, UserReadRepository>();
            service.AddTransient<IUserDomainService, UserDomainService>();
            service.AddMediatR(typeof(CreateProductCommand).Assembly);
            service.AddMediatR(typeof(GetProductByIdQuery).Assembly);
            service.AddTransient(typeof(IPipelineBehavior<,>), (typeof(CommandValidationBehavior<,>)));
            service.AddValidatorsFromAssembly(typeof(CreateProductCommandValidator).Assembly);
            service.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(connectionString);
            });
         
            service.AddSingleton<IMongoClient, MongoClient>(option =>
            {
             return new MongoClient("mongodb://localhost:27017");
              
            }); 
     
        }
    }
}
