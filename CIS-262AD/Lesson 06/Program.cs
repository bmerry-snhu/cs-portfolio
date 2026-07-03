using Lesson_06.DAL;

CustomerAdapter customerAdapter = new CustomerAdapter();
IEnumerable<Customer> customers = customerAdapter.GetAll();
 
foreach(Customer customer in customers)
{
    Console.WriteLine($"CustomerId: {customer.CustomerId} FirstName: {customer.FirstName} LastName: {customer.LastName} Country: {customer.Country} Email: {customer.Email}");
}

InvoiceAdapter invoiceAdapter = new InvoiceAdapter();
IEnumerable<Invoice> invoices = invoiceAdapter.GetAll();

foreach(Invoice invoice in invoices)
{
    Console.WriteLine($"InvoiceId: {invoice.InvoiceId} CustomerId: {invoice.CustomerId} InvoiceDate: {invoice.InvoiceDate:MM/dd/yyyy} Total: ${invoice.Total:0.00}");
}