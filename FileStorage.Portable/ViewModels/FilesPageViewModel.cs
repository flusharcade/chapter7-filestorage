// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilesPageViewModel.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System.Collections.ObjectModel;

namespace FileStorage.Portable.ViewModels
{
	using System;
	using System.Reactive.Subjects;
	using System.Reactive.Linq;
	using System.Linq;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using System.Windows.Input;

	using FileStorage.Portable.UI;

	/// <summary>
	/// Files page view model.
	/// </summary>
	public class FilesPageViewModel : ViewModelBase
	{
		#region Private Properties

		/// <summary>
		/// The address.
		/// </summary>
		private string _address;

		/// <summary>
		/// The closest address.
		/// </summary>
		private string _closestAddress;

		/// <summary>
		/// The geolocation button title.
		/// </summary>
		private string _geolocationButtonTitle = "Start";

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		/// <value>The address.</value>
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

		public ObservableCollection<FileItemViewModel> Files { get; set; }
		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FileStorage.Portable.ViewModels.MapPageViewModel"/> class.
		/// </summary>
		/// <param name="navigation">Navigation.</param>
		/// <param name="commandFactory">Command factory.</param>
		public FilesPageViewModel (INavigationService navigation, Func<Action, ICommand> commandFactory) 
			: base (navigation)
		{
			Files = new ObservableCollection<FileItemViewModel>();
		}

		#endregion

		#region Private Methods

		#endregion

		#region Public Methods

		/// <summary>
		/// Ons the appear.
		/// </summary>
		/// <returns>The appear.</returns>
		public void OnAppear()
		{

		}

		/// <summary>
		/// Ons the disppear.
		/// </summary>
		/// <returns>The disppear.</returns>
		public void OnDisppear()
		{

		}

		/// <summary>
		/// Loads the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="parameters">Parameters.</param>
		protected override async Task LoadAsync (IDictionary<string, object> parameters)
		{
		}

		#endregion
	}
}