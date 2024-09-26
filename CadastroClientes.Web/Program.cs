using Microsoft.EntityFrameworkCore;
using CadastroClientes.Infrastructure.Data;
 
var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddDbContext<CadastroClientesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddControllersWithViews();
 
var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
 
app.UseHttpsRedirection();
app.UseStaticFiles();
 
app.UseRouting();
 
app.UseAuthorization();
 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
 
app.Run();
 
 