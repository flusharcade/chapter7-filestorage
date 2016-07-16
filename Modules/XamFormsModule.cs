// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XamFormsModule.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
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
		#region Public Methods

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

		#endregion
	}
}