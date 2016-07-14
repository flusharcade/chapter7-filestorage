// --------------------------------------------------------------------------------------------------
//  <copyright file="GeolocatorIOS.cs" company="Flush Arcade Pty Ltd.">
//    Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace Locator.iOS.Location
{
	using System;
	using System.Reactive.Subjects;
	using System.Linq;

	using CoreLocation;
	using UIKit;

	using Locator.Portable.Location;

	public class GeolocatorIOS : IGeolocator
	{
		public Subject<IPosition> Positions { get; set; }

		private CLLocationManager locationManager;

		public GeolocatorIOS()
		{
			Positions = new Subject<IPosition> ();
		
			locationManager = new CLLocationManager();
			locationManager.PausesLocationUpdatesAutomatically = false; 

			// iOS 8 has additional permissions requirements
			if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) 
			{
				locationManager.RequestWhenInUseAuthorization ();
			}

			if (UIDevice.CurrentDevice.CheckSystemVersion (9, 0)) 
			{
				locationManager.AllowsBackgroundLocationUpdates = true;
			}
		}

		/// <summary>
		/// Handles the locations updated.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void handleLocationsUpdated (object sender, CLLocationsUpdatedEventArgs e)
		{
			var location = e.Locations.LastOrDefault ();
			if (location != null)
			{
				Console.WriteLine ("Location updated, position: " + location.Coordinate.Latitude + 
				                   "-" + location.Coordinate.Longitude);

				// fire our custom Location Updated event
				Positions.OnNext(new Position()
					{
						Latitude = location.Coordinate.Latitude,
						Longitude = location.Coordinate.Longitude,
					});
			}
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start()
		{
			if (CLLocationManager.LocationServicesEnabled) 
			{
				//set the desired accuracy, in meters
				locationManager.DesiredAccuracy = 1;
				locationManager.LocationsUpdated += handleLocationsUpdated;
				locationManager.StartUpdatingLocation();
			}
		}

		/// <summary>
		/// Stop this instance.
		/// </summary>
		public void Stop()
		{
			locationManager.LocationsUpdated -= handleLocationsUpdated;
			locationManager.StopUpdatingLocation();
		}
	}
}