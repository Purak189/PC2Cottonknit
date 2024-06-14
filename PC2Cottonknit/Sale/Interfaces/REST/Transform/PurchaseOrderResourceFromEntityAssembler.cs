using PC2Cottonknit.Sale.Domain.Model.Aggregates;
using PC2Cottonknit.Sale.Interfaces.REST.Resources;

namespace PC2Cottonknit.Sale.Domain.Model.Command;

public static class PurchaseOrderResourceFromEntityAssembler
{
    public static PurchaseOrderResource ToResourceFromEntity(PurchaseOrder entity)
    {
        return new PurchaseOrderResource(
            entity.id,
            entity.customer,
            (int)entity.fabricId,
            entity.city,
            entity.resumeUrl,
            entity.quantity
            );
    }
}