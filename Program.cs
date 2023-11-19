using NewsPortal.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewsPortal.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("NewsPortalDB");
builder.Services.AddDbContext<NewsPortalDBContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<NewsPortalDBContext, NewsPortalDBContext>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x=>x.AllowAnyHeader()
.AllowAnyOrigin().AllowAnyMethod());

app.UseAuthorization();


app.MapControllers();

app.Run();
