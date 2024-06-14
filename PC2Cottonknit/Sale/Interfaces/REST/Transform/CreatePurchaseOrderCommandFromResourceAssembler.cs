using PC2Cottonknit.Sale.Domain.Model.Command;
using PC2Cottonknit.Sale.Interfaces.REST.Resources;

namespace PC2Cottonknit.Sale.Interfaces.REST.Transform;

public static class CreatePurchaseOrderCommandFromResourceAssembler
{
    public static CreatePurchaseOrderCommand ToCommandFromResource(CreatePurchaseOrderResource resource)
    {
        return new CreatePurchaseOrderCommand(
            resource.customer, 
            resource.fabricId,
            resource.city, 
            resource.resumeUrl, 
            resource.quantity
            );
    }
}