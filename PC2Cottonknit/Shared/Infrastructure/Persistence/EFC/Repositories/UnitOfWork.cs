using PC2Cottonknit.Shared.Domain.Repositories;

namespace PC2Cottonknit.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public Task CompleteAsync()
    {
        throw new NotImplementedException();
    }
}