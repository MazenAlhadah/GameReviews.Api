using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Service.DTOs.Category;
using Service.DTOs.User;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<User> _userRepository;
        public UserService(IGenericRepository<User> userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> Create(CreateUserDto user)
        {
            var User = _mapper.Map<User>(user);
            await _userRepository.Add(User);
            var result = _mapper.Map<UserDto>(User);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var User = await _userRepository.GetByIdAsync(id);
            if (User == null) return false;
            await _userRepository.Delete(User);
            return true;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<UserDto>>(users);
            return result;
        }

        public async Task<UserDto?> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;
            var result = _mapper.Map<UserDto>(user);
            return result;
        }

        public async Task<UserDto?> Update(UpdateUserDto user)
        {
            var User = await _userRepository.GetByIdAsync(user.Id);
            if (User == null) return null;
            _mapper.Map(user, User);
            await _userRepository.Update(User);
            var result = _mapper.Map<UserDto>(User);
            return result;
        }
    }
}
