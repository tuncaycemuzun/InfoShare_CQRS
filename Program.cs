using InfoShare_CQRS.Data.Contexts;
using InfoShare_CQRS.Mediatr.EventHandlers;
using InfoShare_CQRS.Mediatr.Events;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<INotificationHandler<ProductCreatedEvent>, ProductCreatedEventHandler>(); // Event handler'ý ekleyin

builder.Services.AddDbContext<ReadDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ReadDbContext")));
builder.Services.AddDbContext<WriteDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("WriteDbContext")));

builder.Services.AddScoped<DbContext, ReadDbContext>();
builder.Services.AddScoped<DbContext, WriteDbContext>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();

    });
});

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
