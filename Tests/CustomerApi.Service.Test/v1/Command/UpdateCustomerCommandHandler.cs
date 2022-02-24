﻿using CustomerApi.Data.Entities;
using CustomerApi.Data.Repository.v1;
using CustomerApi.Service.v1.Command;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace CustomerApi.Service.Test.v1.Command
{
    public class UpdateCustomerCommandHandlerTests
    {
        private readonly UpdateCustomerCommandHandler _testee;
        private readonly IRepository<Customer> _repository;
        private readonly Customer _customer;

        public UpdateCustomerCommandHandlerTests()
        {
            _repository = A.Fake<IRepository<Customer>>();
            _testee = new UpdateCustomerCommandHandler(_repository);

            _customer = new Customer
            {
                FirstName = "Yoda"
            };
        }
       
        [Fact]
        public async void Handle_ShouldReturnUpdatedCustomer()
        {
            A.CallTo(() => _repository.UpdateAsync(A<Customer>._)).Returns(_customer);

            var result = await _testee.Handle(new UpdateCustomerCommand(), default);

            result.Should().BeOfType<Customer>();
            result.FirstName.Should().Be(_customer.FirstName);
        }

        [Fact]
        public async void Handle_ShouldUpdateAsync()
        {
            await _testee.Handle(new UpdateCustomerCommand(), default);

            A.CallTo(() => _repository.UpdateAsync(A<Customer>._)).MustHaveHappenedOnceExactly();
        }
    }
}