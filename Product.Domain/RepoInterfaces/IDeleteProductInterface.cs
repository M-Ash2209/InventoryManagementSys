using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Product.Domain.RepoInterfaces
{
    public interface IDeleteProductInterface
    {
        Task<IActionResult> DeleteProductAsync(int Id);
    }
}
