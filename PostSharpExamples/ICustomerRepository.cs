using System.Collections.Generic;

namespace PostSharpExamples
{
    public interface ICustomerRepository
    {
        bool Create(Customer newCustomer);
        Customer Read(int customerId);
        IEnumerable<Customer> ReadAll();
        bool Update(int customerId, Customer customerToUpdate);
        bool Delete(Customer customerToDelete);
    }
}