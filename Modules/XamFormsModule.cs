// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PCLModule.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Modules
{
	using System;
	using System.Windows.Input;

	using Autofac;

	using Xamarin.Forms;

	using Locator.Portable.Ioc;
	using Locator.Pages;
	using Locator.UI;

	using Locator.Portable.UI;

	public class XamFormsModule : IModule
	{
		public void Register(ContainerBuilder builer)
		{
			builer.RegisterType<MainPage> ().SingleInstance();
			builer.RegisterType<MapPage> ().SingleInstance();

			builer.RegisterType<Xamarin.Forms.Command> ().As<ICommand>().SingleInstance();

			builer.Register (x => new NavigationPage(x.Resolve<MainPage>())).AsSelf().SingleInstance();

			builer.RegisterType<NavigationService> ().As<INavigationService>().SingleInstance();
		}
	}
}

