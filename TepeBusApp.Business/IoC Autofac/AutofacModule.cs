using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TepeBusApp.Business.Abstract;
using TepeBusApp.Business.Concreate;
using TepeBusApp.Data.Abstract;
using TepeBusApp.Data.Concreate;

namespace TepeBusApp.Business.IoC_Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            builder.RegisterType<TravelManager>().As<ITravelService>();
            builder.RegisterType<TravelDal>().As<ITravelDal>();

            builder.RegisterType<TicketManager>().As<ITicketService>();
            builder.RegisterType<TicketDal>().As<ITicketDal>();

            builder.RegisterType<SeatManager>().As<ISeatService>();
            builder.RegisterType<SeatDal>().As<ISeatDal>();



            builder.RegisterType<AuthManager>().As<IAuthService>();
        }
    }
}
