using Microsoft.Extensions.DependencyInjection;
using Ranjaken.Domain.Interfaces.Repositories;
using Ranjaken.Domain.Interfaces.Services;
using RanjaKen.Infrastructure.Persistences.Repositories;
using RanjaKen.Infrastructure.Persistences.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RanjaKen.Infrastructure.Commons.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped(typeof(IFileService), typeof(FileService));
            
            return services;
        }

    }
}
