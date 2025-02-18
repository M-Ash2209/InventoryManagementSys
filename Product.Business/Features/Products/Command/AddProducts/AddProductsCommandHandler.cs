using CrudApp.Model;
using MediatR;
using Product.Domain.RepoInterfaces;
using Product.Infrastructure.Data;

namespace CrudApp.Features.Products.Command.AddProducts
{
    public class AddProductsCommandHandler : IRequestHandler<AddProductsCommand, int>
    {
        private readonly IAddProductInterface _addProductInterface;
        public AddProductsCommandHandler(IAddProductInterface context)
        {
            _addProductInterface = context;
        }
        public async Task<int> Handle(AddProductsCommand request, CancellationToken cancellationToken)
        {
            var products = new Item { Name = request.Name, Description = request.Description, Price = request.Price, 
                CategoryId = request.CategoryId, Quantity = request.Quantity, Created = DateTime.Now, Updated = DateTime.Now};
           
            return await _addProductInterface.AddProductAsync(products);
        }
    }
}
