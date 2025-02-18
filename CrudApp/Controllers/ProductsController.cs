using CrudApp.Data;
using CrudApp.Features.Products.Command.AddProducts;
using CrudApp.Features.Products.Command.DeleteProduct;
using CrudApp.Features.Products.Command.UpdateProduct;
using CrudApp.Features.Products.Query.GetProductsById;
using CrudApp.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]

public class ProductsController : ControllerBase
{
    private readonly ProductDbContext _context;
    private readonly ISender _sender;

    public ProductsController(ProductDbContext context, ISender sender)
    {
        _context = context;
        _sender = sender;
    }

    [HttpGet]
    //[AllowAnonymous]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _context.Products.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _sender.Send(new GetProductByIdQuery(id));
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(AddProductsCommand command)
    {
        var productId = await _sender.Send(command);
        return Ok(productId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id,UpdateProductCommand updateProductCommand)
    {
        if (id != updateProductCommand.Id) return BadRequest();
        //var updateProductCommand = new UpdateProductCommand();
        var productI = await _sender.Send(updateProductCommand);
        if (productI == null) return NotFound();
        return Ok(productI);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        
        return await _sender.Send(new DeleteProductCommand(id));
    }
}
