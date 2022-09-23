using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using MovieReviewService.Application.AddReviewUseCase;
using MovieReviewService.Application.MovieUseCase;
using MovieReviewService.Application.MovieUseCases;
using MovieReviewService.Application.RevewUseCase;
using MovieReviewService.Application.ReviewUseCase;
using MovieReviewService.Application.UseCase;
using MovieReviewService.Application.UserUseCase;
using MovieReviewService.Data;
using MovieReviewService.Data.Interfaces;

var cors = "test";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(cors, policy =>
    {
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddDbContext<MainContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("User"),
        b => b.MigrationsAssembly("MovieReviewService.Data")));


builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserQuery, UserQueries>();

builder.Services.AddScoped<UpdateUserUseCase>();
builder.Services.AddScoped<UpdateReviewUseCase>();
builder.Services.AddScoped<UpdateMovieUseCase>();

builder.Services.AddScoped<DeleteMovieUseCase>();
builder.Services.AddScoped<DeleteReviewUseCase>();
builder.Services.AddScoped<DeleteUserUseCase>();

builder.Services.AddScoped<AddUserUseCase>();
builder.Services.AddScoped<AddReviewUseCase>();
builder.Services.AddScoped<AddMovieUseCase>();

builder.Services.AddScoped<GetUserUseCase>();
builder.Services.AddScoped<GetMovieUseCase>();
builder.Services.AddScoped<GetReviewUseCase>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(cors);

app.UseAuthorization();

app.MapControllers();

app.Run();
