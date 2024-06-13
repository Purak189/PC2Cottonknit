namespace PC2Cottonknit.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity>
{
    Task AddSync(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    Task<IEnumerable<TEntity>> ListAsync();
}