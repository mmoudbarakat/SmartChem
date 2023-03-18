using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartChemMVC.Areas.Identity.Data;
using SmartChemMVC.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SmartChemMVCContextConnection") ?? throw new InvalidOperationException("Connection string 'SmartChemMVCContextConnection' not found.");

builder.Services.AddDbContext<SmartChemMVCContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<SmartChemMVCUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SmartChemMVCContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();


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
app.UseStatusCodePagesWithReExecute("/error/{0}");

app.UseRouting();
app.UseAuthentication();;
app.MapRazorPages();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");

app.Run();
