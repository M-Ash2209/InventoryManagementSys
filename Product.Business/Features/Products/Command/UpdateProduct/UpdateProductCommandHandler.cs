using CrudApp.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Domain.RepoInterfaces;
using Product.Infrastructure.Data;

namespace CrudApp.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Item>
    {
        private readonly IUpdateProductInterface _updateProductInterface;
        public UpdateProductCommandHandler(IUpdateProductInterface context)
        {
            _updateProductInterface = context;
        }
        public async Task<Item> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var req = new Item
            {
                Description = request.Description,
                Name = request.Name,
                Id = request.Id,
                Price = request.Price,
                Quantity = request.Quantity,
            };
            return await _updateProductInterface.UpdateProductAsnyc(req);
        }

    }
}
