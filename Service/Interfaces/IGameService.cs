using Service.DTOs.Game;
using Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IGameService
    {
        public Task<IEnumerable<GameDto>> GetAll();
        public Task<GameDto?> GetById(int id);
        public Task<GameDto> Create(CreateGameDto game);
        public Task<GameDto?> Update(UpdateGameDto game);
        public Task<bool> Delete(int id);
    }
}
