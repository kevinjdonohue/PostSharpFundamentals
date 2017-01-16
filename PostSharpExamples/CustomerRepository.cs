using System.Collections.Generic;
using System.Linq;

namespace PostSharpExamples
{
    public class CustomerRepository : ICustomerRepository
    {
        private IList<Customer> _customers;

        public IList<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }

        public CustomerRepository()
        {
            _customers = new List<Customer>();
        }

        public bool Create(Customer newCustomer)
        {
            _customers.Add(newCustomer);

            return true;
        }

        public Customer Read(int customerId)
        {
            Customer existingCustomer = GetExistingCustomer(customerId);

            return existingCustomer;
        }

        public IEnumerable<Customer> ReadAll()
        {
            return _customers;
        }

        public bool Update(int customerId, Customer customerToUpdate)
        {
            Customer existingCustomer = GetExistingCustomer(customerId);

            if (existingCustomer == null) return false;

            _customers.Remove(existingCustomer);
            _customers.Add(customerToUpdate);

            return true;
        }

        public bool Delete(Customer customerToDelete)
        {
            _customers.Remove(customerToDelete);

            return true;
        }

        private Customer GetExistingCustomer(int customerId)
        {
            return _customers.FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}