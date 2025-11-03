using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TelesEducacao.Conteudos.Application.AutoMapper;
using TelesEducacao.Conteudos.Data;
using TelesEducacao.WebApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ConteudosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(cfg => { }, typeof(DomainToDtoMappingProfile));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.RegisterServices();

var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
    options.SwaggerEndpoint("/openapi/v1.json", "Teles Educação api"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();