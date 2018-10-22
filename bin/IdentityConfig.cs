using System;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;


namespace PRPC_CIDM4390
{
    public class EmailService : IdentityMessageService
    {
    public Task SendAsync(IdentityMessage message)
    {
        return Task.FromResult(0);
    }
    void sendMail(IdentityMessage message)
    {
        #region formatter
            string text = string.Format("Please click on this link to {0}: {1}", message.Subject, message.Body);
            string html = "Please confirm your account by clicking this link: <a href=\"" + message.Body + "\">link</a><br/>";

            html += System.Web.HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + message.Body);
        #endregion

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("joe@contoso.com");
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("joe@contoso.com", "XXXXXX");
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);
}
    }
    }