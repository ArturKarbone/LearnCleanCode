using System;
using System.Collections.Generic;
using Orders;
using Shouldly;
using Xunit;

namespace Refactoring_From_Good_To_Great
{
    public class OrdersReportTests
    {
        [Fact]
        public void Should_Calculate_Total_Sales()
        {
            var orders = new List<Order>(){
                new Order{
                    PlacedAt = new DateTime(2016,3,1),
                    Amount = 10
                },
                 new Order{
                    PlacedAt = new DateTime(2017,3,1),
                    Amount = 20
                },
                 new Order{
                    PlacedAt = new DateTime(2017,3,10),
                    Amount = 30
                }
            };

            new OrdersReport(orders, new DateTime(2017, 1, 1), new DateTime(2017, 12, 31))
                    .TotalSalesWithinDateRange()
                    .ShouldBe(50);

        }
    }
}
