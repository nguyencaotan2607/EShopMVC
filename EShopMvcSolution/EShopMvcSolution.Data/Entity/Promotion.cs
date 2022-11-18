using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopMvcSolution.Data.Enum;

namespace EShopMvcSolution.Data.Entity
{
    public class Promotion
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int ApplyforAll { get; set; }
        public int DiscountPercent { get; set; }
        public int DiscountAmount { get; set; }
        public int ProductIds { get; set; }
        public int ProductCategoryIds { get; set; }
        public Status Status { get; set; }
        public int Name { get; set; }


    }
}
