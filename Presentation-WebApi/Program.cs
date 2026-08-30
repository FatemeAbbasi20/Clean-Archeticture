using Clean_Arch.Bootstrapper;
using Clean_Arch.Query.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Presentation_WebApi;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Insert services to the container.
var Services = builder.Services;
Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
Services.AddEndpointsApiExplorer();
Services.AddSwaggerGen();
ProjectBootstrapper.Init(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));
Services.AddAutoMapper(typeof(MapProfile).Assembly);
Services.AddAuthentication(option =>
{
    option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:SignInKey" ])),
        ValidIssuer =builder.Configuration["JwtConfig:Issuer"],
        ValidAudience= builder.Configuration["JwtConfig:Audience"],
        ValidateAudience=true,
        ValidateIssuerSigningKey=true,
        ValidateIssuer=true,
        ValidateLifetime=true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
