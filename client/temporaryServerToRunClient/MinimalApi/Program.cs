//======program.cs===========
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TodoApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ToDoDB"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ToDoDB"))));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // כתובת ה-URL של ה-React frontend
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API v1");
    });
}
// Enable CORS

app.UseCors("AllowAngularApp");


app.MapGet("/api/employee", async (ToDoDbContext context) =>
{
    return await context.Employees.ToListAsync();
});

app.MapPost("/api/employee", async (ToDoDbContext context, Employee employee) =>
{
    context.Employees.Add(todo);
    await context.SaveChangesAsync();
    return Results.Created($"/api/employee/{employee.Id}", employee);
});

app.MapPut("/api/employee/{id}", async (ToDoDbContext context, int id, Employee updatedEmployee) =>
{
    // Fetch the existing entity from the database
    var existingEmployee = await context.Employees.FindAsync(id);
    
    if (existingEmployee == null)
    {
        return Results.NotFound();
    }

    // Update the properties of the existing entity
    // existingEmployee.IsComplete = updatedTodo.IsComplete;
    existingEmployee = updatedEmployee;
    try
    {
        // Save changes
        await context.SaveChangesAsync();
        return Results.NoContent();
    }
    catch (DbUpdateConcurrencyException)
    {
        // Handle concurrency conflicts if needed
        return Results.BadRequest("Concurrency conflict occurred.");
    }
});

app.MapDelete("/api/employee/{id}", async (ToDoDbContext context, int id) =>
{
    var employee = await context.Employees.FindAsync(id);
    if (employee == null)
    {
        return Results.NotFound();
    }

    context.Employees.Remove(todo);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();