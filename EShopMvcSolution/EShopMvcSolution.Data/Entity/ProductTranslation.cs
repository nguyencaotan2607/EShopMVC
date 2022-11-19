using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopMvcSolution.Data.Entity
{
    public class ProductTranslation
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Details { get; set; }
        public string SeoDescription { get; set; }

        public string Seotitle { get; set; }
        public int LanguageId { get; set; }

        public Product Products { get; set; }

        public Language Languages { get; set; }
    }
}
