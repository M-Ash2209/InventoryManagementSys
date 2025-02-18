using CrudApp.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}


