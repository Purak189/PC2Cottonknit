using PC2Cottonknit.Sale.Domain.Model.Command;
using PC2Cottonknit.Sale.Domain.Model.Enums;

namespace PC2Cottonknit.Sale.Domain.Model.Aggregates;

public partial class PurchaseOrder
{
    public int id { get; }
    public string customer { get; set; }
    public string city { get; set; }
    public string resumeUrl { get; set; }
    public EFabric fabricId { get; set; } // This is a enum type
    public int quantity { get; set; }
    
    public PurchaseOrder() {}

    public PurchaseOrder(CreatePurchaseOrderCommand command)
    {
        
        customer = command.Customer;
        city = command.City;
        resumeUrl = command.ResumeUrl;
        fabricId = (EFabric)command.FabricId;
        quantity = command.Quantity;
    }
}