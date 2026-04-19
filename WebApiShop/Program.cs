using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;
using Repository;
using Service;
using WebApiShop;
using WebApiShop.middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
builder.Services.AddScoped < IuserRepositories, userRepositories>();
builder.Services.AddScoped <IProductRepositories, ProductRepositories>();
builder.Services.AddScoped<IOrderRepositories, OrderRepositories>();
builder.Services.AddScoped<IcategoryRepositories, categoryRepositories>();

builder.Services.AddScoped<IuserServices, userServices>();
builder.Services.AddScoped<IpasswordServic ,passwordServic>();
builder.Services.AddScoped<IOrderServices , OrderServices>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IratingRepository, ratingRepository>();

builder.Services.AddDbContext<WebApiShopDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("home")));


// Add services to the container.
builder.Host.UseNLog();
//builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRatingMiddleware();

app.UseErrorMiddleware();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
