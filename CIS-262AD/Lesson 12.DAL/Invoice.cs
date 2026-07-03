namespace Lesson_12.DAL;

public class Invoice
{
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal Total { get; set; }
}
