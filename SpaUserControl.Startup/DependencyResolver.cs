using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Pratices.Unity;
//using SpaUserControl.Business.Services;
using SpaUserControl.Domain.Contracts.Repositories;
//using SpaUserControl.Domain.Contracts.Services;
using SpaUserControl.Domain.Models;
using SpaUserControl.Infraestructure.Data;
using SpaUserControl.Infraestructure.Repositories;
using Unity;
using Unity.Lifetime;

namespace SpaUserControl.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());

            container.RegisterType<User, User>(new HierarchicalLifetimeManager());
        }
    }
}
