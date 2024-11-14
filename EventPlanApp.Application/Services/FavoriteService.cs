using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Interfaces;
using EventPlanApp.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Services
{
    public class FavoriteService
    {
        private readonly IFavoritesRepository _favoriteRepository;
        private readonly IMapper _mapper;

        public FavoriteService(IFavoritesRepository favoriteRepository, IMapper mapper)
        {
            _favoriteRepository = favoriteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventoDto>> GetFavoritesByUserIdAsync(string userId)
        {
            var favorites = await _favoriteRepository.GetFavoritesByUserIdAsync(userId);

            // Retorna os eventos favoritos mapeados para DTOs
            return favorites.Select(f => _mapper.Map<EventoDto>(f.Evento)).ToList();
        }
        public async Task<bool> RemoveFromFavoritesAsync(string userId, int eventId)
        {
            // Remove a relação entre o usuário e o evento no banco de dados
            var success = await _favoriteRepository.RemoveFavoriteAsync(userId, eventId);
            return success;
        }
    }
}
