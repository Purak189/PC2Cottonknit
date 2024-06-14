using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace PC2Cottonknit.Sale.Domain.Model.Aggregates;

public partial class PurchaseOrder : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")]public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdateAt")]public DateTimeOffset? UpdatedDate { get; set; }
}