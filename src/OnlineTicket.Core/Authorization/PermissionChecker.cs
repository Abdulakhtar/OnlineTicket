using Abp.Authorization;
using OnlineTicket.Authorization.Roles;
using OnlineTicket.Authorization.Users;

namespace OnlineTicket.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
