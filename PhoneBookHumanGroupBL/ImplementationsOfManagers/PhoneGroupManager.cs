using AutoMapper;
using PhoneBookHumanGroupBL.InterfacesOfManagers;
using PhoneBookHumanGroupDL.InterfacesofRepos;
using PhoneBookHumanGroupEL.Entities;
using PhoneBookHumanGroupEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookHumanGroupBL.ImplementationsOfManagers
{
    public class PhoneGroupManager:Manager<PhoneGroupVM,PhoneGroup,int>, IPhoneGroupManager
    {
        public PhoneGroupManager(IPhoneGroupRepo r,IMapper m):base(r,m,null)
        {
                
        }
    }
}
