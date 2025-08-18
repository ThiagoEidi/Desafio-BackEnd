using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Desafio_BackEnd.Dtos.Deliveryman;
using Desafio_BackEnd.Models.Utils;
using Xunit;

namespace Tests.Deliveryman
{
    public class DeliverymanControllerTests : IntegrationTestBase
    {
        public DeliverymanControllerTests(IntegrationTestWebAppFactory factory)
            : base(factory) { }

        [Fact]
        public async Task CreateDeliveryman_ShouldWork()
        {
            var deliveryman = CreateGenericDeliveryman();

            
            var postResponse = await HttpClient.PostAsJsonAsync("/api/deliveryman", deliveryman);
            
            postResponse.EnsureSuccessStatusCode(); 
            var created = await postResponse.Content.ReadFromJsonAsync<DeliverymanDto>();

            Assert.NotNull(created);
            Assert.Equal(deliveryman.Name, created.Name);
            Assert.Equal(deliveryman.Username, created.Username);
        }

        [Fact]
        public async Task GetDeliverymanById_ShouldReturnNotFound_ForInvalidId()
        {
            var response = await HttpClient.GetAsync($"/api/deliveryman/{Guid.NewGuid()}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
