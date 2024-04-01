using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice01.Data;
using Practice01.Models;

namespace Practice01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CustomerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            _dataContext.Customer.Add(customer);
            await _dataContext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var Customers = await _dataContext.Customer.ToListAsync();
            return Ok(Customers);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customerData)
        {
            var customer = await _dataContext.Customer.FindAsync(customerData.UserId);
            if (customer == null)
            {
                return NotFound("Not found Customer");
            }

            customer.Username = customerData.Username;
            customer.Email = customerData.Email;
            customer.FirstName = customerData.FirstName;
            customer.LastName = customerData.LastName;
            customer.CreatedOn = customerData.CreatedOn;
            customer.IsActive = customerData.IsActive;

            await _dataContext.SaveChangesAsync();
            return Ok(customer);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _dataContext.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound("Not Found Customer");
            }

            _dataContext.Customer.Remove(customer);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Customer.ToListAsync());
        }

        [HttpGet("{id}/orders")]
        public async Task<IActionResult> GetActiveOrderByCustomer(Guid id)
        {
            var customerOrders = _dataContext.Order
                .Where(o => o.OrderBy == id && o.IsActive)
                .ToList();

            if (customerOrders == null)
            {
                return NotFound();
            }
            return Ok(customerOrders);
        }

        



    }
}
