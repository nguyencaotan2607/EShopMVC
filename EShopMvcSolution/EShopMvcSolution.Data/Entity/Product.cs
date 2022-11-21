using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopMvcSolution.Data.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Prince { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public int Viewcount { get; set; }
        public DateTime DateCreate { get; set; }
        public string? SeoAlias { get; set; }

        public List<ProductInCategory> ProductInCategories { get; set;}

        public List<OrderDetail> OrderDetails { get; set; }

        public List<Cart> Carts { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }

        public List<ProductImage> ProductImages { get; set; }

    }
}
