// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator
{
	using System;

	using Xamarin.Forms;

	using Locator.Pages;

	using Locator.Portable.Ioc;

	public class App : Application
	{
		public App ()
		{
			this.MainPage = IoC.Resolve<NavigationPage> ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

