// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationService.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.UI
{
	using System.Collections.Generic;

	internal interface INavigableXamarinFormsPage
	{
		void OnNavigatedTo(IDictionary<string, object> navigationParameters);
	}
}