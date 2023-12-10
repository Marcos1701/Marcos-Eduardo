using MarcosEduardo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string mysqlconnection = "server=localhost;port=3307;database=appcsharp;uid=root;pwd=ifpi;"; // coloquei aqui, o dotnet não estava lendo a string de configuração presente em 'appsettings.json'
// string mysqlconnection =
// builder.Configuration.GetConnectionString("MyDbContext");

builder.Services.AddDbContext<MyDbContext>(options =>
options.UseMySql(mysqlconnection,
ServerVersion.AutoDetect(mysqlconnection)));
//docker run --name mysql-db -p 3307:3306 -e MYSQL_ROOT_PASSWORD=ifpi -d mariadb:latest

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

// para rodar o dotnet 6.0 com mysql, via docker, é necessário criar um arquivo Dockerfile
/* e adicionar o seguinte conteúdo:
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY appcsharp/*.csproj ./appcsharp/
RUN dotnet restore

# copy everything else and build app
COPY appcsharp/. ./appcsharp/
WORKDIR /source/appcsharp
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "appcsharp.dll"]

e rodar o seguinte comando:
docker build -t appcsharp .
docker run -p 8080:80 appcsharp

*/