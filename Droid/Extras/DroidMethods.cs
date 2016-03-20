// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMethods.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Droid.Extras
{
	/// <summary>
	/// The methods interface
	/// </summary>
	public class DroidMethods
	{
		public void Exit()
		{
			Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
		}
	}
}

