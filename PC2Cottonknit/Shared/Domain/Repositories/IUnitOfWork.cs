namespace PC2Cottonknit.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}