using Com.Sapient.Data;
using Com.Sapient.Helpers;
using Com.Sapient.Services;
using Com.Sapient.Services.ActivationTokenService;
using Com.Sapient.Services.EmailService;
using Com.Sapient.Services.RedisService;
using Com.Sapient.Services.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendGrid.Helpers.Mail;
using WebApi.Helpers;

namespace Com.Sapient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost",
                                                          "https://localhost");
                                  });
            });

            services.AddCors();
            services.AddControllers();
            services.AddDbContext<DataContext>(options=>options.UseSqlite("Data Source=UserDetails"));

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRedisService, RedisService>();
            services.AddScoped<IEmailService<SendGridMessage>, SendGridEmailService>();
           

            services.AddSingleton<IRedisService, RedisService>();
            services.AddSingleton<IEmailService<SendGridMessage>, SendGridEmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IActivationTokenService, PasswordResetTokenService>();
            //Configure Facebook Authentication
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });
            //Configure Google Authentication
            services.AddAuthentication()
       .AddGoogle(options =>
       {
           IConfigurationSection googleAuthNSection =
               Configuration.GetSection("Authentication:Google");

           options.ClientId = googleAuthNSection["ClientId"];
           options.ClientSecret = googleAuthNSection["ClientSecret"];
       });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
