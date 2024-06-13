using PC2Cottonknit.Sale.Domain.Model.Aggregates;
using PC2Cottonknit.Sale.Domain.Model.Command;

namespace PC2Cottonknit.Sale.Domain.Services;

public interface IPurchaseOrderCommandService
{
    Task<PurchaseOrder?> Handle(CreatePurchaseOrderCommand command);
}