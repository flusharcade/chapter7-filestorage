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
	public class Position : IPosition
	{
		public double Latitude {get; set;}

		public double Longitude {get; set;}

		public string Address {get; set;}
	}
}

