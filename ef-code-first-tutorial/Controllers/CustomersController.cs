using ef_code_first_tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_code_first_tutorial.Controllers
{
    public class CustomersController
    {
        private readonly SalesDbContext _context;
        public CustomersController() {
            _context = new SalesDbContext();        
        }
        public async Task<ICollection<Customer>> GetCustomers()
        {
            return await _context.Customers
                                    .ToListAsync();
        }
        public async Task<Customer?> GetCustomer(int id)
        {
            return await _context.Customers
                                    .FindAsync(id);
        }
        public async Task<Customer?> GetCustomerWithOrders(int id)
        {
            return await _context.Customers
                                    .Include(x => x.Orders)
                                        .ThenInclude(x => x.Orderlines)
                                            .ThenInclude(x => x.Item)
                                    .SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Customer> InsertCustomer(Customer c)
        {
            _context.Customers.Add(c);
            var changes = await _context.SaveChangesAsync();
            if(changes != 1)
            {
                throw new Exception("Insert Customer Method failed! Sorry :(");
            }
            return c;
        }
        public async Task UpdateCustomer(int id, Customer c)
        {
            if (id != c.Id)
            {
                throw new Exception("Id doesn't match");
            }
            _context.Entry(c).State = EntityState.Modified;
            var changes = await _context.SaveChangesAsync();
            if (changes != 1)
            {
                throw new Exception("Update failed homie");
            }
        }
            public async Task DeleteCustomer(int id)
            {
                var c = await GetCustomer(id);
                if(c is null)
                {
                    throw new Exception("Not found! Tartar Sauce");
                }
                _context.Customers.Remove(c);
                var changes = await _context.SaveChangesAsync();
                if(changes != 1)
                {
                    throw new Exception("Delete Failed! Tartar Sauce");
                }
            }
        
    }
}
