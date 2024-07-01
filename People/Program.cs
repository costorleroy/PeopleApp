using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using People.Areas.Identity.Data;
using People.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PeopleDbContextConnection") ?? throw new InvalidOperationException("Connection string 'PeopleDbContextConnection' not found.");

builder.Services.AddDbContext<PeopleDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<PeopleAppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PeopleDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
    //pattern: "{controller=Img}/{action=Index}/{id?}");
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
