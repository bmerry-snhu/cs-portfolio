using BikeShop.DAL;
using System.Net.Http;
using System.Text.Json;

HttpClient client = new HttpClient();

// We want to make sure that we don't care about the case of the objects
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};

Customer customerToPut = new Customer();
customerToPut.FirstName = "Test";
customerToPut.LastName = "Update";
customerToPut.CustomerId = 1;
 
string jsonToPut = JsonSerializer.Serialize(customerToPut);
 
HttpContent content = new StringContent(jsonToPut, System.Text.Encoding.UTF8, "application/json");
var result = await client.PutAsync("http://localhost:5294/api/customer", content);

// This is how we check to make sure it was successful
if(result.StatusCode == System.Net.HttpStatusCode.OK)
{
    Console.WriteLine("We successfully updated the user!");
}
 
Console.ReadLine();