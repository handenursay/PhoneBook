using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookHumanGroupEL.ViewModels
{
    public class MemberVM
    {
        // Burası veritabanından aldığımız nesneyi UI'a yansttığımız nesne
        //Sayfada kullanılacak model ile veritabanındaki yapı birbirinden ayrı olsun diye DTO ya da ViewModel kullanılır
        public  int Id { get; set; }
        public  DateTime CreatedDate { get; set; }

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

        //Veritabanında bu 2 kolon YOk
        //Ama ben UI'da kişiyi sisteme üye yaparken şifre ve şifre tekrarına ihtiyacım var!
        //İşte böyle durumlarda VM/DTO bize yardım eder!
        public string? Password { get; set; }

        [Compare("Password")]
        public string? PasswordConfirm { get; set; }


    }
}
