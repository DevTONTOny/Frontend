    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApi.dto;
    using WebApi.Models;
    using AutoMapper;

    namespace WebApi.Utils
    {
        public class AutoMapperProfiles: Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<CarrerasDTOCrear, Carrera>();
                CreateMap<Carrera, CarrerasDTO>().ReverseMap();
                CreateMap<AlumnosDTOCrear, Alumno>();
                CreateMap<Alumno, AlumnosDTO>().ReverseMap();
                CreateMap<AlumnosDTO, AlumnosDTOCrear>().ReverseMap();
                
            }
        }
    }