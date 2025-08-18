using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_BackEnd.Data;
using Desafio_BackEnd.Dtos.Deliveryman;
using Desafio_BackEnd.Models;
using Desafio_BackEnd.Models.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace Tests
{
    public abstract class IntegrationTestBase : IClassFixture<IntegrationTestWebAppFactory>, IAsyncLifetime
    {
        protected readonly IntegrationTestWebAppFactory _factory;
        protected readonly HttpClient HttpClient;

        protected IntegrationTestBase(IntegrationTestWebAppFactory factory)
        {
            _factory = factory;
            HttpClient = factory.CreateClient();
        }

        public virtual async Task InitializeAsync()
        {
            await _factory.ResetDatabaseAsync();
        }

        public virtual async Task DisposeAsync()
        {
            HttpClient?.Dispose();
        }

        protected async Task SeedDataAsync<T>(params T[] entities) where T : class
        {
            using var context = await _factory.GetDbContextAsync();
            await context.Set<T>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
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

        protected Desafio_BackEnd.Models.Deliveryman CreateGenericDeliveryman(
            string identifier = "deliveryman1",
            string name = "Thiago Eidi",
            string username = "thiagoeidi1",
            string cnpj = "12354321312141",
            string cnh = "12313123131414",
            string password = "12134",
            EnumCNHType cnh_type = EnumCNHType.A,
            DateTime? birthDate = null)
        {
            return new Desafio_BackEnd.Models.Deliveryman
            {
                Identifier = identifier,
                Name = name,
                CNPJ = cnpj,
                Username = username,
                BirthDate = birthDate ?? new DateTime(1990, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                CNH = cnh, 
                CNHType = cnh_type,
                Password = password, 
            };
        }

        protected void AuthenticateAsRole(string role)
        {
            HttpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Test", role);
        }
    }
}