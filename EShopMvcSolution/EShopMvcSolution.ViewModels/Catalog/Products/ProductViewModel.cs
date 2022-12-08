﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopMvcSolution.ViewModels.Catalog.Products.Dtos
{
    public class ProductViewModel
    {
        public int Id { get; set; }
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

    }
}