using System;

namespace Lesson_13.DAL;

public interface IReportAdapter
{
    public IEnumerable<Report> GetExamsByGrade();
}
