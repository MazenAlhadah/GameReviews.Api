using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Specifications.Games;
using Service.DTOs.Game;
using Service.DTOs.User;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class GameService: IGameService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Game> _gameRepository;
        public GameService(IGenericRepository<Game> gameRepository, IMapper mapper)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
        }

        public async Task<GameDto> Create(CreateGameDto game)
        {
            var Game = _mapper.Map<Game>(game);
            await _gameRepository.Add(Game);
            var result = _mapper.Map<GameDto>(Game);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var Game = await _gameRepository.GetByIdAsync(id);
            if (Game == null) return false;
            await _gameRepository.Delete(Game);
            return true;
        }

        public async Task<IEnumerable<GameDto>> GetAll()
        {
            var games = await _gameRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GameDto>>(games);
            return result;
        }

        public async Task<GameDto?> GetById(int id)
        {
            var spec = new GameDetailsSpecification(id);
            var game = await _gameRepository.GetEntityWithSpecAsync(spec);
            if (game == null) return null;
            var result = _mapper.Map<GameDto>(game);
            return result;
        }

        public async Task<GameDto?> Update(UpdateGameDto game)
        {
            var Game = await _gameRepository.GetByIdAsync(game.Id);
            if (Game == null) return null;
            _mapper.Map(game, Game);
            await _gameRepository.Update(Game);
            var result = _mapper.Map<GameDto>(Game);
            return result;
        }
    }
}
