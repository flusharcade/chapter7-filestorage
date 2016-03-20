// --------------------------------------------------------------------------------------------------
//  <copyright file="GeolocatorDroid.cs" company="Flush Arcade Pty Ltd.">
//    Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace Locator.Droid.Location
{
	using System;
	using System.Reactive.Subjects;
	using System.Linq;

	using Android.Content;
	using Android.App;
	using Android.OS;

	using Android.Locations;

	using Locator.Portable.Location;

	public class GeolocatorDroid : IGeolocator, ILocationListener
	{
		private string provider = string.Empty;

		public Subject<IPosition> Positions { get; set; }

		#region ILocationListener implementation

		public void OnLocationChanged (Location location)
		{
			this.Positions.OnNext (new Position () 
				{
					Latitude = location.Latitude,
					Longitude = location.Longitude
				});
		}

		public void OnProviderDisabled (string provider)
		{
			Console.WriteLine (provider + " disabled by user");
		}

		public void OnProviderEnabled (string provider)
		{
			Console.WriteLine (provider + " disabled by user");
		}

		public void OnStatusChanged (string provider, Availability status, Bundle extras)
		{
			Console.WriteLine (provider + " disabled by user");
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IJavaObject implementation

		public IntPtr Handle 
		{
			get 
			{
				throw new NotImplementedException ();
			}
		}

		#endregion
	
		private LocationManager locationManager;

		public GeolocatorDroid()
		{
			this.Positions = new Subject<IPosition> ();
		
			this.locationManager = (LocationManager)Application.Context.GetSystemService(Context.LocationService);
			this.provider = LocationManager.GpsProvider;
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start()
		{
			if (locationManager.IsProviderEnabled(this.provider))
			{
				locationManager.RequestLocationUpdates (this.provider, 2000, 1, this);
			}
			else
			{
				Console.WriteLine(this.provider + " is not available. Does the device have location services enabled?");
			}
		}
			
		public void Stop()
		{
			this.locationManager.RemoveUpdates (this);
		}
	}
}