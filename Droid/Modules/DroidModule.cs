// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOSModule.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Droid.Modules
{
	using Locator.Portable.Ioc;

	using Autofac;

	using Locator.Droid.Location;
	using Locator.Droid.Extras;

	using Locator.Portable.Extras;

	using Locator.Portable.Location;

	/// <summary>
	/// Droid module.
	/// </summary>
	public class DroidModule : IModule
	{
		/// <summary>
		/// Register the specified builer.
		/// </summary>
		/// <param name="builer">Builer.</param>
		public void Register(ContainerBuilder builer)
		{
			builer.RegisterType<GeolocatorDroid>().As<IGeolocator>().SingleInstance();
			builer.RegisterType<DroidMethods>().As<IMethods>().SingleInstance();
		}
	}
}

