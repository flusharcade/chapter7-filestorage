// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DroidMethods.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Droid.Extras
{
	using Locator.Portable.Extras;

	/// <summary>
	/// The android methods interface
	/// </summary>
	public class DroidMethods : IMethods
	{
		public void Exit()
		{
			Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
		}
	}
}