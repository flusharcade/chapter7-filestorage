// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISQLiteSetup.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Portable.DataAccess.Storage
{
	using SQLite.Net.Interop;

	/// <summary>
	/// The SQLite setup object.
	/// </summary>
	public interface ISQLiteSetup
	{
		string DatabasePath { get; set; }

		ISQLitePlatform Platform { get; set; }
	}
}