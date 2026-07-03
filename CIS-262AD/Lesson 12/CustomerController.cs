using Microsoft.AspNetCore.Mvc;
using Lesson_12.DAL;

namespace Lesson_12
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerAdapter _customerAdapter;
        public CustomerController(ICustomerAdapter customerAdapter)
        {
            _customerAdapter = customerAdapter;
        }
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerAdapter.GetAllCustomers();
        }
        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
            bool isSuccess = _customerAdapter.InsertCustomer(customer);

            if(isSuccess)
            {
                return Ok(customer);
            }
            else
            {
                throw new Exception("Error inserting customer.");
            }
        }
        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            bool isSuccess = _customerAdapter.UpdateCustomer(customer);

            if(isSuccess)
            {
                return Ok(customer);
            }
            else
            {
                throw new Exception("Error updating customer.");
            }
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            bool isSuccess = _customerAdapter.DeleteCustomerById(id);

            if(isSuccess)
            {
                return Ok();
            }
            else
            {
                throw new Exception("Error deleting customer.");
            }
        }
    }
}
