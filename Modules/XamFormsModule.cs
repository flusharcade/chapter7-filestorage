// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamFormsModule.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Modules
{
	using System.Windows.Input;

	using Autofac;

	using Xamarin.Forms;

	using Locator.Portable.Ioc;
	using Locator.Pages;
	using Locator.UI;

	using Locator.Portable.UI;

	/// <summary>
	/// Xamarin forms module.
	/// </summary>
	public class XamFormsModule : IModule
	{
		/// <summary>
		/// Register the specified builer.
		/// </summary>
		/// <param name="builer">Builer.</param>
		public void Register(ContainerBuilder builer)
		{
			builer.RegisterType<MainPage> ().SingleInstance();
			builer.RegisterType<MapPage> ().SingleInstance();

			builer.RegisterType<Command> ().As<ICommand>().InstancePerDependency();

			builer.Register (x => new NavigationPage(x.Resolve<MainPage>())).AsSelf().SingleInstance();

			builer.RegisterType<NavigationService> ().As<INavigationService>().SingleInstance();
		}
	}
}