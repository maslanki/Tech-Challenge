using BusinessLib.Managers;
using BusinessLib.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class BusinessLibTests
    {
        private List<Order> orders;

        private OrderManager orderManager;

        [SetUp]
        public void Setup()
        {
            orderManager = new OrderManager();

            #region orders initialization
            orders = new List<Order>()
            {
                new Order()
                {
                    Lines = new List<Line>()
                    {
                        new Line()
                        {
                            Gtin = "1",
                            Description = "1st product",
                            Quantity = 4
                        },
                        new Line()
                        {
                            Gtin = "2",
                            Description = "2nd product",
                            Quantity = 1
                        }
                    }
                },
                new Order()
                {
                     Lines = new List<Line>()
                    {
                        new Line()
                        {
                            Gtin = "2",
                            Description = "2nd product",
                            Quantity = 5
                        },
                        new Line()
                        {
                            Gtin = "3",
                            Description = "3rd product",
                            Quantity = 5
                        },
                        new Line()
                        {
                            Gtin = "4",
                            Description = "4th product",
                            Quantity = 2
                        },
                        new Line()
                        {
                            Gtin = "5",
                            Description = "5th product",
                            Quantity = 1
                        },
                        new Line()
                        {
                            Gtin = "6",
                            Description = "6th product",
                            Quantity = 4
                        }
                    }
                }
            };
            #endregion
        }


        [Test]
        public async Task GetTop5ProductsTest()
        {
            var top5Products = await orderManager.GetTop5ProductsAsync(orders);
            top5Products.Count.Should().Be(5);

            top5Products.FirstOrDefault().Gtin.Should().Be("2");
            top5Products.FirstOrDefault().ProductName.Should().Be("2nd product");
            top5Products.FirstOrDefault().TotalQuantity.Should().Be(6);

            top5Products[1].Gtin.Should().Be("3");
            top5Products[1].TotalQuantity.Should().Be(5);

            top5Products[2].Gtin.Should().Be("1");
            top5Products[2].TotalQuantity.Should().Be(4);

            top5Products[3].Gtin.Should().Be("6");
            top5Products[3].TotalQuantity.Should().Be(4);

            top5Products[4].Gtin.Should().Be("4");
            top5Products[4].TotalQuantity.Should().Be(2);
        }
    }
}