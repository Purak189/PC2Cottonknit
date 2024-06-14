using ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using PC2Cottonknit.Sale.Domain.Model.Aggregates;
using PC2Cottonknit.Sale.Domain.Model.Command;
using PC2Cottonknit.Sale.Domain.Repositories;
using PC2Cottonknit.Sale.Domain.Services;

namespace PC2Cottonknit.Sale.Application.Internal.CommandServices;

public class PurchaseOrderCommanService(IPurchaseOrderRepository purchaseOrderRepository, IUnitOfWork unitOfWork) : IPurchaseOrderCommandService
{
    public async Task<PurchaseOrder?> Handle(CreatePurchaseOrderCommand command)
    {
        bool purchaseOrderExist =  await purchaseOrderRepository.ExistsOrderWithCustomerAndFabricIdAsync(command.Customer, command.FabricId);
        if ( purchaseOrderExist )
        {
            throw new Exception("Purchase order already exists");
        }
        var purchaseOrder = new PurchaseOrder(command);
        await purchaseOrderRepository.AddAsync(purchaseOrder);
        await unitOfWork.CompleteAsync();
        return purchaseOrder;
    }
}