using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped < IuserRepositories, userRepositories>();
builder.Services.AddScoped<IuserServices, userServices>();
builder.Services.AddScoped<IpasswordServic ,passwordServic>();


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
