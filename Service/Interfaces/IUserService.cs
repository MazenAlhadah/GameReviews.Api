using Service.DTOs.Category;
using Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDto>> GetAll();
        public Task<UserDto?> GetById(int id);
        public Task<UserDto> Create(CreateUserDto user);
        public Task<UserDto?> Update(UpdateUserDto user);
        public Task<bool> Delete(int id);
    }
}
