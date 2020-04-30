using System;
using Store.Entities;
using Store.Entities.Enum;
using System.Globalization;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            DateTime moment = DateTime.Now;
  
            Client client = new Client(name, email, birthDate);
            Order order = new Order(moment, status, client) ;

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #"+i+" item data: ");
                Console.Write("Product name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture );
                Console.Write("Quantity: ");
                int quant = int.Parse(Console.ReadLine());
                Product product = new Product(nameProduct, price);
                OrderItem items = new OrderItem(quant, price, product);
                order.addItem(items);
            }
            Console.WriteLine();
            Console.WriteLine(order);
            Console.WriteLine("Total price: "+order.Total().ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
