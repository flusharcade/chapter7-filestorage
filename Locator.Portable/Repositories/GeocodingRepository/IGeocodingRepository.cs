// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGeocodingRepository.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.Repositories.GeocodingRepository
{
	using System;

	using Locator.Portable.Repositories.GeocodingRepository.Contracts;

	/// <summary>
	/// The geocoding repository interface.
	/// </summary>
	public interface IGeocodingRepository
	{
		#region Methods and Operators

		IObservable<GeocodingContract> GetGeocodeFromAddressAsync (string address, string city, string state);

		#endregion
	}
}
