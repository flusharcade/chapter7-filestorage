// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PortableModule.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.Modules
{
	using System;

	using Autofac;

	using Locator.Portable.Ioc;
	using Locator.Portable.ViewModels;
	using Locator.Portable.UI;
	using Locator.Portable.Location;

	using Locator.Portable.WebServices.GeocodingWebServiceController;

	/// <summary>
	/// Portable module.
	/// </summary>
	public class PortableModule : IModule
	{
		#region Public Methods

		/// <summary>
		/// Register the specified builer.
		/// </summary>
		/// <param name="builer">Builer.</param>
		public void Register(ContainerBuilder builer)
		{
			builer.RegisterType<MainPageViewModel> ().SingleInstance();
			builer.RegisterType<MapPageViewModel> ().SingleInstance();

			builer.RegisterType<Position> ().As<IPosition>().SingleInstance();

			builer.RegisterType<GeocodingWebServiceController> ().As<IGeocodingWebServiceController>().SingleInstance();
		}

		#endregion
	}
}