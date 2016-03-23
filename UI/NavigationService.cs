// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationService.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System.Collections.Generic;

namespace Locator.UI
{
	using System;

	using Xamarin.Forms;

	using Locator.Pages;

	using Locator.Portable.UI;
	using Locator.Portable.Enums;
	using Locator.Portable.Ioc;

	public class NavigationService : INavigationService
	{
		#region INavigationService implementation

		public async void Navigate (PageNames pageName, IDictionary<string, object> navigationParameters)
		{
			var page = this.getPage (pageName);

			if (page != null) 
			{
				var navigablePage = page as INavigableXamarinFormsPage;

				if (navigablePage != null) 
				{
					await IoC.Resolve<NavigationPage> ().PushAsync (page);
					navigablePage.OnNavigatedTo ();
				}
			}
		}

		#endregion

		private Page getPage(PageNames page)
		{
			switch(page)
			{
				case PageNames.MainPage:
					return IoC.Resolve<MainPage> ();
				case PageNames.MapPage:
					return IoC.Resolve<MapPage> ();
				default:
					return null;
			}
		}
	}
}

