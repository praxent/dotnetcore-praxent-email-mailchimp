using Autofac;

namespace Praxent.Email.Mailchimp
{
    public static class Bootstrapper
    {
        public static ContainerBuilder ExtendEmailSystemWithMailChimp(this ContainerBuilder builder)
        {
            builder.RegisterType<MailChimpTransactionalEmailManager>().As<ITransactionalEmailManager>();

            return builder;
        }
    }
}