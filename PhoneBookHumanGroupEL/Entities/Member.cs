using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookHumanGroupEL.Entities
{
    [Table("MEMBER")]
    public class Member:BaseEntity
    {
        [Required]
        [StringLength(50)]
        [MinLength(2)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(2)]
        public string Surname { get; set; }
        public byte? Gender { get; set; }
        public DateTime? BirthDate { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public byte[] Salt { get; set; }

        public bool IsActive { get; set; }


    }
}
