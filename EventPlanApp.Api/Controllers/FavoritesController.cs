using EventPlanApp.Application.Interfaces;
using EventPlanApp.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly IFavoritesRepository _favoritesRepository;
        private readonly FavoriteService _favoriteService;

        public FavoritesController(IFavoritesRepository favoritesRepository, FavoriteService favoriteService)
        {
            _favoritesRepository = favoritesRepository;
            _favoriteService = favoriteService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int eventId)
        {
            // Obtém o ID do usuário autenticado
            var userId = User.FindFirst("userId")?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            // Verifica se o evento já está na lista de favoritos do usuário
            var isFavorited = await _favoritesRepository.IsEventFavoritedByUserAsync(userId, eventId);
            if (isFavorited)
            {
                return BadRequest("Este evento já está nos favoritos.");
            }

            // Adiciona o evento aos favoritos
            await _favoritesRepository.AddToFavoritesAsync(userId, eventId);
            return Ok("Evento adicionado aos favoritos.");
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetFavorites(string userId)
        {
            var favorites = await _favoriteService.GetFavoritesByUserIdAsync(userId);

            if (favorites == null || !favorites.Any())
            {
                return NotFound("Nenhum favorito encontrado.");
            }

            return Ok(favorites);
        }
    }
}
