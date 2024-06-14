namespace PC2Cottonknit.Sale.Interfaces.REST.Resources;

public record PurchaseOrderResource(
    int id,
    string customer,
    int fabricId,
    string city,
    string resumeUrl,
    int quantity
    );