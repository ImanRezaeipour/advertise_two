using Advertise.Core.Domains.Roles;
using Advertise.Core.Domains.Users;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Messages;
using Advertise.Service.Services.Roles;
using Advertise.Service.Services.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using StructureMap;
using StructureMap.Web;
using System;
using System.Data.Entity;
using Advertise.Service.Aspects.Validations;
using StructureMap.Building.Interception;
using StructureMap.DynamicInterception;
using StructureMap.Pipeline;

namespace Advertise.Web.Framework.StructureMap.Registeries
{
    public class AspNetIdentityRegistery : Registry
    {
        #region Public Constructors

        public AspNetIdentityRegistery()
        {
            For<BaseDbContext>().HybridHttpOrThreadLocalScoped().Use(context => (BaseDbContext)context.GetInstance<IUnitOfWork>());
            For<DbContext>().HybridHttpOrThreadLocalScoped().Use(context => (BaseDbContext)context.GetInstance<IUnitOfWork>());
            For<IUserStore<User, Guid>>().HybridHttpOrThreadLocalScoped().Use<UserStore<User, Role, Guid, UserLogin, UserRole, UserClaim>>();
            For<IRoleStore<Role, Guid>>().HybridHttpOrThreadLocalScoped().Use<RoleStore<Role, Guid, UserRole>>();
            For<IAuthenticationManager>().Use<AuthenticationManager>();
            For<ISignInService>().HybridHttpOrThreadLocalScoped().Use<SignInService>();
            For<IRoleService>().HybridHttpOrThreadLocalScoped().Use<RoleService>();
            For<IIdentityMessageService>().Use<SmsService>();
            For<IIdentityMessageService>().Use<EmailService>();
            For<IUserService>().HybridHttpOrThreadLocalScoped().Use<UserService>()
                .Ctor<IIdentityMessageService>("smsService").Is<SmsService>()
                .Ctor<IIdentityMessageService>("emailService").Is<EmailService>()
                .Setter(userService => userService.SmsService).Is<SmsService>()
                .Setter(userService => userService.EmailService).Is<EmailService>();
            //For<UserService>().HybridHttpOrThreadLocalScoped().Use(context => (UserService) context.GetInstance<IUserService>())
            //    .AddInterceptor(new DecoratorInterceptor(typeof(ValidationInterceptor),typeof(ValidationInterceptor)));
            //For<IRoleStore>().HybridHttpOrThreadLocalScoped().Use<RoleStore>();
            //For<IUserStore>().HybridHttpOrThreadLocalScoped().Use<UserStore>();
        }

        #endregion Public Constructors
    }
}