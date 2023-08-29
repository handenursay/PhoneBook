using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookHumanGroupEL.Entities
{
    [Table("PHONEGROUP")]
    public class PhoneGroup:BaseEntity
    {
        [Required]
        [StringLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }
        public bool IsActive { get; set; }

    }
}
