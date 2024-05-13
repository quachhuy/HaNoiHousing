using hnh.Data;
using hnh.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// add dbcontext
builder.Services.AddDbContext<MyDbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Constr")));

// add repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


// add controller
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
