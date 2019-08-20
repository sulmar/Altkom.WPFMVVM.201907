using Autofac;
using SWOP.Transport.DbRepositories;
using SWOP.Transport.DbRepositories.Initializers;
using SWOP.Transport.FakeRepositories;
using SWOP.Transport.FakeRepositories.Fakers;
using SWOP.Transport.IRepositories;
using SWOP.Transport.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWOP.Transport.WPFClient
{
    public class ViewModelLocator
    {
        // PM> Install-Package AutoFac
        private IContainer container;

        public ViewModelLocator()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //builder.RegisterType<EmployeesViewModel>();
            //builder.RegisterType<VehiclesViewModel>();

            builder.RegisterAssemblyTypes(typeof(ViewModelBase).Assembly)
                .Where(t => t.IsSubclassOf(typeof(ViewModelBase)));

            //builder.RegisterType<FakeEmployeeRepository>().As<IEmployeeRepository>();
            // builder.RegisterType<FakeVehicleRepository>().As<IVehicleRepository>();

            builder.RegisterType<DbEmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<DbVehicleRepository>().As<IVehicleRepository>();
            builder.RegisterType<TransportContext>();

            builder.RegisterType<TransportDbInitializer>().As<IDatabaseInitializer<TransportContext>>();

            //builder.RegisterGeneric(typeof(FakeEntityRepository<>))
            //    .As(typeof(IEntityRepository<>));


            builder.RegisterType<FileProfileRepository>().As<IProfileRepository>();

            builder.RegisterType<FrameNavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<MyAuthorizeService>().As<IAuthorizeService>().SingleInstance();

            builder.RegisterType<VehicleFaker>();
            builder.RegisterType<PolicemanFaker>();
            builder.RegisterType<CivilFaker>();

            container = builder.Build();
        }

        // public ShellViewModel ShellViewModel => new ShellViewModel(new FrameNavigationService());
        // public VehiclesViewModel VehiclesViewModel => new VehiclesViewModel(new FakeVehicleRepository(new FakeRepositories.Fakers.VehicleFaker()));
        // public EmployeesViewModel EmployeesViewModel => new EmployeesViewModel(new FakeEmployeeRepository());
        // public LoginViewModel LoginViewModel => new LoginViewModel(new FileProfileRepository(), new FrameNavigationService());

        public ShellViewModel ShellViewModel => container.Resolve<ShellViewModel>();
        public LoginViewModel LoginViewModel => container.Resolve<LoginViewModel>();
        public VehiclesViewModel VehiclesViewModel => container.Resolve<VehiclesViewModel>();
        public EmployeesViewModel EmployeesViewModel => container.Resolve<EmployeesViewModel>();
        public VehicleViewModel VehicleViewModel => container.Resolve<VehicleViewModel>();

    }
}
