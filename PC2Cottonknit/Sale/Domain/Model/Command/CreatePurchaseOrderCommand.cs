namespace PC2Cottonknit.Sale.Domain.Model.Command;

public record CreatePurchaseOrderCommand(
    string Customer,
    int FabricId,
    string City,
    string ResumeUrl,
    int Quantity
    );