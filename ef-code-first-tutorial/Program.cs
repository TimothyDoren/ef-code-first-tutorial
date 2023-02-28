using ef_code_first_tutorial;
using ef_code_first_tutorial.Controllers;
using Microsoft.EntityFrameworkCore;


var custCtrl = new CustomersController();

var customer = await custCtrl.GetCustomerWithOrders(1);
Console.WriteLine($"CUSTOMER: {customer.Name}");
foreach(var ord in customer.Orders)
{
    Console.WriteLine($"ORDER-- Description: {ord.Description}");
    foreach(var ol in ord.Orderlines)
    {
        Console.WriteLine($"--ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, " +
            $"Price: {ol.Item.Price:C}, Line Total: {ol.Quantity * ol.Item.Price:C}");
    }
}

//var _context = new SalesDbContext();
//var order = _context.Orders
//                            .Include(x => x.Orderlines)
//                                .ThenInclude(x => x.Item)
//                            .Include(x => x.Customer)
//                            .Single(x => x.Id == 1);
//Console.WriteLine($"ORDER: Description: {order.Description}");
//foreach(var ol in order.Orderlines)
//{
//    Console.WriteLine($"ORDERLINE: Product: {ol.Item.Name}, Quanity: {ol.Quantity}, Price: {ol.Item.Price:C}" +
//        $" Line Total: {ol.Quantity * ol.Item.Price:C}");
//}
//var orderTotal = order.Orderlines.Sum(ol => ol.Item.Price * ol.Quantity);
//Console.WriteLine($"Total: {orderTotal:C}");
//_context.Customers.ToList().ForEach(c => Console.WriteLine(c.Name)); 
