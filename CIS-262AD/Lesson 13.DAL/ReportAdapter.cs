using System;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Lesson_13.DAL;

public class ReportAdapter : IReportAdapter
{
    private string connectionString = @"Data Source=../Lesson 13/School.db";
    public IEnumerable<Report> GetExamsByGrade()
    {
        string sql = @"
            SELECT
                CASE
                    WHEN Score BETWEEN 90 AND 100 THEN 'A'
                    WHEN Score BETWEEN 80 AND 89 THEN 'B'
                    WHEN Score BETWEEN 70 AND 79 THEN 'C'
                    WHEN Score BETWEEN 60 AND 69 THEN 'D'
                    ELSE 'F'
                END AS LetterGrade,
                COUNT(*) AS NumberOfExams
            FROM Exam
            GROUP BY
                CASE
                    WHEN Score BETWEEN 90 AND 100 THEN 'A'
                    WHEN Score BETWEEN 80 AND 89 THEN 'B'
                    WHEN Score BETWEEN 70 AND 79 THEN 'C'
                    WHEN Score BETWEEN 60 AND 69 THEN 'D'
                    ELSE 'F'
                END
            ORDER BY LetterGrade";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Report>(sql);
        }
    }
}
