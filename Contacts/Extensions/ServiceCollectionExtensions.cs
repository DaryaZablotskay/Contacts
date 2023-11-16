using Microsoft.Extensions.DependencyInjection;
using Contacts.Repositories;
using Contacts.Repositories.Interfaces;
using Contacts.Services.IServices;
using Contacts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactService>();

            return services;
        }
    }
}
