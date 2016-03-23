// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapPageViewModel.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.ViewModels
{
	using System;
	using System.Reactive.Subjects;
	using System.Reactive.Linq;
	using System.Linq;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using Locator.Portable.UI;
	using Locator.Portable.Location;
	using Locator.Portable.Repositories.GeocodingRepository;

	public class MapPageViewModel : ViewModelBase
	{
		#region Constants

		private IDictionary<int, string[]> addresses = new Dictionary<int, string[]>()
		{
			{0, new string[] { "120 Rosamond Rd", "Melbourne", "Victoria" }},
			{1, new string[] { "367 George Street", "Sydney", "New South Wales" }},
			{2, new string[] { "790 Hay St", "Perth", "Western Australi" }},
			{3, new string[] { "77-90 Rundle Mall", "Adelaide", "South Australia" }},
			{4, new string[] { "233 Queen Street", "Brisbane", "Queensland" }},
		};

		#endregion

		#region Subjects

		public Subject<IPosition> LocationUpdates { get; set; } 

		public Subject<IPosition> ClosestUpdates { get; set; } 

		#endregion

		#region Private Properties
	
		private IList<IPosition> positions;

		private Position currentPosition;

		private IDisposable subscriptions;

		private readonly IGeolocator geolocator;

		private string address;

		private string closestAddress;

		private readonly IGeocodingRepository geocodingRepository;

		private int geocodesComplete = 0;

		#endregion

		#region Public Properties

		public string Address
		{
			get
			{
				return this.address;
			}

			set
			{
				if (value.Equals(this.address))
				{
					return;
				}

				this.address = value;
				this.OnPropertyChanged("Address");
			}
		}

		public string ClosestAddress
		{
			get
			{
				return this.closestAddress;
			}

			set
			{
				if (value.Equals(this.closestAddress))
				{
					return;
				}

				this.closestAddress = value;
				this.OnPropertyChanged("ClosestAddress");
			}
		}

		#endregion

		#region Constructors

		public MapPageViewModel (INavigationService navigation, IGeolocator geolocator, 
			IGeocodingRepository geocodingRepository) : base (navigation)
		{
			this.geolocator = geolocator;
			this.geocodingRepository = geocodingRepository;

			this.positions = new List<IPosition> ();
			this.LocationUpdates = new Subject<IPosition> ();
			this.ClosestUpdates = new Subject<IPosition> ();
		}

		#endregion

		#region Private Methods

		public async Task getGeocodeFromAddress(string address, string city, string state)
		{
			var geoContract = await this.geocodingRepository.GetGeocodeFromAddressAsync (address, city, state);

			if (geoContract != null && geoContract.results != null && geoContract.results.Count > 0) 
			{
				var result = geoContract.results.FirstOrDefault ();

				if (result != null && result.geometry != null && result.geometry.location != null) 
				{
					this.geocodesComplete++;

					this.positions.Add(new Position () 
						{
							Latitude = result.geometry.location.lat,
							Longitude = result.geometry.location.lng,
							Address = string.Format("{0}, {1}, {2}", address, city, state)
						});

					// once all geocodes are found, find the closest
					if (this.geocodesComplete == this.positions.Count)
					{
						this.findNearestSite ();
					}
				}
			}
		}

		private double degreesToRadians(double deg) 
		{
			return deg * Math.PI / 180;
		}

		private double pythagorasEquirectangular(double lat1, double lon1, double lat2, double lon2)
		{
			lat1 = this.degreesToRadians(lat1);
			lat2 = this.degreesToRadians(lat2);
			lon1 = this.degreesToRadians(lon1);
			lon2 = this.degreesToRadians(lon2);

			// within a 10km radius
			var radius = 10000;
			var x = (lon2 - lon1) * Math.Cos((lat1 + lat2) / 2);
			var y = (lat2 - lat1);
			var distance = Math.Sqrt(x * x + y * y) * radius;

			return distance;
		}

		/// <summary>
		/// Finds the nearest site.
		/// </summary>
		private async void findNearestSite()
		{
			double mindif = 99999;
			IPosition closest = null;
			var closestIndex = 0;
			var index = 0;

			foreach (var position in this.positions)
			{
				var difference = this.pythagorasEquirectangular(this.currentPosition.Latitude, this.currentPosition.Longitude,
					position.Latitude, position.Longitude);

				if (difference < mindif)
				{
					closest = position;
					closestIndex = index;
					mindif = difference;
				}

				index++;
			}

			if (closest != null) 
			{
				var array = this.addresses [closestIndex];
				this.Address == string.Format("{0}, {1}, {2}", array[0], array[1], array[2]);
				this.ClosestUpdates.OnNext (closest);
			}
		}

		#endregion

		#region Methods

		public void OnAppear()
		{
			this.geolocator.Start ();
			this.subscriptions = this.geolocator.Positions.Subscribe (x => 
				{
					this.findNearestSite();
					this.LocationUpdates.OnNext(x);
				});
		}

		public void OnDisppear()
		{
			this.geolocator.Stop ();

			if (this.subscriptions != null) 
			{
				this.subscriptions.Dispose ();
			}
		}

		protected override async Task LoadAsync (IDictionary<string, object> parameters)
		{
			var index = 0;

			foreach (var address in this.addresses) 
			{
				var array = this.addresses [index];
				this.getGeocodeFromAddress (array[0], array[1], array[2]);
				index++;
			}
		}

		#endregion
	}
}

