// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INavigationService.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.UI
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Locator.Portable.Enums;

	public interface INavigationService
	{
		Task Navigate (PageNames pageName, IDictionary<string, object> navigationParameters);
	}
}

