using Api.Template.DI;
using Api.Template.Domain;
using Api.Template.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddWebAppBindings(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
var app = builder.Build();
app.MapOpenApi();

app.MapGet("/", () => "Hello World!")
    .WithTags("customers")
    .WithSummary("This is a summary.")
    .WithDescription("This is a description.");

app.MapGet("/customers", GetAllCustomers)
    .WithTags("customers")
    .WithSummary("This is a customers.")
    .WithDescription("This is a customers.")
    .Produces<List<Customer>>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);

app.MapGet("/customers/{id}", GetCustomer)
    .WithTags("customers")
    .WithSummary("This is a customer.")
    .WithDescription("This is a customer.")
    .Produces<Customer>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);

app.MapPost("/customers", PostCustomer)
    .WithTags("customers")
    .WithSummary("This is a create customers.")
    .WithDescription("This is create customers.")
    .Produces(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status404NotFound);

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