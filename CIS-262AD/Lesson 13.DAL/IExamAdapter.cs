using System;

namespace Lesson_13.DAL;

public interface IExamAdapter
{
    public IEnumerable<Exam> GetAllExams();
    public Exam GetExamById(int id);
    public IEnumerable<Exam> GetExamByStudentId(int id);
    public bool InsertExam(Exam exam);
    public bool UpdateExam(Exam exam);
    public bool DeleteExamById(int id);
}
