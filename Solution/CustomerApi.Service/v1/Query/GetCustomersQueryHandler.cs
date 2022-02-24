using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CustomerApi.Data.Entities;
using CustomerApi.Data.Repository.v1;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Service.v1.Query
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomersQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll().ToListAsync(cancellationToken: cancellationToken);
        }
    }
}