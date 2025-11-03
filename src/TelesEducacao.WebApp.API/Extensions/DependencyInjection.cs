using TelesEducacao.Conteudos.Application.Services;
using TelesEducacao.Conteudos.Data;
using TelesEducacao.Conteudos.Data.Repository;
using TelesEducacao.Conteudos.Domain;
using TelesEducacao.Core.Bus;

namespace TelesEducacao.WebApp.API.Extensions;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Domain Bus (Mediator)
        services.AddScoped<IMediatrHandler, MediatrHandler>();

        // Conteudos
        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<ICursoAppService, CursoAppService>();
        services.AddScoped<ICargaHorariaService, CargaHorariaService>();
        services.AddScoped<ConteudosContext>();

        //services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
    }
}