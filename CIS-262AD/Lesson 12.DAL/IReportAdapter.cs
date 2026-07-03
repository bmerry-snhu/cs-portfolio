namespace Lesson_12.DAL;

public interface IReportAdapter
{
    IEnumerable<Report> GetSalesByCountry();
}
