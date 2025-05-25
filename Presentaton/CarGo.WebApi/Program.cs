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
using CarGo.Application.interfaces.CarPricinginterfaces;
using CarGo.Persistence.Repositories.CarPricingRepositories;
using CarGo.Application.Features.RepositoryPattern;
using CarGo.Persistence.Repositories.CommentRepositories;
using CarGo.Application.interfaces.RentACarinterfaces;
using CarGo.Persistence.Repositories.RentACarRepositories;
using CarGo.Application.interfaces.CarFeatureinterfaces;
using CarGo.Persistence.Repositories.CarFeatureRepositories;
using CarGo.Application.interfaces.CarDescriptioninterfaces;
using CarGo.Persistence.Repositories.CarDescriptionRepositories;
using CarGo.Application.interfaces.Reviewinterfaces;
using CarGo.Persistence.Repositories.ReviewRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CarGo.Application.Tools;
using Microsoft.AspNetCore.Authentication.Cookies;



// CORS için politika ekle
var builder = WebApplication.CreateBuilder(args);

// CORS için politika ekle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactNative", policy =>
    {
        policy.WithOrigins("http://localhost:19006") // React Native debug server URL'si
              .AllowAnyHeader()                     // Başlıkları serbest bırak
              .AllowAnyMethod();                    // Yöntemleri serbest bırak
    });
});

builder.Services.AddControllers();



// PostgreSQL bağlantısını ekleyin (appsettings.json'dan alarak)
builder.Services.AddDbContext<CarGoContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

// AUTHENTICATION (SADECE BU KISIM DEĞİŞTİRİLDİ)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});



// Diğer servisleri ekleyelim
builder.Services.AddScoped<CarGoContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));



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

// API controller'larını ve Swagger'ı ekleyelim
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// CORS'u ekle
app.UseCors("AllowReactNative");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting(); // 📌 Routing middleware'i gerekli
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllers(); // Bu da endpoint içinde yer almalı
});

app.Run(); // 