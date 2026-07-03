using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Lesson_06.DAL;

public class CustomerAdapter
{
    private string connectionString = @"Data Source=../Lesson 06/Chinook_Sqlite_AutoIncrementPKs.sqlite";
    public IEnumerable<Customer> GetAll()
    {
        string sql = "SELECT CustomerId, FirstName, LastName, Country, Email FROM Customer";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Customer>(sql);
        }
    }
    public Customer GetById(int id)
    {
        string sql = @"SELECT CustomerId, FirstName, LastName, Country, Email FROM Customer WHERE CustomerId = @CustomerId";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.QueryFirst<Customer>(sql, new { CustomerId = id});
        }
    }
}
