using Microsoft.AspNetCore.Mvc;
using PC2Cottonknit.Sale.Domain.Model.Command;
using PC2Cottonknit.Sale.Domain.Model.Enums;
using PC2Cottonknit.Sale.Domain.Repositories;
using PC2Cottonknit.Sale.Domain.Services;
using PC2Cottonknit.Sale.Interfaces.REST.Resources;
using PC2Cottonknit.Sale.Interfaces.REST.Transform;

namespace PC2Cottonknit.Sale.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class PurchaseOrdersController : ControllerBase
{
    private readonly IPurchaseOrderCommandService _purchaseOrderCommandService;
    private readonly IPurchaseOrderRepository _purchaseOrderRepository;

    public PurchaseOrdersController(IPurchaseOrderCommandService purchaseOrderCommandService, IPurchaseOrderRepository purchaseOrderRepository)
    {
        _purchaseOrderCommandService = purchaseOrderCommandService;
        _purchaseOrderRepository = purchaseOrderRepository;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePurchaseOrder([FromBody] CreatePurchaseOrderResource createPurchaseOrderResource)
    {
        // Validamos que no exista una orden de compra con el mismo customer y fabricId
        var existsOrder =
            await _purchaseOrderRepository.ExistsOrderWithCustomerAndFabricIdAsync(createPurchaseOrderResource.customer,
                createPurchaseOrderResource.fabricId);
        if (existsOrder) return BadRequest("Ya existe una orden de compra con el mismo cliente y tipo de tela.");
        
        // Validamos que fabricId correspenda a una de las 8 posibilidades que ofrece Cotton Knit
        if (!Enum.IsDefined(typeof(EFabric), createPurchaseOrderResource.fabricId))
        {
            return BadRequest("El tipo de tela proporcionado no es válido.");
        }
        
        var createPurchaseOrderCommand =
            CreatePurchaseOrderCommandFromResourceAssembler.ToCommandFromResource(createPurchaseOrderResource);
        var purchaseOrder = await _purchaseOrderCommandService.Handle(createPurchaseOrderCommand);
        if (purchaseOrder is null) return BadRequest();
        
        var resource = PurchaseOrderResourceFromEntityAssembler.ToResourceFromEntity(purchaseOrder);
        return Ok(resource);
    }


    
}