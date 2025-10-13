using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.CustomerAPI.Data;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Services.CustomerAPI.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _context;
    public CustomerRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        var customers = await _context.Customers.ToListAsync();
        return customers;
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        return customer;
    }
}
