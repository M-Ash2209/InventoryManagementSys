using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Features.Products.Command.DeleteProduct
{
    public record DeleteProductCommand (int Id) : IRequest<IActionResult>;
    
}
