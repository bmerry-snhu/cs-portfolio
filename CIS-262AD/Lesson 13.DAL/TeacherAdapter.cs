using System;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Lesson_13.DAL;

public class TeacherAdapter : ITeacherAdapter
{
    private string connectionString = @"Data Source=../Lesson 13/School.db";
    public IEnumerable<Teacher> GetAllTeachers()
    {
        string sql = "SELECT TeacherId, FirstName, LastName FROM Teacher";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.Query<Teacher>(sql);
        }
    }
    public Teacher GetTeacherById(int id)
    {
        string sql = @"SELECT TeacherId, FirstName, LastName FROM Teacher WHERE TeacherId = @TeacherId";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            return connection.QueryFirst<Teacher>(sql, new { TeacherId = id });
        }
    }
    public bool InsertTeacher(Teacher teacher)
    {
        string sql = @"INSERT INTO Teacher (FirstName, LastName) VALUES (@FirstName, @LastName)";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, teacher);
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
    public bool UpdateTeacher(Teacher teacher)
    {
        string sql = @"UPDATE Teacher SET FirstName = @FirstName, LastName = @LastName WHERE TeacherId = @TeacherId";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, teacher);
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
    public bool DeleteTeacherById(int id)
    {
        string sql = @"DELETE FROM Teacher WHERE TeacherId = @TeacherId";
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            int rowsAffected = connection.Execute(sql, new { TeacherId = id});
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
