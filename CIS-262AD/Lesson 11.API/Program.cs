using Lesson_11.DAL;
using System.Net.Http;
using System.Text.Json;
 
HttpClient client = new HttpClient();
 
// We want to make sure that we don't care about the case of the objects
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};

// We call the [HttpGet] method:
string response = await client.GetStringAsync("http://localhost:5228/api/customer");

// We transform or deserialize the object
IEnumerable<Customer> customers = JsonSerializer.Deserialize<IEnumerable<Customer>>(response, options);
 
// Now we look through the object.
foreach (Customer customer in customers)
{
    Console.WriteLine($"{customer.CustomerId} {customer.FirstName} {customer.LastName}");
}

Customer customerToPost = new Customer();
customerToPost.FirstName = "Test";
customerToPost.LastName = "Insert";
customerToPost.Country = "Test Country";
customerToPost.Email = "email@fakedomain.net";
 
// We need to Serialize or transform our customer object to JSON
string jsonToPost = JsonSerializer.Serialize(customerToPost);
 
// This is how we pass content to the web application. We make sure we tell it we are using json
HttpContent toPostContent = new StringContent(jsonToPost, System.Text.Encoding.UTF8, "application/json");
var postResult = await client.PostAsync("http://localhost:5228/api/customer", toPostContent);

// This is how we check to make sure it was successful
if(postResult.StatusCode == System.Net.HttpStatusCode.OK)
{
    Console.WriteLine("We successfully added the user!");
}
 
Customer customerToPut = new Customer();
customerToPut.FirstName = "Test";
customerToPut.LastName = "Update";
customerToPut.Country = "Test Country";
customerToPut.Email = "email@fakedomain.net";
customerToPut.CustomerId = 1;
 
string jsonToPut = JsonSerializer.Serialize(customerToPut);
 
HttpContent toPutContent = new StringContent(jsonToPut, System.Text.Encoding.UTF8, "application/json");
var putResult = await client.PutAsync("http://localhost:5228/api/customer", toPutContent);

// This is how we check to make sure it was successful
if(putResult.StatusCode == System.Net.HttpStatusCode.OK)
{
    Console.WriteLine("We successfully updated the user!");
}

var deleteResult = await client.DeleteAsync("http://localhost:5228/api/customer?id=66");
if (deleteResult.StatusCode == System.Net.HttpStatusCode.OK)
{
    Console.WriteLine("We successfully deleted the user!");
}