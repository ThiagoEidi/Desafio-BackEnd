using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Desafio_BackEnd.Dtos.Motorcycle;
using Desafio_BackEnd.Models;
using Xunit;

namespace Tests;

public class MotorcycleControllerTests : IntegrationTestBase, IAsyncLifetime
{
    public MotorcycleControllerTests(IntegrationTestWebAppFactory factory)
        : base(factory) { }

    public async Task InitializeAsync()
    {
        await ResetDatabaseAsync();
    }

    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async Task CreateAndGetMotorcycle_ShouldWork()
    {
        var moto = CreateGenericMotorcycle();

        var postResponse = await HttpClient.PostAsJsonAsync("/api/motorcycle", new CreateMotorcycleRequestDto
        {
            Identifier = moto.Identifier,
            Model = moto.Model,
            Year = moto.Year,
            Plate = moto.Plate
        });
        postResponse.EnsureSuccessStatusCode();
        var createdMotorcycle = await postResponse.Content.ReadFromJsonAsync<MotorcycleDto>();

        Assert.NotNull(createdMotorcycle);
        Assert.Equal(moto.Identifier, createdMotorcycle.Identifier);

        var getResponse = await HttpClient.GetAsync($"/api/motorcycle/{createdMotorcycle.Id}");
        getResponse.EnsureSuccessStatusCode();
        var fetchedMotorcycle = await getResponse.Content.ReadFromJsonAsync<MotorcycleDto>();

        Assert.NotNull(fetchedMotorcycle);
        Assert.Equal(moto.Identifier, fetchedMotorcycle.Identifier);
    }

    [Fact]
    public async Task UpdateMotorcyclePlate_ShouldWork()
    {
        var moto = CreateGenericMotorcycle();
        await SeedDataAsync(moto);

        var updateDto = new UpdateMotorcycleRequestDto { Plate = "ABC-567" };

        var patchResponse = await HttpClient.PatchAsJsonAsync($"/api/motorcycle/{moto.Id}/plate", updateDto);
        patchResponse.EnsureSuccessStatusCode();
        var updatedMotorcycle = await patchResponse.Content.ReadFromJsonAsync<MotorcycleDto>();

        Assert.NotNull(updatedMotorcycle);
        Assert.Equal("ABC-567", updatedMotorcycle.Plate);
    }

    [Fact]
    public async Task DeleteMotorcycle_ShouldWork()
    {
        var moto = CreateGenericMotorcycle();
        await SeedDataAsync(moto);

        var deleteResponse = await HttpClient.DeleteAsync($"/api/motorcycle/{moto.Id}");

        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        var getResponse = await HttpClient.GetAsync($"/api/motorcycle/{moto.Id}");
        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }

    [Fact]
    public async Task GetAllMotorcycles_ShouldReturnAllMotorcycles()
    {
        var moto1 = CreateGenericMotorcycle();
        var moto2 = CreateGenericMotorcycle();
        moto2.Identifier = "moto2";
        moto2.Plate = "BAV-222";

        await SeedDataAsync(moto1, moto2);

        var response = await HttpClient.GetAsync("/api/motorcycle");
        response.EnsureSuccessStatusCode();

        var motorcycles = await response.Content.ReadFromJsonAsync<MotorcycleDto[]>();

        Assert.NotNull(motorcycles);
        Assert.Equal(2, motorcycles.Length);
        Assert.Contains(motorcycles, m => m.Identifier == "moto1");
        Assert.Contains(motorcycles, m => m.Identifier == "moto2");
    }

    [Fact]
    public async Task GetMotorcycleById_ShouldReturnNotFound_ForInvalidId()
    {
        var response = await HttpClient.GetAsync($"/api/motorcycle/{Guid.NewGuid()}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task UpdateMotorcyclePlate_ShouldReturnNotFound_ForInvalidId()
    {
        var updateDto = new UpdateMotorcycleRequestDto { Plate = "ABC-123" };

        var response = await HttpClient.PatchAsJsonAsync($"/api/motorcycle/{Guid.NewGuid()}/plate", updateDto);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task DeleteMotorcycle_ShouldReturnNotFound_ForInvalidId()
    {
        var response = await HttpClient.DeleteAsync($"/api/motorcycle/{Guid.NewGuid()}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetAllMotorcycles_ShouldReturnForbidden_IfNotAdmin()
    {
        AuthenticateAsRole("User"); 

        var response = await HttpClient.GetAsync("/api/motorcycle");

        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }
}
