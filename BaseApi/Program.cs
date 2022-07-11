using BaseApi.Contexts;
using BaseApi.Middlewares;
using BaseApi.Repositories;
using BaseApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBaseService, BaseService>();

builder.Services.AddScoped<IBaseRepository, BaseRepository>();

builder.Services.AddDbContext<BaseAppContext>(options =>
                options.UseNpgsql("Server=localhost;Port=5432;Database=TesteDb;User Id=postgres;Password=postgres"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.Run();
