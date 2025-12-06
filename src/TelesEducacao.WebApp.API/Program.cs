using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TelesEducacao.Alunos.Application.AutoMapper;
using TelesEducacao.Alunos.Data;
using TelesEducacao.Conteudos.Application.AutoMapper;
using TelesEducacao.Conteudos.Data;
using TelesEducacao.WebApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//  Config banco de dados e Identity
builder.Services.AddDbContext<ConteudosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AlunosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedEmail = false;
        options.User.RequireUniqueEmail = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AlunosContext>();

builder.Services.AddAutoMapper(cfg => { },
    typeof(DomainToDtoMappingProfile),
    typeof(DtoToDomainMappingProfile),
    typeof(AlunosDtoToDomainMappingProfile),
    typeof(AlunosDomainToDtoMappingProfile));

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