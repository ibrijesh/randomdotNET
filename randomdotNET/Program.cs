using randomdotNET.FactoryPattern;
using randomdotNET.Repository;
using randomdotNET.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.CodeAnalysis.Options;
using randomdotNET.AuthenticationAndAuthorization.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExampleService, ExampleService>();
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddSingleton<ICustomerService, CustomerService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<IProductService, ProductService>();


// Authentication Services 
builder.Services.AddScoped<TokenService>();


// Notification Services

// Register notifiers
builder.Services.AddScoped<EmailNotifier>();
builder.Services.AddScoped<SmsNotifier>();

// Register the factory
builder.Services.AddScoped<INotifierFactory, NotifierFactory>();


builder.Services.AddControllers();

// configure CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
    

// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,    // validate the token issuer 
            ValidateAudience = true,  // validate the token audience
            ValidateLifetime = true,  // Ensure token is not expired
            ValidateIssuerSigningKey = true, // Validate the signing key
            
            ValidIssuer = jwtSettings.GetValue<string>("Issuer"),    // Issuer must match
            ValidAudience = jwtSettings.GetValue<string>("Audience"),  // // Audience must match
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetValue<string>("Key"))) // Secret key
        };
    });

var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/example", (IExampleService exampleService) => exampleService.GetExample());

app.MapGet("/customer", (ICustomerService customerService) => customerService.GetCustomerById(1));

app.MapControllers();
app.UseCors("AllowSpecificOrigins");


// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseAuthorization();

app.Run();