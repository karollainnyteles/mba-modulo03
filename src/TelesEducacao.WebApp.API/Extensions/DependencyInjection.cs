using TelesEducacao.Catalogo.Application.Services;
using TelesEducacao.Catalogo.Data;
using TelesEducacao.Catalogo.Data.Repository;
using TelesEducacao.Catalogo.Domain;
using TelesEducacao.Core.Bus;

namespace TelesEducacao.WebApp.API.Setup;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // Domain Bus (Mediator)
        services.AddScoped<IMediatrHandler, MediatrHandler>();

        // Catalogo
        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<ICursoAppService, CursoAppService>();
        services.AddScoped<ICargaHorariaService, CargaHorariaService>();
        services.AddScoped<CatalogoContext>();

        //services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();
    }
}