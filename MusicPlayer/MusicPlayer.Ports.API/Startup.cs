using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MusicPlayer.Adaptors.SQLServerDataAccess.Contexts;
using AutoMapper;
using System.Text;

namespace MusicPlayer.Ports.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configurar el middleware de autenticación
            services
               .AddAuthentication(x =>
               {
                   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               }).AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.ASCII.GetBytes(Configuration["JWT:Secret"])
                       ),
                       ValidateAudience = false,
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = false
                   };
               });

            services.AddAuthorization();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<PlaylistDB>();
            services.AddControllers().AddNewtonsoftJson();


            services.AddCors(options =>
                options.AddDefaultPolicy(builder =>
                    builder.WithOrigins("http://localhost:5000", "http://localhost:3001")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            //Añadiendo middleware de autenticación
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
