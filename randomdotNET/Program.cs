using randomdotNET.Repository;
using randomdotNET.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExampleService, ExampleService>();
builder.Services.AddSingleton<CustomerRepository>();
builder.Services.AddSingleton<CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/example", (IExampleService exampleService) => exampleService.GetExample());

app.MapGet("/customer", (CustomerService customerService) => customerService.GetCustomerById(1));

app.Run();