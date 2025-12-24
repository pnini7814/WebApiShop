using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped < IuserRepositories, userRepositories>();
builder.Services.AddScoped<IuserServices, userServices>();
builder.Services.AddScoped<IpasswordServic ,passwordServic>();
builder.Services.AddDbContext<WebApiShopDBContext>(options => options.UseSqlServer(
    "Data Source = srv2\\pupils; Initial Catalog = WebApiShopDB; Integrated Security = True; Trust Server Certificate=True; Pooling=false"));


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
