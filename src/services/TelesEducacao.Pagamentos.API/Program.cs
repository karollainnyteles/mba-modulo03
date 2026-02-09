using Microsoft.EntityFrameworkCore;
using TelesEducacao.Pagamentos.AntiCorruption;
using TelesEducacao.Pagamentos.Business;
using TelesEducacao.Pagamentos.Data;
using TelesEducacao.Pagamentos.Data.Repository;
using MediatR;
using TelesEducacao.Core.Communication.Mediator;
using TelesEducacao.Pagamentos.API.Controllers; 

// aliases pra evitar conflito com IConfigurationManager do .NET
using IPagamentosConfigManager = TelesEducacao.Pagamentos.AntiCorruption.IConfigurationManager;
using PagamentosConfigManager = TelesEducacao.Pagamentos.AntiCorruption.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (SQLite)
builder.Services.AddDbContext<PagamentosContext>(options =>
{
    options.UseSqlite("Data Source=pagamentos.db");
});

// DI Pagamentos (Business + AntiCorruption)
builder.Services.AddScoped<IPagamentoService, PagamentoService>();
builder.Services.AddScoped<IPagamentoCartaoCreditoFacade, PagamentoCartaoCreditoFacade>();
builder.Services.AddScoped<IPayPalGateway, PayPalGateway>();
builder.Services.AddSingleton<IPagamentosConfigManager, PagamentosConfigManager>();

// Repository
builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        typeof(PagamentosController).Assembly, // API
        typeof(PagamentoService).Assembly,     // Business
        typeof(PagamentosContext).Assembly     // Data
    ));

builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
