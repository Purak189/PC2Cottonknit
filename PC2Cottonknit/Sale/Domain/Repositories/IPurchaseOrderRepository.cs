using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using PC2Cottonknit.Sale.Domain.Model.Aggregates;

namespace PC2Cottonknit.Sale.Domain.Repositories;

public interface IPurchaseOrderRepository : IBaseRepository<PurchaseOrder>
{
    Task<bool> ExistsOrderWithCustomerAndFabricIdAsync(string customer, int fabricId);
}