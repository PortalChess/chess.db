using System;
using AutoMapper;
using chess.games.db;
using chess.games.db.api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace chess.db.webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(cfg =>
                {
                    // Configures to return 406 for unsupported "Accept" header content-types
                    cfg.ReturnHttpNotAcceptable = true; 
                })
                .AddJsonOptions(cfg =>
                {
                    cfg.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .AddXmlDataContractSerializerFormatters() // Add "application/xml" content-type support
                .ConfigureApiBehaviorOptions(setupAction =>
                    {
                        // Make invalid model state errors a bit better
                        setupAction.InvalidModelStateResponseFactory = context =>
                        {
                            var problemDetails = new ValidationProblemDetails(context.ModelState)
                            {
                                Title = "One or more model validation errors occurred.",
                                Status = StatusCodes.Status422UnprocessableEntity,
                                Detail = "See the errors property for details.",
                                Instance = context.HttpContext.Request.Path
                            };

                            problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                            return new UnprocessableEntityObjectResult(problemDetails)
                            {
                                ContentTypes = { "application/problem+json" }
                            };
                        };
                    }
                );

            services
                    .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()) // Registers Mapping "Profiles"
                    .AddChessDatabaseContext(Configuration["ChessDB"])
                    .AddChessRepositories();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureExceptionHandling(app, env);

            // NOTE: Order is SPECIFIC!
            // i.e. Authorisation `UseAuthorization()` comes after a Route endpoint is chosen `UseRouting()` but before
            // the endpoint is actually executed `UseEndPoints()`

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void ConfigureExceptionHandling(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(cfg =>
                {
                    cfg.Run(async context =>
                    {
                        // TODO: Better exception handling and logging
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Please try again.");
                    });
                });
            }
        }
    }
}
