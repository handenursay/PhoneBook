using PhoneBookHumanGroupDL.ContextInfo;
using PhoneBookHumanGroupDL.InterfacesofRepos;
using PhoneBookHumanGroupEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookHumanGroupDL.ImplementationofRepos
{
    public class MemberPhoneRepo:Repository<MemberPhone,int>,IMemberPhoneRepo
    {
        public MemberPhoneRepo(PhoneBookHumanGroupContext context):base(context)
        {
        }

    }
}
