using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Controllers;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;
using SistemaDeGestão.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//db connection 

var connection = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<DataBaseContext>(options => options.UseMySql(connection,
    new MySqlServerVersion(
        new Version(8, 0, 0))));

//Injecao de dependencia
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<MovimentacaoService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<ItemPedidoService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produto}/{action=Index}/{id?}");

app.Run();
