// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GestureViewIOS.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.iOS.Renderers.GestureView
{
	using UIKit;
	using Foundation;

	using FileStorage.Controls;

	[Register("GestureViewiOS")]
	public sealed class GestureViewiOS : UIView
	{
		private UIView _mainView;

		private UISwipeGestureRecognizer _swipeLeftGestureRecognizer;
		private UISwipeGestureRecognizer _swipeRightGestureRecognizer;
		private UITapGestureRecognizer _tapGestureRecognizer;

		public GestureViewiOS()
		{
			_mainView = new UIView () { TranslatesAutoresizingMaskIntoConstraints = false };
			_mainView.BackgroundColor = UIColor.Clear;

			Add (_mainView);

			// set layout constraints for main view
			AddConstraints (NSLayoutConstraint.FromVisualFormat("V:|[mainView]|", NSLayoutFormatOptions.DirectionLeftToRight, null, new NSDictionary("mainView", _mainView)));
			AddConstraints (NSLayoutConstraint.FromVisualFormat("H:|[mainView]|", NSLayoutFormatOptions.AlignAllTop, null, new NSDictionary ("mainView", _mainView)));
		}

		public void InitGestures(GestureView swipeView)
		{
			_swipeLeftGestureRecognizer = new UISwipeGestureRecognizer (swipeView.NotifySwipeLeft);
			_swipeLeftGestureRecognizer.Direction = UISwipeGestureRecognizerDirection.Left;
			_swipeRightGestureRecognizer = new UISwipeGestureRecognizer (swipeView.NotifySwipeRight);
			_swipeRightGestureRecognizer.Direction = UISwipeGestureRecognizerDirection.Right;
			_tapGestureRecognizer = new UITapGestureRecognizer(swipeView.NotifyTouch);
			_tapGestureRecognizer.NumberOfTapsRequired = 1;

			_mainView.AddGestureRecognizer (_swipeLeftGestureRecognizer);
			_mainView.AddGestureRecognizer (_swipeRightGestureRecognizer);
			_mainView.AddGestureRecognizer (_tapGestureRecognizer);
		}
	}
}