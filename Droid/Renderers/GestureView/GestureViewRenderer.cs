﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GestureViewRenderer.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

[assembly: Xamarin.Forms.ExportRenderer(typeof(FileStorage.Controls.GestureView), typeof(FileStorage.Droid.Renderers.GestureView.GestureViewRenderer))]

namespace FileStorage.Droid.Renderers.GestureView
{
	using Xamarin.Forms.Platform.Android;

	using Android.Views;
	using Android.Widget;

	using FileStorage.Controls;

	/// <summary>
	/// Gesture view renderer.
	/// </summary>
	public class GestureViewRenderer : ViewRenderer<GestureView, LinearLayout>
	{
		/// <summary>
		/// The layout.
		/// </summary>
		private LinearLayout _layout;

		/// <summary>
		/// The listener.
		/// </summary>
		private readonly GestureListener _listener;

		/// <summary>
		/// The detector.
		/// </summary>
		private readonly GestureDetector _detector;

		/// <summary>
		/// Initializes a new instance of the <see cref="Hoverboard.Droid.Renderers.GestureViewRenderer"/> class.
		/// </summary>
		public GestureViewRenderer ()
		{
			_listener = new GestureListener ();
			_detector = new GestureDetector (_listener);

			_layout = new LinearLayout (Context);
		}

		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="e">E.</param>
		protected override void OnElementChanged (ElementChangedEventArgs<GestureView> e)
		{
			base.OnElementChanged (e);

			if (e.NewElement == null) 
			{
				GenericMotion -= HandleGenericMotion;
				Touch -= HandleTouch;
			}

			if (e.OldElement == null) 
			{
				GenericMotion += HandleGenericMotion;
				Touch += HandleTouch;
			}

			if (Element != null) 
			{
				_listener.InitCoreSwipeView(Element);
			}

			SetNativeControl (_layout);
		}

		/// <summary>
		/// Handles the touch.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void HandleTouch (object sender, TouchEventArgs e)
		{
			_detector.OnTouchEvent (e.Event);
		}

		/// <summary>
		/// Handles the generic motion.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void HandleGenericMotion (object sender, GenericMotionEventArgs e)
		{
			_detector.OnTouchEvent (e.Event);
		}
	}
}