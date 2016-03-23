// --------------------------------------------------------------------------------------------------
//  <copyright file="XamarinNavigationExtensions.cs" company="Flush Arcade Pty Ltd.">
//    Copyright (c) 2014 Flush Arcade Pty Ltd. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace Locator.UI
{
	using System;
	using System.Collections.Generic;

	using Xamarin.Forms;

	using Locator.Pages;

	using Locator.Portable.UI;
	using Locator.Portable.Enums;
	using Locator.Portable.Ioc;
	using Locator.Portable.ViewModels;

	public static class XamarinNavigationExtensions
	{
		#region Public Methods and Operators

		// for ContentPage
		public static void Show(this ContentPage page, IDictionary<string, object> parameters)
		{
			var target = page.BindingContext as ViewModelBase;

			if (target != null)
			{
				target.OnShow(parameters);
			}
		}

		#endregion
	}
}