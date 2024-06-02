using DbContext;
using Features.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Features;
public class Program()
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<ConnectionStrings>(
            builder.Configuration.GetSection(new ConnectionStrings().OptionName));
        var connectionStrings = builder.Configuration.GetSection(new ConnectionStrings().OptionName).Get<ConnectionStrings>() ?? throw new Exception();
        builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(connectionStrings.DefaultConnection));

        UsersInstaller.Register(builder.Services);

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

        builder.Services.AddControllers();
        //builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.MapControllers();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.Run();
    }
}
