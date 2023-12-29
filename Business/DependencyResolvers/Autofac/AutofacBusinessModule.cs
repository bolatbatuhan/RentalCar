using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using CorePackages.Utilities.Helpers.FileHelper;
using CorePackages.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
        builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

        builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
        builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

        builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
        builder.RegisterType<EfUsersDal>().As<IUsersDal>().SingleInstance();

        builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
        builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

        builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
        builder.RegisterType<EfCustomersDal>().As<ICustomersDal>().SingleInstance();

        builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
        builder.RegisterType<EfRentalsDal>().As<IRentalsDal>().SingleInstance();

        builder.RegisterType<FileHelperImages>().As<IFileHelper>();
        builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
        builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
        




        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}

