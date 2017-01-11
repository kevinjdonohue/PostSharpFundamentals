using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharpExamples.Aspects;

namespace PostSharpExamples
{
    public class CustomerServices
    {
        [Log]
        public bool Save(Customer customer)
        {
            Console.WriteLine("Customer is being saved.");
            return true;
        }

        public IEnumerable<Customer> FetchAll()
        {
            throw new ApplicationException("We failed to fetch.");
        }
    }
}
