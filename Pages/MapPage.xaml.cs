// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapPage.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Pages
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Xamarin.Forms;
	using Xamarin.Forms.Maps;

	using Locator.Portable.ViewModels;
	using Locator.Portable.Ioc;
	using Locator.Portable.Location;
	using Locator.UI;

	public partial class MapPage : ContentPage, INavigableXamarinFormsPage
	{
		private MapPageViewModel viewModel;

		private IDisposable locationUpdateSubscriptions;

		private IDisposable closestSubscriptions;

		private Geocoder geocoder;

		public MapPage ()
		{
			this.InitializeComponent ();
		}

		public MapPage (MapPageViewModel model)
		{
			this.viewModel = model;
			this.BindingContext = model;
			this.InitializeComponent ();

			this.Appearing += handleAppearing;
			this.Disappearing += handleDisappearing;

			this.geocoder = new Geocoder ();
		}

		private void handleDisappearing (object sender, EventArgs e)
		{
			this.viewModel.OnDisppear ();

			if (this.locationUpdateSubscriptions != null) 
			{
				this.locationUpdateSubscriptions.Dispose ();
			}

			if (this.closestSubscriptions != null) 
			{
				this.closestSubscriptions.Dispose ();
			}
		}

		private void handleAppearing (object sender, EventArgs e)
		{
			this.viewModel.OnAppear ();

			this.locationUpdateSubscriptions = this.viewModel.LocationUpdates.Subscribe (locationChanged);
			this.closestSubscriptions = this.viewModel.ClosestUpdates.Subscribe (closestChanged);
		}

		private async void locationChanged (IPosition position)
		{
			try 
			{
				var formsPosition = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

				this.MapView.MoveToRegion (MapSpan.FromCenterAndRadius (formsPosition, Distance.FromMiles (0.3)));

				var addresses = await this.geocoder.GetAddressesForPositionAsync(formsPosition);

				var mostRecent = addresses.LastOrDefault();
				if (mostRecent != null)
				{
					this.viewModel.Address = mostRecent;
				}
			}
			catch (Exception e) 
			{
				System.Diagnostics.Debug.WriteLine ("MapPage: Error with moving map region - " + e);
			}
		}

		private async void closestChanged (IPosition position)
		{
			try 
			{
				var pin = new Pin()
				{
					Type = PinType.Place,
					Position = new Xamarin.Forms.Maps.Position (position.Latitude, position.Longitude),
					Label = "Closest Location",
					Address = position.Address
				};
			}
			catch (Exception e) 
			{
				System.Diagnostics.Debug.WriteLine ("MapPage: Error with moving pin - " + e);
			}
		}

		public void OnNavigatedTo(IDictionary<string, object> navigationParameters)
		{
		}
	}
}

