// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPageViewModel.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.ViewModels
{
	using System;
	using System.Windows.Input;

	using Locator.Portable.Enums;
	using Locator.Portable.UI;
	using Locator.Portable.Extras;

	public class MainPageViewModel : ViewModelBase
	{
		#region Private Properties
	
		private readonly IMethods _methods;

		private string _descriptionMessage = "Find your location";

		private string _locationTitle = "Find Location";

		private string _exitTitle = "Exit";

		private ICommand _locationCommand;

		private ICommand _exitCommand;

		#endregion

		#region Public Properties

		public string DescriptionMessage
		{
			get
			{
				return _descriptionMessage;
			}

			set
			{
				if (value.Equals(_descriptionMessage))
				{
					return;
				}

				_descriptionMessage = value;
				OnPropertyChanged("DescriptionMessage");
			}
		}

		public string LocationTitle
		{
			get
			{
				return _locationTitle;
			}

			set
			{
				if (value.Equals(_locationTitle))
				{
					return;
				}

				_locationTitle = value;
				OnPropertyChanged("LocationTitle");
			}
		}

		public string ExitTitle
		{
			get
			{
				return _exitTitle;
			}

			set
			{
				if (value.Equals(_exitTitle))
				{
					return;
				}

				_exitTitle = value;
				OnPropertyChanged("ExitTitle");
			}
		}

		public ICommand LocationCommand
		{
			get
			{
				return _locationCommand;
			}

			set
			{
				if (value.Equals(_locationCommand))
				{
					return;
				}

				_locationCommand = value;
				OnPropertyChanged("LocationCommand");
			}
		}

		public ICommand ExitCommand
		{
			get
			{
				return _exitCommand;
			}

			set
			{
				if (value.Equals(_exitCommand))
				{
					return;
				}

				_exitCommand = value;
				OnPropertyChanged("ExitCommand");
			}
		}

		#endregion

		#region Constructors

		public MainPageViewModel (INavigationService navigation, Func<Action, ICommand> commandFactory,
			IMethods methods) : base (navigation)
		{
			_exitCommand = commandFactory (() => methods.Exit());
			_locationCommand = commandFactory (async () => await Navigation.Navigate(PageNames.MapPage, null));
		}

		#endregion
	}
}