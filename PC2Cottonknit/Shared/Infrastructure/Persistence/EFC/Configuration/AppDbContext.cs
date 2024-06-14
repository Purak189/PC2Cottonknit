using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using PC2Cottonknit.Sale.Domain.Model.Aggregates;

namespace PC2Cottonknit.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors.
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Purchase Order Context
        
        // Configure EFabric as an integer in DB
        builder.Entity<PurchaseOrder>()
            .Property(po => po.fabricId)
            .HasConversion<int>()
            .IsRequired();
        // Ensure customer and fabricId are unique
        builder.Entity<PurchaseOrder>()
            .HasIndex(po => new { po.customer, po.fabricId })
            .IsUnique();
        builder.Entity<PurchaseOrder>().HasKey(po => po.id);
        builder.Entity<PurchaseOrder>().Property(po => po.id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Entity<PurchaseOrder>().Property(po => po.customer)
            .IsRequired();
        builder.Entity<PurchaseOrder>().Property(po => po.city)
            .IsRequired();
        builder.Entity<PurchaseOrder>().Property(po => po.quantity)
            .IsRequired();
        builder.Entity<PurchaseOrder>().Property(po => po.resumeUrl)
            .IsRequired();
        
        
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}