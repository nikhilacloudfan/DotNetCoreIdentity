using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Models
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<ApplicationUser, ApplicationUserModel>();
        }
    }
}
