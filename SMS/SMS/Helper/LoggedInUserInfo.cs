using SMS.ViewModel;

namespace SMS.Helper
{
    public class LoggedInUserInfo
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoggedInUserInfo(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public LoggedInUserInfoDTO GetLoggedInUserInfo()
        {
            try
            {
                var LoggedInUserInfo = _contextAccessor.HttpContext.User;
                var LoggedInUserId = LoggedInUserInfo.FindAll(System.Security.Claims.ClaimTypes.NameIdentifier).Select(x => x.Value).FirstOrDefault();
                var LoggedInName = LoggedInUserInfo.FindAll(System.Security.Claims.ClaimTypes.Name).Select(x => x.Value).FirstOrDefault();

                return new LoggedInUserInfoDTO
                {
                    UserId = LoggedInUserId,
                    UserName = LoggedInName,
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
