using AutoMapper;
using Demo.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.DTOModels;

namespace Web_API.MappingProfiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, DTOLoginUser>();
            CreateMap<DTOLoginUser, User>();
        }
    }
}
