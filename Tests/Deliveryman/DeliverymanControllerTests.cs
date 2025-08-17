using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Desafio_BackEnd.Dtos.Deliveryman;
using Desafio_BackEnd.Models.Utils;
using Xunit;

namespace Tests.Deliveryman
{
    public class DeliverymanControllerTests : IntegrationTestBase, IAsyncLifetime
    {
        public DeliverymanControllerTests(IntegrationTestWebAppFactory factory)
            : base(factory) { }

        public async Task InitializeAsync() => await ResetDatabaseAsync();
        public Task DisposeAsync() => Task.CompletedTask;

        [Fact]
        public async Task CreateDeliveryman_ShouldWork()
        {
            var createDto = CreateGenericDeliveryman();

            
            var postResponse = await HttpClient.PostAsJsonAsync("/api/deliveryman", createDto);
            
            postResponse.EnsureSuccessStatusCode(); 
            var created = await postResponse.Content.ReadFromJsonAsync<DeliverymanDto>();

            Assert.NotNull(created);
            Assert.Equal(createDto.Name, created.Name);
            Assert.Equal(createDto.Username, created.Username);
        }

        [Fact]
        public async Task GetDeliverymanById_ShouldReturnNotFound_ForInvalidId()
        {
            var response = await HttpClient.GetAsync($"/api/deliveryman/{Guid.NewGuid()}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
