// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountRepository.cs" company="Health Connex">
//   Copyright (c) 2015 Health Connex All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.Repositories.GeocodingRepository
{
	using System;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Reactive.Linq;
	using System.Reactive.Subjects;
	using System.Reactive.Threading.Tasks;
	using System.Text;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using System.Threading;

	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;

	using Locator.Portable.Repositories.GeocodingRepository.Contracts;
	using Locator.Portable.Resources;

	/// <summary>
	/// Geocoding repository.
	/// </summary>
	public sealed class GeocodingRepository : IGeocodingRepository
	{
		#region Fields

		/// <summary>
		/// The client handler.
		/// </summary>
		private readonly HttpClientHandler clientHandler;

		#endregion

		#region Constructors and Destructors

		public GeocodingRepository (HttpClientHandler clientHandler)
		{
			this.clientHandler = clientHandler;
		}

		#endregion

		#region Public Methods and Operators

		public IObservable<GeocodingContract> GetGeocodeFromAddressAsync (string address, string city, string state)
		{
			var authClient = new HttpClient (this.clientHandler);

			var message = new HttpRequestMessage (HttpMethod.Get, new Uri (string.Format (ApiConfig.GoogleMapsUrl, address, city, state)));

			return Observable.FromAsync(() => authClient.SendAsync (message, new CancellationToken(false)))
				.SelectMany(async response => 
					{
						if (response.StatusCode != HttpStatusCode.OK)
						{
							throw new Exception("Respone error");
						}

						return await response.Content.ReadAsStringAsync();
					})
				.Select(json => JsonConvert.DeserializeObject<GeocodingContract>(json));
		}

		#endregion
	}
}
