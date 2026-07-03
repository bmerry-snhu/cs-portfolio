namespace Lesson_11.DAL;

public interface ICustomerAdapter
{
    Customer GetCustomerById(int id);
    IEnumerable<Customer> GetAllCustomers();
    bool InsertCustomer(Customer customer);
    bool UpdateCustomer(Customer customer);
    bool DeleteCustomerById(int id);
}
