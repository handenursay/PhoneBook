using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookHumanGroupEL.ViewModels
{
    public class PhoneGroupVM
    {
        public  int Id { get; set; }

        public  DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
