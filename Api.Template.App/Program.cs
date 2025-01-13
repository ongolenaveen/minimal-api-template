using Api.Template.DI;
using Api.Template.Domain;
using Api.Template.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddWebAppBindings(builder.Configuration);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/customers", GetAllCustomers);

app.MapGet("/customers/{id}", GetCustomer);

app.MapPost("/customers", PostCustomer);

app.Run();


static async Task<IResult> GetAllCustomers(ICustomerService customerService)
{
    return TypedResults.Ok(await customerService.GetCustomers());
}

static async Task<IResult> GetCustomer(int id, ICustomerService customerService)
{
    return TypedResults.Ok(await customerService.GetCustomer(id));
}

static async Task<IResult> PostCustomer(Customer customer, ICustomerService customerService)
{
    await customerService.CreateCustomer(customer);
    return TypedResults.Created(new Uri("naveen.org"));
}