using MessagePack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBookHumanGroupBL.EmailSenderManager;
using PhoneBookHumanGroupBL.IEmailSender;
using PhoneBookHumanGroupBL.InterfacesOfManagers;
using PhoneBookHumanGroupEL.ViewModels;
using PhoneBookHumanGroupPL.Models;
using System.Diagnostics;

namespace PhoneBookHumanGroupPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemberManager _memberManager;
        private readonly IMemberPhoneManager _memberPhoneManager;
        private readonly IPhoneGroupManager _phoneGroupManager;
        private readonly IEmailSender _emailSender;

        public HomeController(ILogger<HomeController> logger, IMemberManager memberManager, IMemberPhoneManager memberPhoneManager, IPhoneGroupManager phoneGroupManager, IEmailSender emailSender)
        {
            _logger = logger;
            _memberManager = memberManager;
            _memberPhoneManager = memberPhoneManager;
            _phoneGroupManager = phoneGroupManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize] //login olmadan bu sayfaya erişmesini istemiyoruz
        [HttpGet]
        public IActionResult Phones()
        {
            try
            {
                //kim giriş yaptı ise ona ait telefon rehberini sayfaya göndereceğiz
                var loggedInUserEmail = HttpContext.User.Identity?.Name;

                //email adresinden member tablosundan useri bulacağız böylece idsini memberphone tablosundki FK için kullanabiliriz
                var user = _memberManager.GetByCondition(x => x.Email.ToLower() == loggedInUserEmail.ToLower()).Data;

                //select * from MemberPhone where MemberId=idno
                var phones = _memberPhoneManager.GetAll(x => x.MemberId == user.Id).Data;

                if (phones == null)
                {
                    ViewBag.PhonesPageMsg = $"Rehberinizde kayıtlı kişi henüz yoktur!";
                    return View(new List<MemberPhoneVM>());
                }
                else
                {
                    return View(phones);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata oluştu!");
                //ex loglanacak
                return View();
            }
        }

        [Authorize]
        public IActionResult PhoneAdd()
        {
            try
            {
                // Müşterinin istediği tasarıma göre
                //Sayfaya phonegrouplar gitmelidir
                var phoneGroups = _phoneGroupManager.GetAll(x => x.IsActive).Data;
                if (phoneGroups == null)
                {
                    ViewBag.PhoneGroups = new List<PhoneGroupVM>();
                    ViewBag.DefaultPhoneGroupId = 0;
                }
                else
                {
                    ViewBag.PhoneGroups = phoneGroups;

                    ViewBag.DefaultPhoneGroupId = phoneGroups.FirstOrDefault().Id;
                }

                return View(new MemberPhoneVM());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata oluştu!");
                ViewBag.PhoneGroups = new List<PhoneGroupVM>();
                //ex loglanacak
                return View();
            }
        }



        [HttpPost]
        [Authorize]
        public IActionResult PhoneAdd(MemberPhoneVM model)
        {
            try
            {
                var phoneGroups = _phoneGroupManager.GetAll(x => x.IsActive).Data;
                if (phoneGroups == null)
                    ViewBag.PhoneGroups = new List<PhoneGroupVM>();

                else
                    ViewBag.PhoneGroups = phoneGroups;


                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                //İşlemi yapan user
                //kim giriş yaptı ise ona ait telefon rehberini sayfaya göndereceğiz
                var loggedInUserEmail = HttpContext.User.Identity?.Name;

                //email adresinden member tablosundan useri bulacağız böylece idsini memberphone tablosundki FK için kullanabiliriz
                var user = _memberManager.GetByCondition(x => x.Email.ToLower() == loggedInUserEmail.ToLower()).Data;

                //Eğer PhoneGRoupId=0 gelirse.....
                if (model.PhoneGroupId == 0)
                {

                    var phoneGrp = new PhoneGroupVM()
                    {
                        CreatedDate = DateTime.Now,
                        Name = model.AnotherPhoneGroupName,
                        IsActive = true
                    };

                    var isSamephoneGrp = _phoneGroupManager.GetByCondition(x => x.Name.ToLower() == model.AnotherPhoneGroupName.ToLower() && x.IsActive).Data;

                    if (isSamephoneGrp == null)
                    {
                        var result = _phoneGroupManager.Add(phoneGrp).Data;
                        model.PhoneGroupId = result.Id;
                    }
                    else
                    {
                        model.PhoneGroupId = isSamephoneGrp.Id;
                    }

                }
                model.MemberId = user.Id;
                model.CreatedDate = DateTime.Now;
                model.PhoneNumber = $"{model.CountryPhoneCode} {model.Phone}";

                //Aynı telefondan zaten var mı?

                if (_memberPhoneManager.GetAll(x => x.PhoneNumber == model.PhoneNumber).Data.Count > 0)
                {
                    ModelState.AddModelError("", $"{model.PhoneNumber} rehberde zaten eklidir!");
                    return View(model);

                }



                if (_memberPhoneManager.Add(model).IsSuccess)
                {
                    TempData["PhoneAddSuccessMsg"] = $"{model.PhoneGroupNameSurname} Rehber Eklendi! ";

                    #region MailGonderelim
                    EmailMessageModel m = new EmailMessageModel()
                    {
                        To=user.Email,
                        Subject=$"Human Group Telefon Rehberi - Rehbere Yeni Kişi Eklendi!",
                        Body=$"<p>Merhaba {user.Name} {user.Surname}, </p> <br/> <p> Rehberinize {model.PhoneGroupNameSurname} adlı kişiyi eklediniz. </p>"
                    };

                    _emailSender.SendEmail(m);

                    #endregion

                    return RedirectToAction("Phones", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "REhbere Kişi eklenemedi! Tekrar deneyiniz!");
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik bir hata oluştu!");
                return View(model);

            }
        }
    }
}



