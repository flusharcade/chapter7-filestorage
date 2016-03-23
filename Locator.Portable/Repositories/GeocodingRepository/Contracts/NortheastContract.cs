// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NortheastContract.cs" company="Health Connex">
//   Copyright (c) 2015 Health Connex All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.Repositories.GeocodingRepository.Contracts
{
	using System.Collections.Generic;

    /// <summary>
    /// Northeast contract.
    /// </summary>
	public sealed class NortheastContract
    {
        #region Public Properties

		/// <summary>
		/// Gets or sets the lat.
		/// </summary>
		/// <value>The lat.</value>
		public double lat { get; set; }

		/// <summary>
		/// Gets or sets the lng.
		/// </summary>
		/// <value>The lng.</value>
		public double lng { get; set; }

        #endregion
    }
}
