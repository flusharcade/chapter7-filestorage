// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GestureLayoutRenderer.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

[assembly: Xamarin.Forms.ExportRenderer(typeof(FileStorage.Controls.GestureView), typeof(FileStorage.iOS.Renderers.GestureView.GestureLayoutRenderer))]

namespace FileStorage.iOS.Renderers.GestureView
{
	using System;
	using System.Reflection;

	using Foundation;
	using UIKit;

	using Xamarin.Forms;
	using Xamarin.Forms.Platform.iOS;

	using FileStorage.Controls;

    /// <summary>
    /// Swipe layout renderer.
    /// </summary>
	public class GestureLayoutRenderer : ViewRenderer<GestureView, GestureViewiOS>
    {
		private GestureViewiOS swipeViewIOS;

		public GestureLayoutRenderer()
		{
			this.swipeViewIOS = new GestureViewiOS ();
		}

		protected override void OnElementChanged (ElementChangedEventArgs<GestureView> e)
		{
			base.OnElementChanged (e);

			if (this.Element != null) 
			{
				this.swipeViewIOS.InitGestures (this.Element);
				this.SetNativeControl (this.swipeViewIOS);
			}
		}
    }
}