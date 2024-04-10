using Microsoft.EntityFrameworkCore;
using PracticumServer.Core;
using PracticumServer.Core.Repositories;
using PracticumServer.Core.Services;
using PracticumServer.Data;
using PracticumServer.Data.Repositories;
using PracticumServer.Service;
using Microsoft.Extensions.Configuration;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployee_RoleRepository, Employee_RoleRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mappingConfig = new MapperConfiguration(mc =>
{
    //mc.AddProfile(new EMProfile());
});


IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<DataContext>(option => {
   option.UseMySql(builder.Configuration.GetConnectionString("PracticumDB"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("PracticumDB")));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var policy = "policy";
builder.Services.AddCors(option => option.AddPolicy(name: policy, policy =>
{
    policy.AllowAnyOrigin(); policy.AllowAnyHeader(); policy.AllowAnyMethod();
}));

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

app.UseCors(policy);

app.Run();

