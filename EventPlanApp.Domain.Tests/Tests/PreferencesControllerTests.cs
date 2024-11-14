using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EventPlanApp.Domain.Entities;
using Google;
using EventPlanApp.Infra.Data;

public class PreferencesControllerTests
{
    [Fact]
    public async Task Post_ShouldReturnBadRequest_WhenValidationFails()
    {
        var mockContext = new Mock<EventPlanContext>();
        var validator = new UserPreferencesValidator();

        var controller = new PreferencesController(mockContext.Object, validator);

        var invalidPreferences = new UserPreferences
        {
            UserId = 1,
            EventType = "", // Tipo de evento inválido
            Location = "",
            PriceRange = ""
        };

        var result = await controller.Post(invalidPreferences);
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task Post_ShouldReturnOk_WhenPreferencesAreSavedSuccessfully()
    {
        var options = new DbContextOptionsBuilder<EventPlanContext>()
            .UseInMemoryDatabase(databaseName: "PreferencesDb")
        .Options;

        using (var context = new EventPlanContext(options))
        {
            var validator = new UserPreferencesValidator();
            var controller = new PreferencesController(context, validator);

            var preferences = new UserPreferences
            {
                UserId = 1,
                EventType = "Music",
                Location = "New York",
                PriceRange = "Medium"
            };

            var result = await controller.Post(preferences);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
