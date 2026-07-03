using System;

namespace Lesson_13.DAL;

public interface ITeacherAdapter
{
    public IEnumerable<Teacher> GetAllTeachers();
    public Teacher GetTeacherById(int id);
    public bool InsertTeacher(Teacher teacher);
    public bool UpdateTeacher(Teacher teacher);
    public bool DeleteTeacherById(int id);
}
