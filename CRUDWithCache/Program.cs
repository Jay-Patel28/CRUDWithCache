using CRUDWithCache.Managers;
using CRUDWithCache.Services;
using CRUDWithCache.Repositories;
using Microsoft.EntityFrameworkCore;
using CRUDWithCache;
using AutoMapper;
using CRUDWithCache.DTOs;
using CRUDWithCache.Models;
using CRUDWithCache.Entities;
using CRUDWithCache.Caching;
using CRUDWithCache.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpResponseExceptionFilter>();
});

//builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connectionString));

MapperConfiguration mapperConfig = new MapperConfiguration(mc =>
{
    mc.CreateMap<AuthorDTO, Author>();
    mc.CreateMap<Author, AuthorDTO>();
    mc.CreateMap<Author, AuthorEntity>();
    mc.CreateMap<AuthorEntity, Author>();
    mc.CreateMap<BookDTO, Book>();
    mc.CreateMap<Book, BookDTO>();
    mc.CreateMap<Book, BookEntity>();
    mc.CreateMap<BookEntity, Book>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("MyRedisConStr");
    options.InstanceName = "DB0";
});
builder.Services.AddMemoryCache();

builder.Services.AddSingleton<RedisCache>();
builder.Services.AddSingleton<InMemoryCache>();

builder.Services.AddTransient<ServiceResolver>(serviceProvider => cacheType =>
{
    switch (cacheType)
    {
        case CacheType.RedisCache:
            return serviceProvider.GetService<RedisCache>();
        default:
            return serviceProvider.GetService<InMemoryCache>();
    }
});

builder.Services.AddSingleton<AuthorsCache>();

builder.Services.AddScoped<AuthorsRepository>();
builder.Services.AddScoped<BooksRepository>();

builder.Services.AddScoped<AuthorsManager>();
builder.Services.AddScoped<BooksManager>();

builder.Services.AddScoped<AuthorsService>();
builder.Services.AddScoped<BooksService>();

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
