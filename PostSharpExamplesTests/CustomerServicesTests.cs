using System;
using System.Collections.Generic;
using FluentAssertions;
using Ploeh.AutoFixture;
using PostSharpExamples;
using Xunit;

namespace PostSharpExamplesTests
{
    public class CustomerServicesTests : IDisposable
    {
        private Fixture _fixture;

        public CustomerServicesTests()
        {
            _fixture = new Fixture();
        }

        public void Dispose()
        {
            _fixture = null;
        }

        [Fact]
        public void WhenSaveIsCalled_ThenLogAspectShouldFire_OnEntry_OnSuccess_OnExit()
        {
            //arrange
            ICustomerRepository customerRepository = new CustomerRepository();
            CustomerServices customerServices = new CustomerServices(customerRepository);
            Customer customer = _fixture.Create<Customer>();
            Queue<string> expectedMessages = new Queue<string>();
            expectedMessages.Enqueue("PostSharpExamples.Save OnEntry");
            expectedMessages.Enqueue("PostSharpExamples.Save OnSuccess returns True");
            expectedMessages.Enqueue("PostSharpExamples.Save OnExit");

            //act
            bool result = customerServices.Save(customer);

            //assert
            result.Should().BeTrue();
            Logger.Messages.Should().HaveCount(3, "we added three messages to the logger from the Log Aspect's point cuts, OnEntry, OnSuccess, and OnExit methods.");
            Logger.Messages.ShouldBeEquivalentTo(expectedMessages, options => options.WithStrictOrdering(), "the messages should be in expected order: OnEntry, OnSuccess, OnExit.");
            Customer storedCustomer = customerRepository.Read(customer.CustomerId);
            storedCustomer.Should().Be(customer);
        }
    }
}
