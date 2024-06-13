using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using PC2Cottonknit.Sale.Domain.Model.Aggregates;
using PC2Cottonknit.Sale.Domain.Model.Enums;
using PC2Cottonknit.Sale.Domain.Repositories;
using PC2Cottonknit.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace PC2Cottonknit.Sale.Infrastructure.Persistence.EFC.Repositories;

public class PurchaseOrderRepository(AppDbContext context) : BaseRepository<PurchaseOrder>(context), IPurchaseOrderRepository
{
    public async Task<bool> ExistsOrderWithCustomerAndFabricIdAsync(string customer, int fabricId)
    {
        EFabric fabric = (EFabric)fabricId;
        return await Context.Set<PurchaseOrder>()
            .AnyAsync(po => po.customer == customer && po.fabricId == fabric);
    }
}