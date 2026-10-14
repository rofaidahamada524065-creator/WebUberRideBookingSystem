
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebUberRideBookingSystem.Data;
using WebUberRideBookingSystem.Repos.Impelementation;
using WebUberRideBookingSystem.Repos.Interface;
using WebUberRideBookingSystem.UnitOfWorkk;

namespace WebUberRideBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbcontext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
            builder.Services.AddScoped(typeof(IGenaricRepo<>), typeof(GenaricRepo<>));
            builder.Services.AddScoped<IUserCustom,UserCustom>();
            builder.Services.AddScoped<IunitOfWork,UnitOfWork>();

            var key = Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]);

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["jwt:issuer"],
                    ValidAudience = builder.Configuration["key:audine"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true
                };
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
