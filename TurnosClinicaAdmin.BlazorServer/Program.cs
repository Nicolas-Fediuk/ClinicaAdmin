using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Session;
using TurnosClinicaAdmin.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSession();  

builder.Services.AddTransient<IRepositorio, Repositorio>();
builder.Services.AddSweetAlert2();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiración de la sesión
    options.Cookie.HttpOnly = true; // Solo accesible desde HTTP
    options.Cookie.IsEssential = true; // Requerido para cookies no opcionales
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<SessionMiddleware>();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
