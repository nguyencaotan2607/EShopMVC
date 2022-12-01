using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using EShopMvcSolution.Application.Catalog.Products.Dtos;
using EShopMvcSolution.Application.Catalog.Products.Dtos.Manage;
using EShopMvcSolution.Application.Dtos;
using EShopMvcSolution.Data.EF;
using EShopMvcSolution.Data.Entity;
using EShopSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace EShopMvcSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopMvcDbContext _context;

        public ManageProductService(EShopMvcDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddViewcount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.Viewcount += 1; 
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Prince = request.Prince,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                Viewcount = 0,
                DateCreate = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    }

                }

            };   
            _context.Products.Add(product);
            return  await _context.SaveChangesAsync();


        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Can't Find Product with Id : {productId}");
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
            
        }



        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingResquest request)
        {
            //1.Select Join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on pt.Id equals pic.ProductId
                        join c in _context.Categories on pic.ProductId equals c.Id
                        select new { p, pt, pic };

            //2.filter

            if (!string.IsNullOrEmpty(request.keyword))
            {
                query = query.Where(x => x.pt.Name.Contains(request.keyword));
            }

            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
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

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var producttranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);

            if (product == null || producttranslation == null) throw new EShopException($"Can't Find a Product With Id: {request.Id}");

            producttranslation.Name = request.Name;
            producttranslation.Description = request.Description;
            producttranslation.SeoTitle = request.SeoTitle;
            producttranslation.SeoDescription= request.SeoDescription;
            producttranslation.Details = request.Details;
            producttranslation.SeoAlias= request.SeoAlias;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newprice)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null) throw new EShopException($"Can't Fint Product With Id:{productId}");
            product.Prince = newprice;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int AddedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Can't Find Product with Id:{productId}");

            product.Stock += AddedQuantity;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
