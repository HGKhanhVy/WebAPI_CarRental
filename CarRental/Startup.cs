using Invedia.DI;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using CarRental.Contract.Repository.Infrastructure;
using CarRental.Core.Configs;
using CarRental.Repository.Infrastructure;
using CarRental.WebApi.Extensions;
using ILogger = Serilog.ILogger;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CarRental.Contract.Repository.Models;
using AngleSharp;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace CarRental.WebApi
{
    public class Startup
    {
        private IConfiguration _configuration;
        ILogger _logger;

        public Startup(WebApplicationBuilder builder, IWebHostEnvironment env)
        {
            _configuration = builder.Configuration;
            _logger = Log.Logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSystemSetting(_configuration.GetSection("SystemSetting").Get<SystemSettingModel>());

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));
            var secretKey = _configuration["AppSettings:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    // tự cấp token
                    ValidateIssuer = false, // sử dụng dịch vụ thì chọn true => chỉ ra đường dẫn
                    ValidateAudience = false,

                    // ký vào token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes), // thuật toán đối xứng key

                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRental", Version = "v1" });
            });

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = false;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = false;
            });
            services.AddAutoMapperServices();
            var connectionString = _configuration.GetConnectionString("CarRentalConnection");
            services.AddDI();
            services.PrintServiceAddedToConsole();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("CarRentalConnection")));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /*var isUserSwagger = _configuration.GetValue<bool>("UseSwagger", false);
            if (isUserSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.DefaultModelsExpandDepth(-1);
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRental v1");
                });
            }*/

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRental v1");
            });

            app.UseAuthentication();
            app.MapControllers();
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseAuthorization();
            AppContext.SetSwitch("System.Globalization.Invariant", false);
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
