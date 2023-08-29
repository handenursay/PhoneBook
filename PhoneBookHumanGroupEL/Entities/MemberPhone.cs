using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookHumanGroupEL.Entities
{
    [Table("MEMBERPHONE")]
    public class MemberPhone:BaseEntity
    {
        [Column(Order = 3)]

        public int PhoneGroupId { get; set; }
        [Required]
        [StringLength(150,MinimumLength =5)]
        [Column(Order = 4)]

        public string PhoneGroupNameSurname { get; set; }

        [Required]
        [Column(Order =5)]
        //REgularExpression gerekli 
        //05396796650   (0539) 679 66 50  0539-679-66-50 5396796650 +90 539 679 66 50 
        public string PhoneNumber { get; set; }

        [Column(Order = 6)]

        public int MemberId { get; set; }


        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }


        [ForeignKey("PhoneGroupId")]
        public virtual PhoneGroup PhoneGroup { get; set; }

    }
}
