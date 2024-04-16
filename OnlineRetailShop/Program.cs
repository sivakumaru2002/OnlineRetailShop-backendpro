using Microsoft.EntityFrameworkCore;
using OnlineRetailShop.Repository;
using OnlineRetailShop.Repository.Implementation;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Service.Implementation;
using OnlineRetailShop.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOriginPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ICartService, CartService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOriginPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
