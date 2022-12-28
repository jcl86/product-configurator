//using SuperErp.Management.Domain;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using System.Security.Claims;

//namespace SuperErp.Core
//{
//    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, Role>
//    {
//        public CustomClaimsPrincipalFactory(UserManager<User> userManager,
//            RoleManager<Role> roleManager,
//            IOptions<IdentityOptions> optionsAccessor) :
//            base(userManager, roleManager, optionsAccessor)
//        { }

//        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
//        {
//            //var principal = await _userClaimsPrincipalFactory.CreateAsync(user);
//            //var token = new JwtSecurityToken(issuer, audience, principal.Claims, notBefore, expires, credentials);

//            var identity = await base.GenerateClaimsAsync(user);

//            //RoleManager.get
//            user = await ReloadUserInludingNavigationProperty(user);

//            //foreach (var claim in claims)
//            //{
//            //    identity.AddClaim(claim);
//            //}

//            return identity;
//        }

//        private async Task<User> ReloadUserInludingNavigationProperty(User user)
//        {
//            user = await UserManager.Users
//               // .Include(x => x.UserRoles).ThenInclude(x => x.Role)
//               // .Include(x => x.UserRoles).ThenInclude(x => x.Company)
//                .SingleAsync(x => x.Id == user.Id);
//            return user;
//        }
//    }
//}