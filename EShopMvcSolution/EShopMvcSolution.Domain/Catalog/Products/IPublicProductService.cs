using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopMvcSolution.Application.Catalog.Products.Dtos;
using EShopMvcSolution.Application.Catalog.Products.Dtos.Public;
using EShopMvcSolution.Application.Dtos;

namespace EShopMvcSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingResquest resquest);  
    }
}
