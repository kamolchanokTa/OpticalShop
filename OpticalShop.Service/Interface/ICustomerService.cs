using OpticalShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Service.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();

        void AddCustomer(Customer customer);

        void DeleteCustomer(string customerId);
    }
}
