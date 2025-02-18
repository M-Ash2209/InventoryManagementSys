using CrudApp.Model;
using MediatR;
using Product.Domain.RepoInterfaces;
using Product.Infrastructure.Data;

namespace CrudApp.Features.Products.Query.GetProductsById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Item>
    {

        private readonly IGetProductInterface _res;
        public GetProductByIdQueryHandler(IGetProductInterface context)
        {
            _res = context;
        }
        public async Task<Item> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _res.GetProductByIdAsync(request.Id);
            return product;
        }
    }
}
