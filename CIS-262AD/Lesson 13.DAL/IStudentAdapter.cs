using System;

namespace Lesson_13.DAL;

public interface IStudentAdapter
{
    public IEnumerable<Student> GetAllStudents();
    public Student GetStudentById(int id);
    public bool InsertStudent(Student student);
    public bool UpdateStudent(Student student);
    public bool DeleteStudentById(int id);
}
