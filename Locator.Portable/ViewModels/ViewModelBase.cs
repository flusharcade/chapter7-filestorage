// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.ViewModels
{
	using System;
	using System.ComponentModel;
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
			this.Navigation = navigation;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Raises the property changed event.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;

			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion
	}
}