using Microsoft.EntityFrameworkCore;
using PhoneBookHumanGroupEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookHumanGroupDL.ContextInfo
{
    public class PhoneBookHumanGroupContext :DbContext
    {
        public PhoneBookHumanGroupContext(DbContextOptions<PhoneBookHumanGroupContext> opt)
            :base(opt)
        {
                
        }

        public virtual DbSet<PhoneGroup> PhoneGroupTable { get; set; }
        public virtual DbSet<Member> MemberTable { get; set; }
        public virtual DbSet<MemberPhone> MemberPhoneTable { get; set; }
    }
}
