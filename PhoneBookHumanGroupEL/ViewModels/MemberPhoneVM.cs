using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookHumanGroupEL.Entities;

namespace PhoneBookHumanGroupEL.ViewModels
{
    public class MemberPhoneVM
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public int PhoneGroupId { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string PhoneGroupNameSurname { get; set; }

        //REgularExpression gerekli 
        //05396796650   (0539) 679 66 50  0539-679-66-50 5396796650 +90 539 679 66 50 
        public string? PhoneNumber { get; set; }

        public int MemberId { get; set; }

        public MemberVM? Member { get; set; }

        public PhoneGroupVM? PhoneGroup { get; set; }

        public string? AnotherPhoneGroupName { get; set; } //ViewModel ya da diğer adıyla DTO classları ön yüzdeki istediğimiz işlemleri yapmak için yardımcıdır. Böylece ön yüzden aldığımız bilgileri ENTITIlerimize aktarırız.


        public string CountryPhoneCode { get; set; } // bu aslında başka tabloda olmalı
        public string Phone { get; set; } // bu aslında başka tabloda olmalı
        public static List<string> CountryPhoneCodes { get; set; } = new List<string>
        {
            "+90",
            "+1",
            "+44",
            "+35",
            "+66"
        };


    }

}
