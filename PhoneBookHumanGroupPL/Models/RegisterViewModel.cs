using System.ComponentModel.DataAnnotations;

namespace PhoneBookHumanGroupPL.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50)]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = " Lütfen isim girerken sayı kullanmayınız.")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = " Lütfen soy isim girerken sayı kullanmayınız.")]
        public string Surname { get; set; }
        public byte? Gender { get; set; }
        public DateTime? BirthDate { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        //[RegularExpression("\"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]")]
        //[RegularExpression(@"^[a-z][a-z0-9_-]*$", ErrorMessage = @"Parola küçük harf ile başlamalıdır.Sonrasında küçük harf,rakam, tire ya da alt tire kullanılabilir. ")]
        //Abdullah teşekkür ederiz
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Parolalar en az 8 karakter olmalı ve aşağıdakilerden 4'ünden 3'ünü içermelidir: büyük harf ( A-Z ), küçük harf ( a-z ), sayı ( 0-9 ) ve özel karakter ( ör. !@#$% ^ & * )")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")] 
        public string PasswordConfirm { get; set; }


    }
}
