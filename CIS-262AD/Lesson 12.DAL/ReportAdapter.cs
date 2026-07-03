using Dapper;
using Microsoft.Data.Sqlite;

namespace Lesson_12.DAL;

public class ReportAdapter : IReportAdapter
{
    private string connectionString = @"Data Source=../Lesson 12/Chinook_Sqlite_AutoIncrementPKs.sqlite";
    public IEnumerable<Report> GetSalesByCountry()
    {
        string sql = @"SELECT Customer.Country, SUM(Invoice.Total) AS 'Total' 
            FROM Invoice 
            INNER JOIN CUSTOMER ON Invoice.CustomerId = Customer.CustomerId 
            GROUP BY Customer.Country";
        
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Report>(sql);
        }
    }
}
