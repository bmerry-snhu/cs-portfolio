using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Lesson_11.DAL;

public class InvoiceAdapter : IInvoiceAdapter
{
    private string connectionString = @"Data Source=../Lesson 11/Chinook_Sqlite_AutoIncrementPKs.sqlite";
    public IEnumerable<Invoice> GetAllInvoices()
    {
        string sql = "SELECT InvoiceId, CustomerId, InvoiceDate, CAST(Total AS REAL) AS Total FROM Invoice";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Invoice>(sql);
        }
    }
    public Invoice GetInvoiceById(int id)
    {
        string sql = @"SELECT InvoiceId, CustomerId, InvoiceDate, CAST(Total AS REAL) AS Total FROM Invoice WHERE InvoiceId = @InvoiceId";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.QueryFirst<Invoice>(sql, new { InvoiceId = id});
        }
    }
    public IEnumerable<Invoice> GetInvoiceByCustomerId(int customerId)
    {
        string sql = @"SELECT InvoiceId, CustomerId, InvoiceDate, CAST(Total AS REAL) AS Total FROM Invoice WHERE CustomerId = @CustomerId";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Invoice>(sql, new { CustomerId = customerId});
        }
    }
    public bool InsertInvoice(Invoice invoice)
    {
        string sql = @"INSERT INTO Invoice (CustomerId, InvoiceDate, Total) VALUES (@CustomerId, @InvoiceDate, @Total)";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, invoice);
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
    public bool UpdateInvoice(Invoice invoice)
    {
        string sql = @"UPDATE Invoice SET CustomerId = @CustomerId, InvoiceDate = @InvoiceDate, Total = @Total WHERE InvoiceId = @InvoiceId";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, invoice);
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
    public bool DeleteInvoiceById(int id)
    {
        string sql = "DELETE FROM Invoice WHERE InvoiceId = @InvoiceId";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, new { InvoiceId = id});
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
