using Mandrill.Model;
using Praxent.API.Client.Mailchimp;
using Praxent.Email.Model;

namespace Praxent.Email.Mailchimp
{
    public class MailChimpTransactionalEmailManager : ITransactionalEmailManager
    {
        private readonly IMandrillApiClient _mandrillApiClient;

        public MailChimpTransactionalEmailManager(IMandrillApiClient mandrillApiClient)
        {
            _mandrillApiClient = mandrillApiClient;
        }

        public void SendTransactionalEmail(TransactionalEmail transactionalEmail)
        {
            var message = new MandrillMessage()
            {
                FromEmail = transactionalEmail.FromEmail,
                ReplyTo = transactionalEmail.ReplyTo,
                Subject = transactionalEmail.Subject
            };

            message.AddTo(transactionalEmail.EmailAddress);

            foreach (var key in transactionalEmail.MergeValuesForTemplate.Keys)
            {
                message.AddRcptMergeVars(transactionalEmail.EmailAddress, key, transactionalEmail.MergeValuesForTemplate[key]);
            }
            _mandrillApiClient.SendTemplateAsync(message, transactionalEmail.TemplateName);
        }
    }
}