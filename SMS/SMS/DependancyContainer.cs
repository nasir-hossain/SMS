using SMS.Helper;
using SMS.IRepository;
using SMS.Repository;

namespace SMS
{
    public class DependancyContainer
    {
        public static void RegisterServices(IServiceCollection services, WebApplicationBuilder builder, ConfigurationManager Configuration)
        {
            services.AddTransient<IMasterService,MasterService>(); //Registering Service for Dependancy Injection
            services.AddTransient<IUserRegistration,UserRegistration>();
            services.AddTransient<SmtpService>();
        }
    }
}
