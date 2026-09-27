using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("50 N Temple", "Salt Lake City", "Utah", "USA");
        Customer customer1 = new Customer("James Brooks", address1);
        Order order1 = new Order(customer1);
        Product product1 = new Product("Jacket", "0001", 75.00, 2);
        Product product2 = new Product("Backpack", "0002", 45.00, 1);
        Product product3 = new Product("Notebook", "0003", 8.50, 4);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Address address2 = new Address("123 King Street", "Toronto", "Ontario", "Canada");
        Customer customer2 = new Customer("Mark Vance", address2);
        Order order2 = new Order(customer2);
        Product product4 = new Product("Phone", "0004", 750.00, 1);
        Product product5 = new Product("Phone Case", "0005", 15.50, 3);
        Product product6 = new Product("Headphones", "0006", 65.00, 1);
        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);

        Console.WriteLine("[ORDER 1]");
        Console.WriteLine("");

        Console.WriteLine("- PACKING LABEL -");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("- SHIPPING LABEL -");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("");

        Console.WriteLine($"--- TOTAL PRICE: ${order1.CalculateTotalPrice():F2} ---");

        Console.WriteLine("");
        Console.WriteLine("-----------------------");
        Console.WriteLine("");

        Console.WriteLine("[ORDER 2]");
        Console.WriteLine("");

        Console.WriteLine("- PACKING LABEL -");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("- SHIPPING LABEL -");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("");

        Console.WriteLine($"--- TOTAL PRICE: ${order2.CalculateTotalPrice():F2} ---");
    }
}