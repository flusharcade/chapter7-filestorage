﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INavigationService.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Portable.UI
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using FileStorage.Portable.Enums;

	/// <summary>
	/// Navigation service.
	/// </summary>
	public interface INavigationService
	{
		#region Methods

		/// <summary>
		/// Navigate the specified pageName and navigationParameters.
		/// </summary>
		/// <param name="pageName">Page name.</param>
		/// <param name="navigationParameters">Navigation parameters.</param>
		Task Navigate (PageNames pageName, IDictionary<string, object> navigationParameters);

		/// <summary>
		/// Pop this instance.
		/// </summary>
		Task Pop();

		#endregion
	}
}