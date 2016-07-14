// --------------------------------------------------------------------------------------------------
//  <copyright file="GeolocatorDroid.cs" company="Flush Arcade Pty Ltd.">
//    Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace Locator.Droid.Location
{
	using System;
	using System.Reactive.Subjects;

	using Android.Content;
	using Android.App;
	using Android.OS;
	using Android.Locations;
	using Android.Provider;

	using Object = Java.Lang.Object;

	using Xamarin.Forms;

	using Locator.Portable.Location;

	public class GeolocatorDroid : Object, IGeolocator, ILocationListener
	{
		private string provider = string.Empty;

		public Subject<IPosition> Positions { get; set; }

		#region ILocationListener implementation

		public void OnLocationChanged (Location location)
		{
			Positions.OnNext (new Position () 
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

		private LocationManager locationManager;

		public GeolocatorDroid()
		{
			Positions = new Subject<IPosition> ();
		
			locationManager = (LocationManager) Android.App.Application.Context.GetSystemService(Context.LocationService);
			provider = LocationManager.NetworkProvider;
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		public void Start()
		{
			if (locationManager.IsProviderEnabled(provider))
			{
				locationManager.RequestLocationUpdates (provider, 2000, 1, this);
			}
			else
			{
				Console.WriteLine(provider + " is not available. Does the device have location services enabled?");
			}
		}
			
		public void Stop()
		{
			locationManager.RemoveUpdates (this);
		}

		private void RequestLocationServices()
		{
			// Build the alert dialog
			AlertDialog.Builder builder = new AlertDialog.Builder(Forms.Context);
			builder.SetTitle("Locator");
			builder.SetMessage("Would you like to enable Location Services and GPS");
			builder.SetPositiveButton("Yes", (sender, e) =>
			{
				// Show location settings when the user acknowledges the alert dialog
				Intent intent = new Intent(Settings.ActionLocationSourceSettings);
				Forms.Context.StartActivity(intent);
			});
			builder.SetNegativeButton("No", (sender, e) =>
			{
			});

			Dialog alertDialog = builder.Create();
			alertDialog.SetCanceledOnTouchOutside(false);
			alertDialog.Show();
		}
	}
}