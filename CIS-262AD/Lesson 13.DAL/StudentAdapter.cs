using System;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Lesson_13.DAL;

public class StudentAdapter : IStudentAdapter
{
    private string connectionString = @"Data Source=../Lesson 13/School.db";
    public IEnumerable<Student> GetAllStudents()
    {
        string sql = "SELECT StudentId, FirstName, LastName FROM Student";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Student>(sql);
        }
    }
    public Student GetStudentById(int id)
    {
        string sql = @"SELECT StudentId, FirstName, LastName FROM Student WHERE StudentId = @StudentId";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.QueryFirst<Student>(sql, new { StudentId = id });
        }
    }
    public bool InsertStudent(Student student)
    {
        string sql = @"INSERT INTO Student (FirstName, LastName) VALUES (@FirstName, @LastName)";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, student);
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
    public bool UpdateStudent(Student student)
    {
        string sql = @"UPDATE Student SET FirstName = @FirstName, LastName = @LastName WHERE StudentId = @StudentId";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, student);
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
    public bool DeleteStudentById(int id)
    {
        string sql = @"DELETE FROM Student WHERE StudentId = @StudentId";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, new { StudentId = id});
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
