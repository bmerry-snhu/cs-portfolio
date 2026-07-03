using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Lesson_10.DAL;

public class CustomerAdapter : ICustomerAdapter
{
    private string connectionString = @"Data Source=../Lesson 10/Chinook_Sqlite_AutoIncrementPKs.sqlite";
    public IEnumerable<Customer> GetAllCustomers()
    {
        string sql = "SELECT CustomerId, FirstName, LastName, Country, Email FROM Customer";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Customer>(sql);
        }
    }
    public Customer GetCustomerById(int id)
    {
        string sql = @"SELECT CustomerId, FirstName, LastName, Country, Email FROM Customer WHERE CustomerId = @CustomerId";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.QueryFirst<Customer>(sql, new { CustomerId = id});
        }
    }
    public bool InsertCustomer(Customer customer)
    {
        string sql = @"INSERT INTO Customer (FirstName, LastName, Country, Email) VALUES (@FirstName, @LastName, @Country, @Email)";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, customer);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool UpdateCustomer(Customer customer)
    {
        string sql = @"UPDATE Customer SET FirstName = @FirstName, LastName = @LastName WHERE CustomerId = @CustomerId";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, customer);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool DeleteCustomerById(int id)
    {
        string sql = "DELETE FROM Customer WHERE CustomerId = @CustomerId";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, new { CustomerId = id});
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
