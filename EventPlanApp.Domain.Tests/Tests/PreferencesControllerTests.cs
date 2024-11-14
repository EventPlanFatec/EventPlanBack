using Moq;
using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Entities;
using EventPlanApp.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Microsoft.AspNetCore.Mvc;

public class PreferencesControllerTests
{
    private readonly Mock<IEventPreferenceService> _mockEventPreferenceService;
    private readonly Mock<UserPreferencesValidator> _mockUserPreferencesValidator;
    private readonly EventPlanContext _context;
    private readonly PreferencesController _controller;

    public PreferencesControllerTests()
    {
        // Criando um mock para o IEventPreferenceService
        _mockEventPreferenceService = new Mock<IEventPreferenceService>();

        // Criando um mock para o UserPreferencesValidator
        _mockUserPreferencesValidator = new Mock<UserPreferencesValidator>();

        // Criando uma instância do contexto de dados, simulando um banco de dados
        var options = new DbContextOptionsBuilder<EventPlanContext>()
            .UseInMemoryDatabase(databaseName: "EventPlanTestDb")
            .Options;
        _context = new EventPlanContext(options);

        // Instanciando o controlador com as dependências mockadas
        _controller = new PreferencesController(_context, _mockUserPreferencesValidator.Object, _mockEventPreferenceService.Object);
    }

    [Fact]
    public async Task SavePreferences_ValidPreferences_ReturnsOk()
    {
        // Arrange: Preparar os dados de teste
        var preferences = new UserPreferences
        {
            UserId = 1,
            EventType = "Music",
            Location = "NY",
            PriceRange = "Mid"
        };

        // Simular o comportamento do serviço
        _mockEventPreferenceService.Setup(x => x.SavePreferencesAsync(It.IsAny<EventPreference>())).ReturnsAsync(true);

        // Act: Chamar o método no controlador
        var result = await _controller.SavePreferences(preferences);

        // Assert: Verificar o resultado
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Preferências salvas com sucesso.", okResult.Value);
    }
}
