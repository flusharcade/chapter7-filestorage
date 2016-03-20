// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppDelegate.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.iOS
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Foundation;
	using UIKit;

	using Locator.iOS.Modules;

	using Locator.Modules;

	using Locator.Portable.Ioc;
	using Locator.Portable.Modules;

	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			this.initIoC ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}

		private void initIoC()
		{
			IoC.CreateContainer ();
			IoC.RegisterModule (new IOSModule());
			IoC.RegisterModule (new XamFormsModule());
			IoC.RegisterModule (new PortableModule());
			IoC.StartContainer ();
		}
	}
}

