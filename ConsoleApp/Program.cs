

using BusinessLib.Managers;

var orderManager = new OrderManager();

Console.WriteLine("****** Orders with status IN_PROGRESS ******");
var inProgressOrders = await orderManager.GetInProgressOrdersAsync();
inProgressOrders.ForEach(o => Console.WriteLine(o));

Console.WriteLine("\n\n\n****** Top 5 products sold ******");
var topProducts = await orderManager.GetTop5ProductsAsync(inProgressOrders);
topProducts.ForEach(o => Console.WriteLine(o));

var firstProductId = topProducts.FirstOrDefault().MerchantProductNo;
Console.WriteLine($"****** Setting a stock = 25 of the product with merchantProductNo = {firstProductId} ******");
await orderManager.SetStock(firstProductId);
Console.WriteLine($"Done!");
