using Asal.OrderReportingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.OrderReportingSystem.Utilities
{
    public class MyUtilities
    {
        public static bool GetSortType()
        {
            while (true)
            {
                Console.WriteLine("[1] Ascending");
                Console.WriteLine("[2] Descending");
                Console.Write("Choose: ");

                var choice = Console.ReadLine();

                if (choice == "1")
                    return true;

                if (choice == "2")
                    return false;

                Console.WriteLine("Invalid choice. Please choose 1 or 2.");
            }
        }


        public static Guid ReadGuid(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (Guid.TryParse(input, out Guid id))
                    return id;

                Console.WriteLine("Invalid GUID. Please try again.");
            }
        }

        public static decimal ReadPositiveAmount(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal amount) && amount > 0)
                    return amount;

                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }
        }

        public static DateTime ReadDate(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime date))
                    return date;

                Console.WriteLine("Invalid date. Please try again.");
            }
        }

        public static void PrintCustomerOrdersTotalAmount(Customer customer,decimal totalAmount)
        {
            Console.WriteLine(
                $"Customer Name: {customer.CustomerName} | " +
                $"Customer ID: {customer.CustomerId} | " +
                $"Total Amount: {totalAmount}"

            );
            Console.WriteLine(new string('-', 50));
        }

        public static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"Customer Name : {customer.CustomerName}");
            Console.WriteLine($"Customer ID   : {customer.CustomerId}");
            Console.WriteLine(new string('-', 40));
        }

        public static void PrintOrder(Order order)
        {
            Console.WriteLine($"Order ID: {order.OrderId}");
            Console.WriteLine($"Customer: {order.Customer.CustomerName}");
            Console.WriteLine($"Total Amount: {order.OrderTotalAmount:C}");
            Console.WriteLine($"Status: {order.OrderStatus}");
            Console.WriteLine($"Created Date: {order.CreatedDate}");
        }

        
    }
}
