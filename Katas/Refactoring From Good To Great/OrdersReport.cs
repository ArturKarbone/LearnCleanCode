using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Order
    {
        public DateTime PlacedAt { get; set; }
        public decimal Amount { get; set; }
    }

    class OrdersReport{
        private IEnumerable<Order> @orders;
        private DateTime @startDate;
        private DateTime @endDate;
        public OrdersReport(IEnumerable<Order> orders, DateTime startDate, DateTime endDate)
        {
            //???  @orders = orders;
            this.@orders = orders;
            this.@startDate = startDate;
            this.@endDate = endDate;
        }

        public decimal TotalSalesWithinDateRange(){
            var ordersWithinRange = @orders.Where(x=>x.PlacedAt >= @startDate && x.PlacedAt <= @endDate);

            return ordersWithinRange.Sum(x=>x.Amount);
        }
    }
}
