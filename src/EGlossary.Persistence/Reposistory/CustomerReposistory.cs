using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using EGlossary.Persistence.DataModels;
using EGlossary.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGlossary.Persistence.Reposistory
{
    public class CustomerReposistory : ICustomerReposistory
    {
        private readonly InMemoryDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerReposistory(InMemoryDbContext inMemoryDbContext, IMapper mapper)
        {
            _dbContext = inMemoryDbContext;
            _mapper = mapper;
        }

        public async Task<int> CreateCustomer(CustomerEntity customer)
        {
            var customerDataModel = _mapper.Map<CustomerDataModel>(customer);
            customer.CreatedDate = DateTime.Now;
            _dbContext.Customer.AddRange(customerDataModel);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerEntity>> GetCustomers()
        {
            _ = GetCustmoreInMemory();
            var Customers = await _dbContext.Customer.ToListAsync();
            return _mapper.Map<IEnumerable<CustomerEntity>>(Customers);
        }

        public async Task<CustomerEntity> GetCustomerById(int Id)
        {
            _ = GetCustmoreInMemory();
            var Customer = await _dbContext.Customer.Where(p => p.Id == Id).FirstOrDefaultAsync();

            return _mapper.Map<CustomerEntity>(Customer);
        }

        public async Task<bool> DeleteCustomer(int Id)
        {
            _ = GetCustmoreInMemory();
            var customer = await _dbContext.Customer.Where(p => p.Id == Id).FirstOrDefaultAsync();
            if (customer != null)
            {
                _dbContext.Customer.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else { return false; }
        }

        public async Task GetCustmoreInMemory()
        {
            await CustomerSeedData.Seed(_dbContext).ConfigureAwait(false);
        }
    }
}