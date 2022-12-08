using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopMvcSolution.ViewModels.Catalog.Products.Dtos;
using EShopMvcSolution.ViewModels.Catalog.Products.Dtos.Manage;
using EShopMvcSolution.ViewModels.Dtos;

namespace EShopMvcSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingResquest resquest);  
    }
}
