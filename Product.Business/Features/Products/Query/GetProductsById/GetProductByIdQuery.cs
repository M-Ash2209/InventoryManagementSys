using CrudApp.Model;
using MediatR;

namespace CrudApp.Features.Products.Query.GetProductsById
{
    public record GetProductByIdQuery(int Id) : IRequest<Item>;

}
