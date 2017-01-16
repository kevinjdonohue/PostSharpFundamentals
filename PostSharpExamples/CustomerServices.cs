using System;
using System.Collections.Generic;
using PostSharpExamples.Aspects;

namespace PostSharpExamples
{
    public class CustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [Log]
        public bool Save(Customer customer)
        {
            Console.WriteLine("Customer is being saved.");

            return _customerRepository.Create(customer);
        }

        public IEnumerable<Customer> FetchAll()
        {
            return _customerRepository.ReadAll();
        }
    }
}
