using System.Collections.Generic;
using FluentAssertions;
using PostSharpExamples;
using Xunit;
using Xunit.Abstractions;

namespace PostSharpExamplesTests
{
    public class CustomerServicesTests
    {
        private ITestOutputHelper _output;

        public CustomerServicesTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void WhenSaveIsCalled_ThenLogAspectShouldFire_OnEntry_OnSuccess_OnExit()
        {
            //arrange
            CustomerServices customerServices = new CustomerServices();
            Customer customer = new Customer();
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
        }
    }
}
