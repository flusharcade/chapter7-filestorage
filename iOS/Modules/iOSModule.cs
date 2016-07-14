// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOSModule.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.iOS.Modules
{
	using Locator.Portable.Ioc;

	using Autofac;

	using Locator.iOS.Location;
	using Locator.iOS.Extras;

	using Locator.Portable.Extras;

	using Locator.Portable.Location;

	public class IOSModule : IModule
	{
		public void Register(ContainerBuilder builer)
		{
			builer.RegisterType<GeolocatorIOS>().As<IGeolocator>().SingleInstance();
			builer.RegisterType<IOSMethods>().As<IMethods>().SingleInstance();
		}
	}
}