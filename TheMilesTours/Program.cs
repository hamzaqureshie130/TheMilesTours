using Infrastructure.TheMilesTours;
using ApplicationLayer.TheMilesTours;
using TheMilesTours.Helper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<FileUploader>();
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    // Admin area ke sabhi pages ke liye dynamic routing
    options.Conventions.AddAreaFolderRouteModelConvention("Admin", "/", model =>
    {
        foreach (var selector in model.Selectors)
        {
            var template = selector.AttributeRouteModel.Template;
            if (template != null && template.StartsWith("Admin/"))
            {
                // Admin area ke routes ko as-is rakhna hai
                selector.AttributeRouteModel.Template = template;
            }
        }
    });
});
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureServices(configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
