﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopMvcSolution.ViewModels.Dtos;

namespace EShopMvcSolution.ViewModels.Catalog.Products.Dtos.Manage
{
    public class GetProductPagingResquest : PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}