using Driver.Application.IServices;
using Driver.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(c =>
    {
        c.AddPolicy("AllowOrigin", options =>
        {
            options.AllowAnyOrigin();
            options.AllowAnyHeader();
            options.AllowAnyMethod();
        });
    });
builder.Services.AddScoped<IServiceManager, ServiceManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(options => options.AllowAnyOrigin());
app.UseAuthorization();


app.MapControllers();

app.Run();
