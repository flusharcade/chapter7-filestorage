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
	
		private readonly IMethods methods;

		private string descriptionMessage = "Find your location";

		private string locationTitle = "Find Location";

		private string exitTitle = "Exit";

		private ICommand locationCommand;

		private ICommand exitCommand;

		#endregion

		#region Public Properties

		public string DescriptionMessage
		{
			get
			{
				return this.descriptionMessage;
			}

			set
			{
				if (value.Equals(this.descriptionMessage))
				{
					return;
				}

				this.descriptionMessage = value;
				this.OnPropertyChanged("DescriptionMessage");
			}
		}

		public string LocationTitle
		{
			get
			{
				return this.locationTitle;
			}

			set
			{
				if (value.Equals(this.locationTitle))
				{
					return;
				}

				this.locationTitle = value;
				this.OnPropertyChanged("LocationTitle");
			}
		}

		public string ExitTitle
		{
			get
			{
				return this.exitTitle;
			}

			set
			{
				if (value.Equals(this.exitTitle))
				{
					return;
				}

				this.exitTitle = value;
				this.OnPropertyChanged("ExitTitle");
			}
		}

		public ICommand LocationCommand
		{
			get
			{
				return this.locationCommand;
			}

			set
			{
				if (value.Equals(this.locationCommand))
				{
					return;
				}

				this.locationCommand = value;
				this.OnPropertyChanged("LocationCommand");
			}
		}

		public ICommand ExitCommand
		{
			get
			{
				return this.exitCommand;
			}

			set
			{
				if (value.Equals(this.exitCommand))
				{
					return;
				}

				this.exitCommand = value;
				this.OnPropertyChanged("ExitCommand");
			}
		}

		#endregion

		#region Constructors

		public MainPageViewModel (INavigationService navigation, Func<Action, ICommand> commandFactory,
			IMethods methods) : base (navigation)
		{
			this.exitCommand = commandFactory (() => methods.Exit());
			this.locationCommand = commandFactory (() => this.Navigation.Navigate(PageNames.MapPage));
		}

		#endregion
	}
}

