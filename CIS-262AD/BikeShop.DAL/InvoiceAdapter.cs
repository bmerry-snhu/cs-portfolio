using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace BikeShop.DAL;

public class InvoiceAdapter : IInvoiceAdapter
{
    private string connectionString = @"Data Source=../BikeShop/BikeShop.db";
    public IEnumerable<Invoice> GetAllInvoices()
    {
        string sql = "SELECT InvoiceId, CustomerId, CAST(Amount AS REAL) AS Amount, InvoiceDate FROM Invoice";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Invoice>(sql);
        }
    }
    public Invoice GetInvoiceById(int id)
    {
        string sql = @"SELECT InvoiceId, CustomerId, CAST(Amount AS REAL) AS Amount, InvoiceDate FROM Invoice WHERE InvoiceId = @InvoiceId";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.QueryFirst<Invoice>(sql, new { InvoiceId = id});
        }
    }
    public IEnumerable<Invoice> GetInvoiceByCustomerId(int customerId)
    {
        string sql = @"SELECT InvoiceId, CustomerId, CAST(Amount AS REAL) AS Amount, InvoiceDate FROM Invoice WHERE CustomerId = @CustomerId";
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Invoice>(sql, new { CustomerId = customerId});
        }
    }
    public bool InsertInvoice(Invoice invoice)
    {
        string sql = @"INSERT INTO Invoice (CustomerId, InvoiceDate, Amount) VALUES (@CustomerId, @InvoiceDate, @Amount)";
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
        string sql = @"UPDATE Invoice SET CustomerId = @CustomerId, InvoiceDate = @InvoiceDate, Amount = @Amount WHERE InvoiceId = @InvoiceId";
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
