// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WinPhoneModule.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.WinPhone.Modules
{   
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Autofac;

    using Locator.WinPhone.Location;
    using Locator.WinPhone.Extras;
    using Locator.Portable.Location;
    using Locator.Portable.Extras;
    using Locator.Portable.Ioc;

    public class WinPhoneModule : IModule
    {
        public void Register(ContainerBuilder builer)
        {
            builer.RegisterType<GeolocatorWinPhone>().As<IGeolocator>().SingleInstance();
            builer.RegisterType<WinPhoneMethods>().As<IMethods>().SingleInstance();
        }
    }
}
