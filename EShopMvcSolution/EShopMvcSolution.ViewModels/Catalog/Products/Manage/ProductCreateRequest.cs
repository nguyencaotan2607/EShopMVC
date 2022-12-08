using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EShopMvcSolution.ViewModels.Catalog.Products.Dtos.Manage
{
    public class ProductCreateRequest
    {
        public decimal Prince { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public int Viewcount { get; set; }
        public DateTime DateCreate { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string Details { get; set; }
        public string SeoDescription { get; set; }

        public string SeoAlias { get; set; }

        public string SeoTitle { get; set; }
        public string LanguageId { get; set; }

        public IFormFile ThumbnailImage { get; set; }
    }
}
