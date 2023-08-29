using AutoMapper;
using AutoMapper.Execution;
using PhoneBookHumanGroupEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookHumanGroupEL.Entities;
using PhoneBookHumanGroupEL.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookHumanGroupEL.Mappings
{
    public class Maps:Profile
    {
        //kim kime dönüşsün

        public Maps()
        {
            CreateMap<PhoneBookHumanGroupEL.Entities.Member, MemberVM>();
            CreateMap<MemberVM, PhoneBookHumanGroupEL.Entities.Member>();

            CreateMap<MemberPhone, MemberPhoneVM>().ReverseMap();
            // CreateMap<MemberPhoneVM, MemberPhone>();


            CreateMap<PhoneGroup, PhoneGroupVM>().ReverseMap();

        }
    }
}
