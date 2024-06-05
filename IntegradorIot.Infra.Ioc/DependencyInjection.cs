using IntegradorIoc.Application.Interfaces;
using IntegradorIoc.Application.Mapping;
using IntegradorIoc.Application.Services;
using IntegrationIot.Infra.Data.Context;
using IntegrationIot.Infra.Data.Identity;
using IntegrationIot.Infra.Data.Repositories;
using IntegratorIot.Domain.Account;
using IntegratorIot.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace IntegradorIot.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b =>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            //AutoMapper
            services.AddAutoMapper((typeof(ModelsToDTOPappingProfile)));


            //Autenticação
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["jwt:issuer"],
                    ValidAudience = configuration["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["jwt:secretkey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            //serviços
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<ICommandService, CommandService>();
            services.AddTransient<IParameterService, ParameterService>();
            services.AddTransient<ICommandDescriptionService, CommandDescriptionService>();
            services.AddTransient<IAuthenticate, AuthenticateService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            //repositorios
            services.AddTransient<IDeviceRepository, DeviceRepository>();
            services.AddTransient<ICommandRepository, CommandRepository>();
            services.AddTransient<IParameterRepository, ParameterRepository>();
            services.AddTransient<ICommandDescriptionRepository, CommandDescriptionRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();


            return services;
        }
    }
}
