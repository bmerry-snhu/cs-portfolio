using System;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Lesson_13.DAL;

public class ExamAdapter : IExamAdapter
{
    private string connectionString = @"Data Source=../Lesson 13/School.db";
    public IEnumerable<Exam> GetAllExams()
    {
        string sql = "SELECT ExamId, StudentId, Score FROM Exam";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Exam>(sql);
        }
    }
    public Exam GetExamById(int id)
    {
        string sql = @"SELECT ExamId, StudentId, Score FROM Exam WHERE ExamId = @ExamId";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.QueryFirst<Exam>(sql, new { ExamId = id });
        }
    }
    public IEnumerable<Exam> GetExamByStudentId(int id)
    {
        string sql = @"SELECT ExamId, StudentId, Score FROM Exam WHERE StudentId = @StudentId";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Exam>(sql, new { StudentId = id });
        }
    }
    public bool InsertExam(Exam exam)
    {
        string sql = @"INSERT INTO Exam (StudentId, Score) VALUES (@StudentId, @Score)";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, exam);
            if(rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool UpdateExam(Exam exam)
    {
        string sql = @"UPDATE Exam SET StudentId = @StudentId, Score = @Score WHERE ExamId = @ExamId";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, exam);
            if(rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public bool DeleteExamById(int id)
    {
        string sql = @"DELETE FROM Exam WHERE ExamId = @ExamId";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, new { ExamId = id});
            if(rowsAffected > 0)
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
