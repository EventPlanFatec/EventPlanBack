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

        public FavoritesController(IFavoritesRepository favoritesRepository)
        {
            _favoritesRepository = favoritesRepository;
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
    }
}
