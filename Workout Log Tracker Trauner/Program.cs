using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Workout_Log_Tracker_Trauner.Data;
using Workout_Log_Tracker_Trauner.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Workout_Log_Tracker_TraunerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Workout_Log_Tracker_TraunerContext") ?? throw new InvalidOperationException("Connection string 'Workout_Log_Tracker_TraunerContext' not found.")));
builder.Services.AddScoped<WorkoutService>();

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
