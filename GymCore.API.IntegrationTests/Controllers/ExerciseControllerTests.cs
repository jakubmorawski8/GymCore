using System.Net;
using System.Threading.Tasks;
using GymCore.API.IntegrationTests.Base;
using GymCore.Application.Requests.Exercise.Queries.GetExerciseDetails;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace GymCore.API.IntegrationTests.Controllers
{
    public class ExerciseControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly string _defaultExerciseEndpoint = "/api/exercise/";
        private readonly string _existingGuid = "dda005cf-297d-450c-ae57-f65be5adebe7";
        private readonly string _notExistingGuid = "11a005cf-297d-450c-ae57-f65be5adebe7";

        public ExerciseControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsNotFoundResult()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(_defaultExerciseEndpoint + _notExistingGuid);
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<GetExerciseDetailsQueryResponse>(responseString);

            result.ExerciseDetailsVm.ShouldBeNull();
            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task ReturnsOkResult()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(_defaultExerciseEndpoint + _existingGuid);
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<GetExerciseDetailsQueryResponse>(responseString);

            result.ExerciseDetailsVm.ShouldNotBeNull();
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}
