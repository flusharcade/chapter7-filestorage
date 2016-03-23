// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPage.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Pages
{
	using System;
	using System.Collections.Generic;

	using Xamarin.Forms;

	using Locator.Portable.ViewModels;
	using Locator.Portable.Ioc;
	using Locator.UI;

	public partial class MainPage : ContentPage, INavigableXamarinFormsPage 
	{
		private MainPageViewModel viewModel;

		public MainPage ()
		{
			this.InitializeComponent ();
		}

		public MainPage (MainPageViewModel model)
		{
			this.BindingContext = model;
			this.InitializeComponent ();
		}

		public void OnNavigatedTo(IDictionary<string, object> navigationParameters)
		{
			this.Show (navigationParameters);
		}
	}
}

