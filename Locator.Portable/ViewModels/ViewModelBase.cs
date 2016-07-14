﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.ViewModels
{
	using System;
	using System.ComponentModel;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using System.Reactive.Threading.Tasks;
	using System.Runtime.CompilerServices;

	using Locator.Portable.UI;

	/// <summary>
	/// The base class of all view models
	/// </summary>
	public class ViewModelBase : INotifyPropertyChanged
	{
		#region Public Events

		/// <summary>
		/// The property changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		#region 

		public INavigationService Navigation;

		#endregion

		#region Constructors

		public ViewModelBase(INavigationService navigation)
		{
			Navigation = navigation;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Raises the property changed event.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		/// <summary>
		/// </summary>
		/// <param name="parameters">
		/// </param>
		public async void OnShow(IDictionary<string, object> parameters)
		{
			LoadAsync(parameters).ToObservable().Subscribe(
				result =>
				{
					// we can add things to do after we load the view model
				}, 
				ex =>
				{
					// we can handle any areas from the load async function
				});
		}

		protected virtual async Task LoadAsync(IDictionary<string, object> parameters)
		{
		}

		#endregion
	}
}