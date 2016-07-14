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

	/// <summary>
	/// Main page.
	/// </summary>
	public partial class MainPage : ContentPage, INavigableXamarinFormsPage 
	{
		/// <summary>
		/// The view model.
		/// </summary>
		private MainPageViewModel viewModel;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Locator.Pages.MainPage"/> class.
		/// </summary>
		public MainPage ()
		{
			InitializeComponent ();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Locator.Pages.MainPage"/> class.
		/// </summary>
		/// <param name="model">Model.</param>
		public MainPage (MainPageViewModel model)
		{
			BindingContext = model;
			InitializeComponent ();
		}

		/// <summary>
		/// Called when page navigated to.
		/// </summary>
		/// <returns>The navigated to.</returns>
		/// <param name="navigationParameters">Navigation parameters.</param>
		public void OnNavigatedTo(IDictionary<string, object> navigationParameters)
		{
			this.Show (navigationParameters);
		}
	}
}