using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Model;

namespace Product.Domain.RepoInterfaces
{
    public interface IAddProductInterface
    {
        Task<int> AddProductAsync(Item item);
    }
}
