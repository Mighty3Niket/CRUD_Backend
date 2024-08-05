using CRUDAPI.BAL.IServices;
using CRUDAPI.BAL.Services;
using CRUDAPI.DAL.DBContext;
using CRUDAPI.DAL.IRepositories;
using CRUDAPI.DAL.Repositories;
using CRUDAPI.Helper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//DB Context
builder.Services.AddDbContext<blogContext>(options =>
 options.UseNpgsql(builder.Configuration.GetConnectionString("CRUDConnection")));





//Mapper
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPostService, PostService>();
// Repository
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
