using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopMvcSolution.Data.Enum;

namespace EShopMvcSolution.Data.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public int ShipName { get; set; }
        public int ShipAddress { get; set; }
        public int ShipEmail { get; set; }
        public int ShipPhoneNumber { get; set; }
        public OrderStatus Status { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
