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

	public partial class MapPage : ContentPage
	{
		private MapPageViewModel viewModel;

		private IDisposable subscriptions;

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

			this.subscriptions = this.viewModel.LocationUpdates.Subscribe (locationChanged);
		}

		private void handleAppearing (object sender, EventArgs e)
		{
			this.viewModel.OnAppear ();

			if (this.subscriptions != null) 
			{
				this.subscriptions.Dispose ();
			}
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
	}
}

