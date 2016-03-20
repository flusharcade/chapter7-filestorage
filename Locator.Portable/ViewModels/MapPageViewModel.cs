// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapPageViewModel.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.ViewModels
{
	using System;
	using System.Windows.Input;
	using System.Reactive.Subjects;

	using Locator.Portable.UI;
	using Locator.Portable.Location;

	public class MapPageViewModel : ViewModelBase
	{
		#region Events

		public Subject<IPosition> LocationUpdates { get; set; } 

		#endregion

		#region Private Properties
	
		private IDisposable subscriptions;

		private readonly IGeolocator geolocator;

		private string address;

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

		#endregion

		#region Constructors

		public MapPageViewModel (INavigationService navigation, IGeolocator geolocator) : base (navigation)
		{
			this.geolocator = geolocator;
			this.LocationUpdates = new Subject<IPosition> ();
		}

		#endregion

		#region Methods

		public void OnAppear()
		{
			this.geolocator.Start ();
			this.subscriptions = this.geolocator.Positions.Subscribe (this.LocationUpdates.OnNext);
		}

		public void OnDisppear()
		{
			this.geolocator.Stop ();

			if (this.subscriptions != null) 
			{
				this.subscriptions.Dispose ();
			}
		}

		#endregion
	}
}

