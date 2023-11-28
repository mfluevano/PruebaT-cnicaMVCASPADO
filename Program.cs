    using System.Data;
    using System.Data.SqlClient;
    using System.Reflection;
    using Microsoft.AspNetCore.Mvc;
    using PruebaTécnicaMVCASPADO.Data;
    using PruebaTécnicaMVCASPADO.Models;
    using PruebaTécnicaMVCASPADO.Services.Implementaciones;
    using PruebaTécnicaMVCASPADO.Services.Interfaces;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddScoped<ICatalogosService<CatProducto>, catProductosImplementacion>();
    builder.Services.AddScoped<ICatalogosService<CatTipoCliente>, catTipoClienteImplementacion>();
    builder.Services.AddScoped<ICatalogosService<TblClientes>, catClientesImplementacion>();
    builder.Services.AddScoped<ICatalogosServiceFac<TblFacturas>, tblFacturacionImplementacion>();
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

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}");

    app.Run();

