using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineRetailshop.Filter;
using OnlineRetailShop.MiddleWare;
using OnlineRetailShop.Repository;
using OnlineRetailShop.Repository.Implementation;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Service.Implementation;
using OnlineRetailShop.Service.Interface;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("V1", new OpenApiInfo { Title = "RetailShop", Version = "V1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new String[]{}
        }

    });
});
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!))
    };
});

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
builder.Services.AddTransient<IAuthenticationRespository, AuthenticationRepository>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IUserCheckService, UserCheckService>();
builder.Services.AddTransient<IAuthenticationServices, AuthenticationServices>();
builder.Services.AddScoped<AuthorizationFilter>();
builder.Services.AddTransient<AuthorizationMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/V1/swagger.json", "RetailShop V1"));
}
app.UseCors("AllowAnyOriginPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await next(context);
});
app.useAuthorizationMiddleWare();
//UserID
//61A6CB32-DCC4-464C-BBA9-8E85F0D10113
//Token
//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiU3JpbmlkaGkiLCJzdWIiOiJwYXNzd29yZCIsIlVzZXJJZCI6IjYxYTZjYjMyLWRjYzQtNDY0Yy1iYmE5LThlODVmMGQxMDExMyIsImp0aSI6IjIyNDQ3YzZlLWFiZTktNGM0ZS1iNGY5LThjNDRiZWExZmVkMiIsImV4cCI6MTcxNDcyNzA5NywiaXNzIjoiaHR0cHM6Ly9Qcm9JbmRpYS5jb20iLCJhdWQiOiJodHRwczovL1Byb0luZGlhLmNvbSJ9.BO0QKe8DpVla2MuaDB4fj8h2AyI1xbmQU2mKSCqReHY
app.MapControllers();
app.Run();
