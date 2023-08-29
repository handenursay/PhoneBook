using AutoMapper;
using PhoneBookHumanGroupBL.InterfacesOfManagers;
using PhoneBookHumanGroupDL.InterfacesofRepos;
using PhoneBookHumanGroupEL.Entities;
using PhoneBookHumanGroupEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookHumanGroupBL.ImplementationsOfManagers
{
    public class MemberManager:Manager<MemberVM,Member,int>,IMemberManager
    {
        public MemberManager(IMemberRepo repo, IMapper mapper) :base(repo,mapper,null)
        {
                
        }
    }
}
