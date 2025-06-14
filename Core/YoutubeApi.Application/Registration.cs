﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace YoutubeApi.Application
{
    public static class Registration
    {
        public static void AddAplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }
    }
}
