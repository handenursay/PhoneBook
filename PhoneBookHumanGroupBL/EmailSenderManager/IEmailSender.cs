using PhoneBookHumanGroupBL.IEmailSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookHumanGroupBL.EmailSenderManager
{
    public interface IEmailSender
    {
        //from 
        //to
        //CC
        //BCC
        //subject
        //dosya ekle...ilerleyen projelerde yazarız
        bool SendEmail(EmailMessageModel model);

        Task SendMailAsync(EmailMessageModel model);
    }
}
