using SMS.Helper;
using SMS.IRepository;
using SMS.Repository;
using SMS.Services.UploadFile;
using SMS.Services.UploadFile.Interface;

namespace SMS
{
    public class DependancyContainer
    {
        public static void RegisterServices(IServiceCollection services, WebApplicationBuilder builder, ConfigurationManager Configuration)
        {
            services.AddTransient<IMasterService,MasterService>(); //Registering Service for Dependancy Injection
            services.AddTransient<IUserRegistration,UserRegistration>();
            services.AddTransient<SmtpService>();
            services.AddTransient<CodeGenerator>();
            services.AddTransient<LoggedInUserInfo>();
            services.AddTransient<IUploadfile, UploadFile>();
        }
    }
}
