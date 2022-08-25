﻿using AutoMapper;
using Messenger.Domains.Dtos.User;

namespace Messenger.Server.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, Domains.Dtos.User.UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
