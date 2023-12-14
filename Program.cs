using MarcosEduardo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string mysqlconnection = "server=localhost;port=3307;database=appcsharp;uid=root;pwd=ifpi;"; // coloquei aqui, o dotnet não estava lendo a string de configuração presente em 'appsettings.json'
//caso dê erro ao conectar com o banco de dados, comente a linha abaixo e descomente a linha acima
// string mysqlconnection =
// builder.Configuration.GetConnectionString("MyDbContext");

builder.Services.AddDbContext<MyDbContext>(options =>
options.UseMySql(mysqlconnection,
ServerVersion.AutoDetect(mysqlconnection)));
//docker run --name mysql-db -p 3307:3306 -e MYSQL_ROOT_PASSWORD=ifpi -e MYSQL_DATABASE=appcsharp -d mariadb:latest

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();