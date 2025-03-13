using FluentEmail.MailKitSmtp;
using FS0924_S17_L3.Data;
using FS0924_S17_L3.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<LendingService>();

builder
    .Services.AddFluentEmail(
        builder.Configuration.GetSection("MailSettings").GetValue<string>("FromDefault")
    )
    .AddRazorRenderer()
    .AddMailKitSender(
        new SmtpClientOptions()
        {
            Server = builder.Configuration.GetSection("MailSettings").GetValue<string>("Server"),
            Port = builder.Configuration.GetSection("MailSettings").GetValue<int>("Port"),
            User = builder.Configuration.GetSection("MailSettings").GetValue<string>("Username"),
            Password = builder
                .Configuration.GetSection("MailSettings")
                .GetValue<string>("Password"),
            UseSsl = builder.Configuration.GetSection("MailSettings").GetValue<bool>("UseSsl"),
            RequiresAuthentication = builder
                .Configuration.GetSection("MailSettings")
                .GetValue<bool>("RequiresAuthentication"),
        }
    );
builder.Services.AddScoped<EmailService>();

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

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
