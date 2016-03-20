// --------------------------------------------------------------------------------------------------
//  <copyright file="IPosition.cs" company="Flush Arcade Pty Ltd.">
//    Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
//  </copyright>
// --------------------------------------------------------------------------------------------------

namespace Locator.Portable.Location
{
	using System;

	/// <summary>
	/// The position interface.
	/// </summary>
	public interface IPosition
	{
		double Latitude {get; set;}

		double Longitude {get; set;}
	}
}

