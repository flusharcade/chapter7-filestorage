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
	using System.Windows.Input;

	using Locator.Portable.UI;
	using Locator.Portable.Location;
	using Locator.Portable.Repositories.GeocodingRepository;

	public class MapPageViewModel : ViewModelBase
	{
		#region Constants

		private IDictionary<int, string[]> _addresses = new Dictionary<int, string[]>()
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
	
		private IList<IPosition> _positions;

		private IPosition _currentPosition;

		private IDisposable _subscriptions;

		private readonly IGeolocator _geolocator;

		private readonly IGeocodingWebServiceController _geocodingWebServiceController;

		private string _address;

		private string _closestAddress;

		private string _geolocationButtonTitle = "Start";

		private bool _geolocationUpdating;

		private int _geocodesComplete = 0;

		private ICommand _nearestAddressCommand;

		private ICommand _geolocationCommand;

		#endregion

		#region Public Properties

		public string Address
		{
			get
			{
				return _address;
			}

			set
			{
				if (value.Equals(_address))
				{
					return;
				}

				_address = value;
				OnPropertyChanged("Address");
			}
		}

		public string ClosestAddress
		{
			get
			{
				return _closestAddress;
			}

			set
			{
				if (value.Equals(_closestAddress))
				{
					return;
				}

				_closestAddress = value;
				OnPropertyChanged("ClosestAddress");
			}
		}

		public string GeolocationButtonTitle
		{
			get
			{
				return _geolocationButtonTitle;
			}

			set
			{
				if (value.Equals(_geolocationButtonTitle))
				{
					return;
				}

				_geolocationButtonTitle = value;
				OnPropertyChanged("GeolocationButtonTitle");
			}
		}

		public ICommand NearestAddressCommand
		{
			get
			{
				return _nearestAddressCommand;
			}

			set
			{
				if (value.Equals(_nearestAddressCommand))
				{
					return;
				}

				_nearestAddressCommand = value;
				OnPropertyChanged("NearestAddressCommand");
			}
		}

		public ICommand GeolocationCommand
		{
			get
			{
				return _geolocationCommand;
			}

			set
			{
				if (value.Equals(_geolocationCommand))
				{
					return;
				}

				_geolocationCommand = value;
				OnPropertyChanged("GeolocationCommand");
			}
		}

		#endregion

		#region Constructors

		public MapPageViewModel (INavigationService navigation, IGeolocator geolocator, Func<Action, ICommand> commandFactory, 
			IGeocodingWebServiceController geocodingRepository) : base (navigation)
		{
			_geolocator = geolocator;
			_geocodingWebServiceController = geocodingRepository;

			_nearestAddressCommand = commandFactory(() => FindNearestSite());
			_geolocationCommand = commandFactory(() =>
			{
				if (_geolocationUpdating)
				{
					geolocator.Stop();
				}
				else
				{
					geolocator.Start();
				}

				GeolocationButtonTitle = _geolocationUpdating ? "Start" : "Stop";
				_geolocationUpdating = !_geolocationUpdating;
			});

			_positions = new List<IPosition> ();

			LocationUpdates = new Subject<IPosition> ();
			ClosestUpdates = new Subject<IPosition> ();
		}

		#endregion

		#region Private Methods

		public async Task GetGeocodeFromAddress(string address, string city, string state)
		{
			var geoContract = await _geocodingWebServiceController.GetGeocodeFromAddressAsync(address, city, state);

			if (geoContract != null && geoContract.results != null && geoContract.results.Count > 0)
			{
				var result = geoContract.results.FirstOrDefault();

				if (result != null && result.geometry != null && result.geometry.location != null)
				{
					_geocodesComplete++;

					_positions.Add(new Position()
						{
							Latitude = result.geometry.location.lat,
							Longitude = result.geometry.location.lng,
							Address = string.Format("{0}, {1}, {2}", address, city, state)
						});

					// once all geocodes are found, find the closest
					if ((_geocodesComplete == _positions.Count) && _currentPosition != null)
					{
						FindNearestSite();
					}
				}
			}
		}

		private double DegreesToRadians(double deg) 
		{
			return deg * Math.PI / 180;
		}

		private double PythagorasEquirectangular(double lat1, double lon1, double lat2, double lon2)
		{
			lat1 = DegreesToRadians(lat1);
			lat2 = DegreesToRadians(lat2);
			lon1 = DegreesToRadians(lon1);
			lon2 = DegreesToRadians(lon2);

			// within a 5km radius
			var radius = 5;
			var x = (lon2 - lon1) * Math.Cos((lat1 + lat2) / 2);
			var y = (lat2 - lat1);
			var distance = Math.Sqrt(x * x + y * y) * radius;

			return distance;
		}

		/// <summary>
		/// Finds the nearest site.
		/// </summary>
		private void FindNearestSite()
		{
			if (_geolocationUpdating)
			{
				_geolocationUpdating = false;
				_geolocator.Stop();
				GeolocationButtonTitle = "Start";
			}

			double mindif = 99999;
			IPosition closest = null;
			var closestIndex = 0;
			var index = 0;

			if (_currentPosition != null)
			{
				foreach (var position in _positions)
				{
					var difference = PythagorasEquirectangular(_currentPosition.Latitude, _currentPosition.Longitude,
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
					var array = _addresses[closestIndex];
					Address = string.Format("{0}, {1}, {2}", array[0], array[1], array[2]);
					ClosestUpdates.OnNext(closest);			
				}
			}
		}

		#endregion

		#region Methods

		public void OnAppear()
		{
			_subscriptions = _geolocator.Positions.Subscribe (x => 
				{
					_currentPosition = x;
					LocationUpdates.OnNext(x);
				});
		}

		public void OnDisppear()
		{
			_geolocator.Stop ();

			if (_subscriptions != null) 
			{
				_subscriptions.Dispose ();
			}
		}

		protected override async Task LoadAsync (IDictionary<string, object> parameters)
		{
			var index = 0;

			// all 5 tasks will run in parallel
			for (int i = 0; i < 5; i++)
			{
				var array = _addresses [index];
				index++;

				GetGeocodeFromAddress(array[0], array[1], array[2]).ConfigureAwait(false);
			}
		}

		#endregion
	}
}