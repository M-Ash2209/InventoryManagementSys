using System.ComponentModel.DataAnnotations.Schema;
using Product.Domain.Model;

namespace CrudApp.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }  

        public Category Category { get; set; }
       

    }

}
