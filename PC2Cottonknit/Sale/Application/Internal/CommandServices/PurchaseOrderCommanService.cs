using PC2Cottonknit.Sale.Domain.Model.Aggregates;
using PC2Cottonknit.Sale.Domain.Model.Command;
using PC2Cottonknit.Sale.Domain.Repositories;
using PC2Cottonknit.Sale.Domain.Services;

namespace PC2Cottonknit.Sale.Application.Internal.CommandServices;

public class PurchaseOrderCommanService(IPurchaseOrderRepository purchaseOrderRepository) : IPurchaseOrderCommandService
{
    public async Task<PurchaseOrder?> Handle(CreatePurchaseOrderCommand command)
    {
        bool purchaseOrderExist =  await purchaseOrderRepository.ExistsOrderWithCustomerAndFabricIdAsync(command.Customer, command.FabricId);
        if ( purchaseOrderExist )
        {
            throw new Exception("Purchase order already exists");
        }
        
    }
}