// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendedContentPage.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
using System.Threading.Tasks;

namespace FileStorage.UI
{
	using System;

	using Xamarin.Forms;

	using FileStorage.Portable.ViewModels;

	/// <summary>
	/// Extended content page.
	/// </summary>
	public class ExtendedContentPage : ContentPage
	{
		#region Events

		/// <summary>
		/// Occurs when touch handler.
		/// </summary>
		public event EventHandler AlertFinished;

		#endregion

		#region Private Properties

		/// <summary>
		/// The model.
		/// </summary>
		private ViewModelBase _model;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="MyCareManager.XamForms.Controls.Page.ExtendedContentPage"/> class.
		/// </summary>
		public ExtendedContentPage(ViewModelBase model)
		{
			_model = model;
			_model.Alert -= HandleAlert;
			_model.Alert += HandleAlert;
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Handles the alert.
		/// </summary>
		/// <returns>The alert.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private async void HandleAlert(object sender, string message)
		{
			await DisplayAlert("FileStorage", message, "OK");
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Override this method to execute an action when the BindingContext changes.
		/// </summary>
		/// <remarks></remarks>
		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				_model = (BindingContext as ViewModelBase);
			}
		}

		#endregion
	}
}