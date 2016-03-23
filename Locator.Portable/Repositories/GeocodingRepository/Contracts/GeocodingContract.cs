// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeocodingContract.cs" company="Health Connex">
//   Copyright (c) 2015 Health Connex All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.Repositories.GeocodingRepository.Contracts
{
	using System.Collections.Generic;

    /// <summary>
	/// AccountContract
    /// </summary>
	public sealed class GeocodingContract
    {
        #region Public Properties

		/// <summary>
		/// Gets or sets the results.
		/// </summary>
		/// <value>The results.</value>
		public List<GeocodingResultContract> results { get; set; }

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public string status { get; set; }

        #endregion
    }
}
