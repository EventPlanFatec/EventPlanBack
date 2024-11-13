using EventPlanApp.Api.Controllers;
using EventPlanApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace EventPlanApp.Domain.Tests
{
    public class FavoritesControllerTests
    {
        [Fact]
        public async Task AddToFavorites_NewEvent_ShouldAddSuccessfully()
        {
            // Arrange
            var mockRepo = new Mock<IFavoritesRepository>();
            mockRepo.Setup(repo => repo.IsEventFavoritedByUserAsync(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(false);
            var controller = new FavoritesController(mockRepo.Object);

            // Simula o usuário autenticado
            controller.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext()
            {
                HttpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext()
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim("userId", "123") // Aqui você define um ID fictício para o usuário
                    }))
                }
            };

            // Act
            var result = await controller.AddToFavorites(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Evento adicionado aos favoritos.", okResult.Value);
            mockRepo.Verify(repo => repo.AddToFavoritesAsync(It.IsAny<string>(), 1), Times.Once);
        }

        [Fact]
        public async Task AddToFavorites_ExistingFavorite_ShouldReturnBadRequest()
        {
            // Arrange
            var mockRepo = new Mock<IFavoritesRepository>();
            mockRepo.Setup(repo => repo.IsEventFavoritedByUserAsync(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(true);
            var controller = new FavoritesController(mockRepo.Object);

            // Simula o usuário autenticado
            controller.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext()
            {
                HttpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext()
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim("userId", "123") // Aqui você define um ID fictício para o usuário
                    }))
                }
            };

            // Act
            var result = await controller.AddToFavorites(1);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Este evento já está nos favoritos.", badRequestResult.Value);
        }
    }
}
