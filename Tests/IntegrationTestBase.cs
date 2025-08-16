using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Data;
using Desafio_BackEnd.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Tests
{
    public abstract class IntegrationTestBase : IClassFixture<IntegrationTestWebAppFactory>
    {
        protected readonly IntegrationTestWebAppFactory Factory;
        protected readonly HttpClient HttpClient;

        protected IntegrationTestBase(IntegrationTestWebAppFactory factory)
        {
            Factory = factory;
            HttpClient = factory.CreateClient();
        }

        protected async Task<ApplicationDBContext> GetDbContextAsync()
        {
            var scope = Factory.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
            return context;
        }

        protected async Task SeedDataAsync<T>(params T[] entities) where T : class
        {
            using var context = await GetDbContextAsync();
            await context.Set<T>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        protected async Task ClearDataAsync<T>() where T : class
        {
            using var context = await GetDbContextAsync();
            context.Set<T>().RemoveRange(context.Set<T>());
            await context.SaveChangesAsync();
        }
        protected async Task ResetDatabaseAsync()
        {
            using var context = await GetDbContextAsync();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }

        protected Motorcycle CreateGenericMotorcycle(
            string identifier = "moto1",
            string model = "Yamaha MT-07",
            int year = 2025,
            string plate = "ABC-1234")
        {
            return new Motorcycle
            {
                Identifier = identifier,
                Model = model,
                Year = year,
                Plate = plate
            };
        }
    }
}