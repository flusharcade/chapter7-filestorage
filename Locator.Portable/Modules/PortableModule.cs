// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PortableModule.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
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

	public class PortableModule : IModule
	{
		public void Register(ContainerBuilder builer)
		{
			builer.RegisterType<MainPageViewModel> ().SingleInstance();
			builer.RegisterType<MapPageViewModel> ().SingleInstance();

			builer.RegisterType<Position> ().As<IPosition>().SingleInstance();
		}
	}
}