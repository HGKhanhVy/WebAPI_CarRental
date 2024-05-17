//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using CarRental.Contract.Service;
using CarRental.Core.Configs;
using CarRental.WebApi;
using Microsoft.Extensions.Options;
using Serilog;
using CarRental.Contract.Service;
using CarRental.Core.Configs;
using CarRental.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("*")
                                                          .AllowAnyHeader()
                                                          .AllowAnyMethod();
                                      // .AllowCredentials();

                                  });
        });



        _ = builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
           _ = loggerConfiguration.ReadFrom.Configuration(builder.Configuration));

        var startup = new Startup(builder, builder.Environment);
        startup.ConfigureServices(builder.Services);

        var app = builder.Build();
        app.UseCors(MyAllowSpecificOrigins);
        SystemSettingModel.Configs = app.Configuration;
        OnAppStart(app);
        startup.Configure(app, builder.Environment);
        app.Run();
    }
    public static void OnAppStart(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var bootstrapperService = scope.ServiceProvider.GetRequiredService<IBootstrapperService>();
        bootstrapperService.InitialAsync().Wait();
    }
}