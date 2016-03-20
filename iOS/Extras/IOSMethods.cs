// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOSMethods.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.iOS.Extras
{
	using UIKit;

	/// <summary>
	/// The methods interface
	/// </summary>
	public class IOSMethods
	{
		public void Exit()
		{
			UIApplication.SharedApplication.PerformSelector(new ObjCRuntime.Selector("terminateWithSuccess"), null, 0f);
		}
	}
}

