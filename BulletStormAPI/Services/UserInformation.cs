using System.Security.Claims;

namespace BulletStormAPI.Services
{
    public class UserInformation : IUserInformation
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private int _userId;

        public int UserId
        {
            get
            {
                if (_userId == 0)
                {
                    _userId = GetUserId();
                }
                return _userId;
            }

        }

        public UserInformation(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        private int GetUserId()
        {
            string userId = _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("You are not logged in.");
            }
            return int.Parse(userId);
        }
    }
}
