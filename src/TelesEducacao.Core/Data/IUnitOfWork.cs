namespace TelesEducacao.Core.Data;

public interface IUnitOfWork
{
    Task<bool> Commit();
}