using EventPlanApp.Api.Controllers;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Services;
using EventPlanApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace EventPlanApp.Domain.Tests
{
    public class FavoritesControllerTests
    {
        private readonly Mock<IFavoritesRepository> _favoritesRepositoryMock;
        private readonly Mock<FavoriteService> _favoriteServiceMock;
        private readonly FavoritesController _controller;

        public FavoritesControllerTests()
        {
            // Mock do repositório
            _favoritesRepositoryMock = new Mock<IFavoritesRepository>();

            // Aqui estamos criando um mock do FavoriteService, mas com a dependência do repositório
            _favoriteServiceMock = new Mock<FavoriteService>(_favoritesRepositoryMock.Object);

            // Criando o controlador e passando as dependências
            _controller = new FavoritesController(_favoritesRepositoryMock.Object, _favoriteServiceMock.Object);
        }

        [Fact]
        public async Task AddToFavorites_NewEvent_ShouldAddSuccessfully()
        {
            // Arrange
            _favoritesRepositoryMock.Setup(repo => repo.IsEventFavoritedByUserAsync(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(false);

            // Simula o usuário autenticado
            _controller.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext()
            {
                HttpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext()
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim("userId", "123") // Define um ID fictício para o usuário
                    }))
                }
            };

            // Act
            var result = await _controller.AddToFavorites(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Evento adicionado aos favoritos.", okResult.Value);
            _favoritesRepositoryMock.Verify(repo => repo.AddToFavoritesAsync(It.IsAny<string>(), 1), Times.Once);
        }

        [Fact]
        public async Task AddToFavorites_ExistingFavorite_ShouldReturnBadRequest()
        {
            // Arrange
            _favoritesRepositoryMock.Setup(repo => repo.IsEventFavoritedByUserAsync(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(true);

            // Simula o usuário autenticado
            _controller.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext()
            {
                HttpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext()
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim("userId", "123") // Define um ID fictício para o usuário
                    }))
                }
            };

            // Act
            var result = await _controller.AddToFavorites(1);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Este evento já está nos favoritos.", badRequestResult.Value);
        }

        [Fact]
        public async Task GetFavorites_ReturnsOk_WhenFavoritesExist()
        {
            // Arrange
            var userId = "user123";
            var favorites = new List<EventoDto>
            {
                new EventoDto { EventoId = 1, NomeEvento = "Evento 1", DataInicio = DateTime.Now },
                new EventoDto { EventoId = 2, NomeEvento = "Evento 2", DataInicio = DateTime.Now.AddDays(1) }
            };

            _favoriteServiceMock.Setup(service => service.GetFavoritesByUserIdAsync(userId))
                .ReturnsAsync(favorites);

            // Act
            var result = await _controller.GetFavorites(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<EventoDto>>(okResult.Value);
            Assert.Equal(favorites.Count, returnValue.Count());
        }

        [Fact]
        public async Task GetFavorites_ReturnsNotFound_WhenNoFavoritesExist()
        {
            // Arrange
            var userId = "user123";
            _favoriteServiceMock.Setup(service => service.GetFavoritesByUserIdAsync(userId))
                .ReturnsAsync(new List<EventoDto>());  // Nenhum favorito encontrado

            // Act
            var result = await _controller.GetFavorites(userId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Nenhum favorito encontrado.", notFoundResult.Value);
        }

        [Fact]
        public async Task RemoveFromFavorites_EventNotFavorited_ShouldReturnBadRequest()
        {
            // Arrange
            var userId = "user123";
            var eventId = 1;
            _favoritesRepositoryMock.Setup(r => r.IsEventFavoritedByUserAsync(userId, eventId))
                                    .ReturnsAsync(false);

            _controller.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext()
            {
                HttpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext()
                {
                    User = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(new System.Security.Claims.Claim[]
                    {
                        new System.Security.Claims.Claim("userId", userId)
                    }))
                }
            };

            // Act
            var result = await _controller.RemoveFromFavorites(eventId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Este evento não está nos favoritos.", badRequestResult.Value);
        }

        [Fact]
        public async Task RemoveFromFavorites_SuccessfullyRemoved_ShouldReturnOk()
        {
            // Arrange
            var userId = "user123";
            var eventId = 1;
            _favoritesRepositoryMock.Setup(r => r.IsEventFavoritedByUserAsync(userId, eventId))
                                    .ReturnsAsync(true);
            _favoritesRepositoryMock.Setup(r => r.RemoveFavoriteAsync(userId, eventId))
                                    .ReturnsAsync(true);

            _controller.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext()
            {
                HttpContext = new Microsoft.AspNetCore.Http.DefaultHttpContext()
                {
                    User = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(new System.Security.Claims.Claim[]
                    {
                        new System.Security.Claims.Claim("userId", userId)
                    }))
                }
            };

            // Act
            var result = await _controller.RemoveFromFavorites(eventId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Evento removido dos favoritos.", okResult.Value);
        }

    }
}
