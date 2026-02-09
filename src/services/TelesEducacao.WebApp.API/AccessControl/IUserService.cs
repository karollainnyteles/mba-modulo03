namespace TelesEducacao.WebApp.API.AccessControl;

public interface IUserService
{
    Task<Guid?> RegisterAsync(string email, string senha, string roleName, CancellationToken cancellationToken);

    Task<Guid?> LoginAsync(string email, string senha, CancellationToken cancellationToken);
}