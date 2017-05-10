﻿using AutoMapper;
using PostKek.Data;
using PostKek.Models.BindingModels;
using PostKek.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PostKek
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Post, SinglePostVm>();
                expression.CreateMap<Comment, SingleCommenVm>();
                expression.CreateMap<User, IndexViewModel>();
                expression.CreateMap<Post, EditPostBm>();
                expression.CreateMap<User, SingleUserVm>();
            });
        }
    }
}
