using AutoMapper;
using Demo.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.DTOModels;

namespace Web_API.MappingProfiles
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, DTOStudent>();
            CreateMap<DTOStudent, Student>();
        }
    }
}
