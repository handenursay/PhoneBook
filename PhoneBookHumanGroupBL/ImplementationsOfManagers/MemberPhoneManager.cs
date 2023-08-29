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
    public class MemberPhoneManager : Manager<MemberPhoneVM, MemberPhone, int>,
        IMemberPhoneManager
    {
    public MemberPhoneManager(IMemberPhoneRepo repo, IMapper mapper):base(repo,mapper, new string[] { "PhoneGroup", "Member" })
        {
                
        }
    }
}
