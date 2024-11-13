using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
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
    }
}
