// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOSModule.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.iOS.Modules
{
	using Autofac;

	using FileStorage.iOS.DataAccess;
	using FileStorage.iOS.Extras;
	using FileStorage.iOS.Logging;

	using FileStorage.Portable.DataAccess.Storage;
	using FileStorage.Portable.Extras;
	using FileStorage.Portable.Ioc;
	using FileStorage.Portable.Logging;

	/// <summary>
	/// IOS Module.
	/// </summary>
	public class IOSModule : IModule
	{
		#region Public Methods

		/// <summary>
		/// Register the specified builer.
		/// </summary>
		/// <param name="builer">Builer.</param>
		public void Register(ContainerBuilder builer)
		{
			builer.RegisterType<IOSMethods>().As<IMethods>().SingleInstance();
			builer.RegisterType<LoggeriOS>().As<ILogger>().SingleInstance();
			builer.RegisterType<SQLiteSetup>().As<ISQLiteSetup>().SingleInstance();
		}

		#endregion
	}
}