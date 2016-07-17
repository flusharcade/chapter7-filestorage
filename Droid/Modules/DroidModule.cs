// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOSModule.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Droid.Modules
{
	using FileStorage.Portable.Ioc;

	using Autofac;

	using FileStorage.Droid.Location;
	using FileStorage.Droid.Extras;

	using FileStorage.Portable.Extras;

	using FileStorage.Portable.Location;

	/// <summary>
	/// Droid module.
	/// </summary>
	public class DroidModule : IModule
	{
		#region Public Methods

		/// <summary>
		/// Register the specified builer.
		/// </summary>
		/// <param name="builer">Builer.</param>
		public void Register(ContainerBuilder builer)
		{
			builer.RegisterType<GeoFileStorageDroid>().As<IGeoFileStorage>().SingleInstance();
			builer.RegisterType<DroidMethods>().As<IMethods>().SingleInstance();
		}

		#endregion
	}
}