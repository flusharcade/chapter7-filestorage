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

	using Locator.UI;
	using Locator.Portable.ViewModels;
	using Locator.Portable.Location;

	public partial class MapPage : ContentPage, INavigableXamarinFormsPage
	{
		private MapPageViewModel viewModel;

		private IDisposable locationUpdateSubscriptions;

		private IDisposable closestSubscriptions;

		private Geocoder geocoder;

		public MapPage ()
		{
			InitializeComponent ();
		}

		public MapPage (MapPageViewModel model)
		{
			viewModel = model;
			BindingContext = model;
			InitializeComponent ();

			Appearing += HandleAppearing;
			Disappearing += HandleDisappearing;

			geocoder = new Geocoder ();
		}

		private void HandleDisappearing (object sender, EventArgs e)
		{
			viewModel.OnDisppear ();

			if (locationUpdateSubscriptions != null) 
			{
				locationUpdateSubscriptions.Dispose ();
			}

			if (closestSubscriptions != null) 
			{
				closestSubscriptions.Dispose ();
			}
		}

		private void HandleAppearing (object sender, EventArgs e)
		{
			viewModel.OnAppear ();

			locationUpdateSubscriptions = viewModel.LocationUpdates.Subscribe (LocationChanged);
			closestSubscriptions = viewModel.ClosestUpdates.Subscribe (ClosestChanged);
		}

		private void LocationChanged (IPosition position)
		{
			try 
			{
				var formsPosition = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

				geocoder.GetAddressesForPositionAsync(formsPosition)
				        .ContinueWith(_ =>
						{
							var mostRecent = _.Result.FirstOrDefault();
							if (mostRecent != null)
							{
								viewModel.Address = mostRecent;
							}
						})
				        .ConfigureAwait(false);

				MapView.MoveToRegion(MapSpan.FromCenterAndRadius(formsPosition, Distance.FromMiles(0.3)));
			}
			catch (Exception e) 
			{
				System.Diagnostics.Debug.WriteLine ("MapPage: Error with moving map region - " + e);
			}
		}

		private void ClosestChanged (IPosition position)
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

				MapView.Pins.Add(pin);

				MapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude)
				                                                 , Distance.FromMiles(0.3)));
			}
			catch (Exception e) 
			{
				System.Diagnostics.Debug.WriteLine ("MapPage: Error with moving pin - " + e);
			}
		}

		public void OnNavigatedTo(IDictionary<string, object> navigationParameters)
		{
			this.Show(navigationParameters);
		}
	}
}