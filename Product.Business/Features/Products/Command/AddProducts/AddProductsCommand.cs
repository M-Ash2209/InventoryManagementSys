using System.ComponentModel.DataAnnotations.Schema;
using MediatR;

namespace CrudApp.Features.Products.Command.AddProducts
{
    public class AddProductsCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}
