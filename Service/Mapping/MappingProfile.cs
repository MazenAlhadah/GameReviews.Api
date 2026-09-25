using AutoMapper;
using Domain.Entities;
using Service.DTOs.Category;
using Service.DTOs.Game;
using Service.DTOs.Review;
using Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User,UserDto>();
            CreateMap<Game, GameDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Category, CategoryDto>();

            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<CreateGameDto, Game>();
            CreateMap<UpdateGameDto, Game>();

            CreateMap<CreateReviewDto, Review>();
            CreateMap<UpdateReviewDto, Review>();

            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();


        }
    }
}
