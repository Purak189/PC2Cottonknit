namespace PC2Cottonknit.Sale.Interfaces.REST.Resources;

public record CreatePurchaseOrderResource(
    string customer,
    string city,
    string resumeUrl,
    int fabricId,
    int quantity
    );