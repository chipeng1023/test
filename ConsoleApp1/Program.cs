using ConsoleApp1.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setup =>
            {
                setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ConsoleApp1.xml"));
            });

            var app = builder.Build();

            app.MapWhen(context => context.Request.Path.StartsWithSegments("/swagger"), app =>
            {
                app.Use(async (context, next) =>
                {
                    await next();
                });
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SupportedSubmitMethods([]);
                });
            });

            app.AddApiTest();

            app.Run();
        }
    }
}