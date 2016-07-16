// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOSModule.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.iOS.Modules
{
	using Autofac;

	using Locator.iOS.Location;
	using Locator.iOS.Extras;

	using Locator.Portable.Extras;
	using Locator.Portable.Ioc;
	using Locator.Portable.Location;

	/// <summary>
	/// IOS Module.
	/// </summary>
	public class IOSModule : IModule
	{
		#region Public Methods

		/// <summary>
		/// Register the specified builer.
		/// </summary>
		/// <param name="builer">Builer.</param>
		public void Register(ContainerBuilder builer)
		{
			builer.RegisterType<GeolocatorIOS>().As<IGeolocator>().SingleInstance();
			builer.RegisterType<IOSMethods>().As<IMethods>().SingleInstance();
		}

		#endregion
	}
}