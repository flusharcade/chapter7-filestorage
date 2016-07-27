// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarouselView.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Controls
{
	using System;
	using System.Windows.Input;

	using Xamarin.Forms;

	/// <summary>
	/// Carousel view.
	/// </summary>
	public partial class CarouselView : ContentView
	{
		/// <summary>
		/// The index of the selected.
		/// </summary>
		public int SelectedIndex = 0;

		/// <summary>
		/// Backing Storage for the Spacing property
		/// </summary>
		public static readonly BindableProperty SelectedCommandProperty = BindableProperty.Create<CarouselView, ICommand>(w => w.SelectedCommand, default(ICommand),
				propertyChanged: (bindable, oldvalue, newvalue) => { });

		/// <summary>
		/// Spacing added between elements (both directions)
		/// </summary>
		/// <value>The spacing.</value>
		public ICommand SelectedCommand
		{
			get { return (ICommand)GetValue(SelectedCommandProperty); }
			set { SetValue(SelectedCommandProperty, value); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FileStorage.Controls.CarouselView"/> class.
		/// </summary>
		public CarouselView()
		{
			InitializeComponent();

			GestureView.SwipeLeft += HandleSwipeLeft;
			GestureView.SwipeRight += HandleSwipeRight;
			GestureView.Touch += HandleTouch;
		}

		/// <summary>
		/// Handles the view selected.
		/// </summary>
		/// <returns>The view selected.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void HandleTouch(object sender, EventArgs e)
		{
			if (SelectedCommand != null)
			{
				var cell = CarouselScroll.GetSelectedItem(SelectedIndex);
				SelectedCommand.Execute(cell);
			}
		}

		/// <summary>
		/// Handles the swipe left.
		/// </summary>
		/// <returns>The swipe left.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void HandleSwipeLeft(object sender, EventArgs e)
		{
			if ((CarouselScroll.ScrollX + CarouselScroll.Width) < (CarouselScroll.Content.Width - CarouselScroll.Width))
			{
				SelectedIndex++;
				CarouselScroll.ScrollToAsync(CarouselScroll.ScrollX + Width + 20, 0, true);
			}
		}

		/// <summary>
		/// Handles the swipe right.
		/// </summary>
		/// <returns>The swipe right.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void HandleSwipeRight(object sender, EventArgs e)
		{
			if (CarouselScroll.ScrollX > 0)
			{
				SelectedIndex--;
				CarouselScroll.ScrollToAsync(CarouselScroll.ScrollX - Width - 20, 0, true);
			}
		}
	}
}