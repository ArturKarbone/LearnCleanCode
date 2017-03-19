using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Order
    {
        public DateTime PlacedAt { get; set; }
        public decimal Amount { get; set; }

        public bool PlacedBetween(DateRange dateRange) => PlacedAt >= dateRange.From && PlacedAt <= dateRange.To;
    }

    class DateRange
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool Includes(DateTime date) => date >= From && date <= To;

    }
    class OrdersReport
    {
        private IEnumerable<Order> @orders;
        private DateRange @dateRange;

        public OrdersReport(IEnumerable<Order> orders, DateRange dateRange)
        {
            //???  @orders = orders;
            this.@orders = orders;
            this.@dateRange = dateRange;           
        }

        public decimal TotalSalesWithinDateRange()
        {
            return OrdersWithinRange()
                .Sum(x => x.Amount);
        }

        private IEnumerable<Order> OrdersWithinRange()
        {
            return @orders.Where(x => x.PlacedBetween(dateRange));
        }
    }
}