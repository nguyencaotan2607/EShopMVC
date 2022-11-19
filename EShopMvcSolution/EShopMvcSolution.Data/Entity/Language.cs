using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopMvcSolution.Data.Entity
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Isdefault { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }

    }
}
