using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using Strado.InVento.Core.Models;
using Strado.InVento.Core.Dtos;

namespace Strado.InVento
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /*AutoMapper Initialize*/
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<Brand, BrandsDto>();
                cfg.CreateMap<Categories, CategoriesDtos>();
                cfg.CreateMap<Parts, PartsDtos>();
                cfg.CreateMap<Address, AddressDtos>();
            });
        }

    }
}
