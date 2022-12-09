﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EShopMvcSolution.Data.EF;
using EShopMvcSolution.ViewModels.Catalog.Products.Dtos;
using EShopMvcSolution.ViewModels.Catalog.Products.Dtos.Public;
using EShopMvcSolution.ViewModels.Dtos;
using Microsoft.EntityFrameworkCore;


namespace EShopMvcSolution.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly EShopMvcDbContext _context;

        public PublicProductService(EShopMvcDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingResquest request)
        {
            //1.Select Join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on pt.Id equals pic.ProductId
                        join c in _context.Categories on pic.ProductId equals c.Id
                        select new { p, pt, pic };

            //2.filter

            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }

            //3. Paging
            int totalrow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex * 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreate = x.p.DateCreate,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Prince = x.p.Prince,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    Viewcount = x.p.Viewcount

                }).ToListAsync();

            //4. Select and Projection 

            var PageResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalrow,
                Items = data
            };
            return PageResult;
        }
    }
}
