using PitPizzas.Patterns.Builder;

var app = WebApplication.CreateBuilder(args);

app.Services.AddControllersWithViews();
app.Services.AddDistributedMemoryCache();
app.Services.AddSession();

// Um builder novo + um diretor por requisição
app.Services.AddScoped<IPizzaBuilder, PizzaBuilder>();
app.Services.AddScoped<Diretor>();

var web = app.Build();

web.UseStaticFiles();
web.UseRouting();
web.UseSession();

web.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pizza}/{action=Index}/{id?}");

web.Run();
