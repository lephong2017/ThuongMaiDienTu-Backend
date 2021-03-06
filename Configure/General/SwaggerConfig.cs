﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TemplateWebApiForMy.Configure.General
{
    public static class SwaggerConfig
    {
        //class nay dung de cau hinh swagger de test cac api 
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "Version 0.1",
                    Title = "Thương Mại Điện Tử",
                    Description = "Toàn bộ api ứng dụng được viết tại đây",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Rental car",
                        Email = string.Empty,
                        Url = "https://rental-car.azurewebsites.net/"
                    },
                    License = new License
                    {
                        Name = "NLU - FIT",
                        Url = "https://rental-car.azurewebsites.net/"
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }
        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API");
            });
        }
    }
}
