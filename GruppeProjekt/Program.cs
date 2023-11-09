using GruppeProjekt.model;
using GruppeProjekt.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


/*
 * Indsætter een KundeRepository
 */
builder.Services.AddSingleton<IKundeRepository>(new KundeRepository(true));
builder.Services.AddSingleton<IBurgerRepository>(new BurgerRepository(true));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();