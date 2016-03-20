// --------------------------------------------------------------------------------------------------
//  <copyright file="IGeolocator.cs" company="Flush Arcade Pty Ltd.">
//    Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace Locator.Portable.Location
{
	using System;
	using System.Reactive.Subjects;

	public interface IGeolocator
	{
		Subject<IPosition> Positions { get; set; } 

		void Start();

		void Stop();
	}
}

