using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDbContextFactory<OMAContext> _ctx;
        public CustomerService(IDbContextFactory<OMAContext> ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Customer> GetCustomersAndOrders()
        {
            var context = _ctx.CreateDbContext();
            context.Database.EnsureCreated();
            return context.Customers
                   .Where(c => !c.IsDeleted)
                   .Include(c => c.Orders)
                   .Include(o => o.Address);
        }
    }
}