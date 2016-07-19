// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SQLiteSetup.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Droid.DataAccess
{
	using System;
	using System.IO;

	using SQLite.Net.Interop;

	using FileStorage.Portable.DataAccess;

	/// <summary>
	/// The SQLite setup object.
	/// </summary>
	public class SQLiteSetup : ISQLiteSetup
	{
		public string DatabasePath { get; set; }

		public ISQLitePlatform Platform { get; set; }

		public SQLiteSetup(ISQLitePlatform platform)
		{
			DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "filestorage.db3"); ;
			Platform = platform;
		}
	}
}