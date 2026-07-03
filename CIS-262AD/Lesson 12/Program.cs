using Lesson_12.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add Support for Web API Controllers
builder.Services.AddControllers();

// Add Dependency Injection
builder.Services.AddTransient<ICustomerAdapter, CustomerAdapter>();
builder.Services.AddTransient<IInvoiceAdapter, InvoiceAdapter>();
builder.Services.AddTransient<IReportAdapter, ReportAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

// Set up mapping for Web API
app.MapControllers();

app.Run();
