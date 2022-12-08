using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopMvcSolution.Data.Entity;
using EShopMvcSolution.ViewModels.Catalog.Products.Dtos;
using EShopMvcSolution.ViewModels.Catalog.Products.Dtos.Manage;
using EShopMvcSolution.ViewModels.Dtos;

namespace EShopMvcSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newprice);

        Task<bool> UpdateStock(int productId, int AddedQuantity);

        Task<int> AddViewcount(int productId);


        Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingResquest request);

    }


}
