namespace Lesson_12.DAL;

public interface IInvoiceAdapter
{
    IEnumerable<Invoice> GetAllInvoices();
    Invoice GetInvoiceById(int id);
    IEnumerable<Invoice> GetInvoiceByCustomerId(int customerId);
    bool InsertInvoice(Invoice invoice);
    bool UpdateInvoice(Invoice invoice);
    bool DeleteInvoiceById(int id);
}
