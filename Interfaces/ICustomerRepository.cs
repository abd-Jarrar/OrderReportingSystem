using Asal.OrderReportingSystem.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Asal.OrderReportingSystem.Interfaces
{
    public interface ICustomerRepository
    {
        public Customer? GetCustomerById(Guid CustomerId);

        public bool DeleteCustomer(Guid CustomerId);

        public List<Order> GetCustomerOrders(Guid CustomerId);

        public bool AddCustomer(string CustomerName, string CustomerEmail);

        public void DisplayCustomer(Guid CustomerId);

        public void DisplayCustomers(List<Customer> customers);

        public void DisplayAllCustomers();

    }
}
