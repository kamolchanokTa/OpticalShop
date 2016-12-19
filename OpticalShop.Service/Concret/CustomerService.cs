using OpticalShop.Core.Domain;
using OpticalShop.Data;
using OpticalShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpticalShop.Service.Concret
{
    public class CustomerService : ICustomerService
    {
        private IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public IEnumerable<Customer>  GetCustomers()
        {
            var Customers = this._customerRepository.Table.ToList();
            if (Customers == null)
                throw new NullReferenceException("Cannot find any customer");
            return Customers;
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            if (this._customerRepository.Table.FirstOrDefault(m =>
                m.FirstName == customer.FirstName &&
                m.FamilyName == customer.FamilyName 
                ) != null)
                throw new ArgumentException("customer name : " + customer.FirstName + " " + customer.FamilyName  + " already exist");

            this._customerRepository.Insert(customer);
        }

        public void DeleteCustomer(string customerId)
        {
            var customer = this._customerRepository.GetById(customerId);
            if (customer == null)
                throw new NullReferenceException("Cannot delete customer id : " + customerId);

            //string cacheKey = string.Format(CACHE_KEY_MACHINE, machineId);

            //_cacheManager.Remove(cacheKey);
            this._customerRepository.Delete(customer);
        }
    }
}
