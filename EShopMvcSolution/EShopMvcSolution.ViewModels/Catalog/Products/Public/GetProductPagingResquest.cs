using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopMvcSolution.ViewModels.Dtos;

namespace EShopMvcSolution.ViewModels.Catalog.Products.Dtos.Public
{
    public class GetProductPagingResquest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
