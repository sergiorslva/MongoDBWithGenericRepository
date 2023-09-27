using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDBRepository.Application.Services;
using MongoDBRepository.Domain.Interfaces.Repositories;
using MongoDBRepository.Repository;

namespace MongoDBRepository.IoC
{
    public static class DependencyInjector
    {
        public static void RegisterDependencies(this IServiceCollection service)
        {
            service.AddTransient<IMongoClient>(sp =>
            {
                var options = sp.GetService<IConfiguration>().GetSection("Mongo").Get<MongoDbOptions>();
                return new MongoClient(options.ConnectionString);
            });

            service.AddTransient<IMongoDatabase>(sp =>
            {
                var client = sp.GetService<IMongoClient>();
                var options = sp.GetService<IConfiguration>().GetSection("Mongo").Get<MongoDbOptions>();
                return client.GetDatabase(options.Database);
            });

            service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            service.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            service.AddScoped<IClassRepository, ClassRepository>();
            service.AddScoped<IClassService, ClassService>();
        }
    }
}