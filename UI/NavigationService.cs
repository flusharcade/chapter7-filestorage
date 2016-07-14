// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationService.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.UI
{
	using System.Threading.Tasks;
	using System.Collections.Generic;

	using Xamarin.Forms;

	using Locator.Pages;

	using Locator.Portable.UI;
	using Locator.Portable.Enums;
	using Locator.Portable.Ioc;

	public class NavigationService : INavigationService
	{
		#region INavigationService implementation

		public async Task Navigate (PageNames pageName, IDictionary<string, object> navigationParameters)
		{
			var page = GetPage (pageName);

			if (page != null) 
			{
				var navigablePage = page as INavigableXamarinFormsPage;

				if (navigablePage != null) 
				{
					await IoC.Resolve<NavigationPage> ().PushAsync (page);
					navigablePage.OnNavigatedTo (navigationParameters);
				}
			}
		}

		#endregion

		private Page GetPage(PageNames page)
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

