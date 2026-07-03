using Lesson_07.DAL;

Console.WriteLine("Insert a new row in the database by answering the following prompts:");
Console.Write("First Name: ");
string? firstName = Console.ReadLine();
Console.Write("Last Name: ");
string? lastName = Console.ReadLine();
Console.Write("Country: ");
string? country = Console.ReadLine();
Console.Write("Email: ");
string? email = Console.ReadLine();

Customer customer = new Customer();
customer.FirstName = firstName;
customer.LastName = lastName;
customer.Country = country;
customer.Email = email;

CustomerAdapter customerAdapter = new CustomerAdapter();

bool isSuccessful = customerAdapter.InsertCustomer(customer);

string result = isSuccessful ? "succeeded" : "failed";

Console.WriteLine($"Inserting the record {result}.");