using EventPlanApp.Application.Interfaces;
using EventPlanApp.Application.Services;
using EventPlanApp.Domain.Entities;
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
        [HttpDelete("{eventId}")]
        public async Task<IActionResult> RemoveFromFavorites(int eventoId)
        {
            // Recupera o ID do usuário autenticado
            var userId = User.Identity.Name;

            // Verifica se o evento está nos favoritos
            var isFavorited = await _favoritesRepository.IsEventFavoritedByUserAsync(userId, eventoId);
            if (!isFavorited)
            {
                return BadRequest("Este evento não está nos favoritos.");
            }

            // Remove o evento dos favoritos
            var result = await _favoriteService.RemoveFromFavoritesAsync(userId, eventoId);
            if (result)
            {
                return Ok("Evento removido dos favoritos.");
            }

            return StatusCode(500, "Erro ao remover o evento dos favoritos.");
        }
                       
    }
}
