using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using CarGo.Persistence.Context;
using CarGo.Application.Features.CQRS.Handlers.AboutHandlers;
using Microsoft.Extensions.DependencyInjection;
using CarGo.Application.interfaces;
using CarGo.Persistence.Repositories;
using CarGo.Application.Features.CQRS.Handlers.BannerHandlers;
using CarGo.Application.Features.CQRS.Handlers.BrandHandlers;
using CarGo.Application.Features.CQRS.Handlers.CarHandlers;
using Cargo.Domain.Entities;
using CarGo.Application.interfaces.Carinterfaces;
using CarGo.Persistence.Repositories.CarRepositories;
using CarGo.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarGo.Application.Features.CQRS.Handlers.ContactHandlers;
using CarGo.Application.Services;
using CarGo.Application.Features.Mediator.Handlers.BlogHandlers;
using MediatR;
using CarGo.Application.interfaces.BlogInterfaces;
using CarGo.Persistence.Repositories.BlogRepositories;



// CORS i�in politika ekle
var builder = WebApplication.CreateBuilder(args);

// CORS i�in politika ekle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactNative", policy =>
    {
        policy.WithOrigins("http://localhost:19006") // React Native debug server URL'si
              .AllowAnyHeader()                     // Ba�l�klar� serbest b�rak
              .AllowAnyMethod();                    // Y�ntemleri serbest b�rak
    });
});

builder.Services.AddControllers();



// PostgreSQL ba�lant�s�n� ekleyin (appsettings.json'dan alarak)
builder.Services.AddDbContext<CarGoContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

// Di�er servisleri ekleyelim
builder.Services.AddScoped<CarGoContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddApplicationService(builder.Configuration);

// API controller'lar�n� ve Swagger'� ekleyelim
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// CORS'u do�ru s�rada ekledi�imizden emin olal�m
app.UseCors("AllowReactNative");  // CORS middleware'ini burada �a��r�yoruz.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();
app.Run();
