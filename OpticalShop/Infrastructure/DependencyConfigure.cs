using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using Autofac;
using OpticalShop.Data;
using System.Data.SQLite;
using OpticalShop.Core.Caching;
using System.Web.Mvc;
using OpticalShop.Service;
using OpticalShop.Service.Concret;
using OpticalShop.Service.Interface;

namespace OpticalShop.Infrastructure
{
    public class DependencyConfigure
    {
        private ContainerManager _containerManager;

        public ContainerManager ContainerManager
        {
            get
            {
                return _containerManager;
            }
        }

        public static void Initialize()
        {
            // Init SPC Engine
           /* if (Singleton<OpticalShopEngine>.Instance == null)
            {
                Singleton<SPCEngine>.Instance = SPCEngine.Init();
            }
            */
            if (Singleton<DependencyConfigure>.Instance == null)
            {
                Singleton<DependencyConfigure>.Instance = new DependencyConfigure();
                Singleton<DependencyConfigure>.Instance.RegisterDependencies();
            }

           // AutomaticSyncMainLanguage();
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            string connectionString = string.Format("data source='{0}'", WebConfiguration.LocalDatabasePath);

            builder.RegisterAssemblyTypes(typeof(MvcApplication).Assembly).PropertiesAutowired();

            builder.RegisterModule<AutofacWebTypesModule>();


            // Register Engine
           // builder.Register<IEngine>(e => Singleton<SPCEngine>.Instance).SingleInstance();

            // Register Data Access
            builder.Register<IDbContext>(
                c => new SQLiteDbContext(new SQLiteConnection(connectionString))).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            //cache manager
            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("opticalShop_cache_static").SingleInstance();

            // Register Services
            builder.RegisterType<NLogLoggingService>().As<ILoggingService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();

            var container = builder.Build();

            this._containerManager = new ContainerManager(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


        /// <summary>
        /// Automatic Sync MainLanguage to SettingService/Language
        /// </summary>
        private static void AutomaticSyncMainLanguage()
        {
            string mainLanguageCode = WebConfiguration.DefaultLanguage;

            string languageFile = HttpContext.Current.Server.MapPath("~/Content/Language_" + mainLanguageCode + ".xml");

            /*bool isReadOnly = false;
            FileAttributes attributes = System.IO.File.GetAttributes(languageFile);
            if (attributes == FileAttributes.ReadOnly)
            {
                System.IO.File.SetAttributes(languageFile, attributes & ~FileAttributes.ReadOnly);
                isReadOnly = true;
            }

            var _languages = new Languages();
            XmlSerializer xml = new XmlSerializer(typeof(Languages));
            using (FileStream fs = new FileStream(languageFile, FileMode.Open))
            {
                _languages = (Languages)xml.Deserialize(fs);
            }

            if (isReadOnly)
            {
                System.IO.File.SetAttributes(languageFile, attributes & FileAttributes.ReadOnly);
            }
            
            ISettingService settingService = Singleton<DependencyConfigure>.Instance.ContainerManager.Resolve<ISettingService>();
            var currentLanguage = settingService.GetLanguges(mainLanguageCode);
            var languageToSync = _languages.LanguagesList.Where(l => !currentLanguage.Any(
                l2 => l2.Key == l.Key && l2.Code == mainLanguageCode));
            foreach (var item in languageToSync)
            {
                settingService.UpdateLanguage(new Core.Domain.Language
                {
                    Code = mainLanguageCode,
                    Key = item.Key,
                    Text = item.Value
                });
            }*/
        }
    }
}