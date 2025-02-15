using Harfiyat_Business.Dependency;

var builder = WebApplication.CreateBuilder(args);

//! Business Dependencies
builder.Services.GetDependency();
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.ConfigureFluentValidation();
//!---------------------------------------
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddRouting(opt =>
{
    opt.LowercaseQueryStrings = true;
    opt.AppendTrailingSlash = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
      endpoints.MapAreaControllerRoute(
      name: "admin",
      areaName:"Admin",
      pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{Controller=Home}/{Action=Index}/{id?}");
  

});

//! AUTO MİGRATE
app.ConfigureAutoMigrate();
//!-----------
app.Run();
