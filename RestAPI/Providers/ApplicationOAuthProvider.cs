using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using RestAPI.Models;

namespace RestAPI.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
             context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            try
            {
                using (AuthRepository _repo = new AuthRepository())
                {
                    EmployeeModel user =(EmployeeModel) await _repo.FindUser(context.UserName, context.Password);

                    if (user == null)
                    {
                        context.SetError("invalid_grant", "The user name or password is incorrect.");
                        return;
                    }
                  //  var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    //identity.AddClaim(new Claim("sub", context.UserName));
                    //identity.AddClaim(new Claim("role", "user"));

                    //List<Claim> roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
                    //AuthenticationProperties properties = CreateProperties(user.UserName, Newtonsoft.Json.JsonConvert.SerializeObject(roles.Select(x => x.Value)));

                    //AuthenticationTicket ticket = new AuthenticationTicket(identity, properties);

                    ClaimsIdentity authIdentity = await _repo.claimsIdentity(user);
                    context.Validated(authIdentity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
