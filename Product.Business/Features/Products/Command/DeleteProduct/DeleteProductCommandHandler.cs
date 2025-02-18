using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Domain.RepoInterfaces;
using Product.Infrastructure.Data;

namespace CrudApp.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, IActionResult>
    {
        private readonly IDeleteProductInterface _deleteProductInterface;
        public DeleteProductCommandHandler(IDeleteProductInterface context)
        {
            _deleteProductInterface = context;
        }
        public async Task<IActionResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            return await _deleteProductInterface.DeleteProductAsync(request.Id);                             
        }
    }
}
