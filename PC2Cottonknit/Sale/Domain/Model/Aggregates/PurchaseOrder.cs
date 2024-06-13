using PC2Cottonknit.Sale.Domain.Model.Enums;

namespace PC2Cottonknit.Sale.Domain.Model.Aggregates;

public class PurchaseOrder
{
    public int id { get; }
    public string customer { get; set; }
    public string city { get; set; }
    public string resumerUrl { get; set; }
    public EFabric fabricId { get; set; } // This is a enum type
    public int quantity { get; set; }
}