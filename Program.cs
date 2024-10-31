using Frontend_MVC_00013940.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register NoteService for dependency injection
builder.Services.AddHttpClient<NoteService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7145/api/"); // Replace with your backend API URL
});

// Register TagService for dependency injection
builder.Services.AddHttpClient<TagService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7145/api/"); // Replace with your backend API URL
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Notes}/{action=Index}/{id?}");

app.Run();
