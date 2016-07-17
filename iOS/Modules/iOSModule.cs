// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOSModule.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.iOS.Modules
{
	using Autofac;

	using FileStorage.iOS.Extras;

	using FileStorage.Portable.Extras;
	using FileStorage.Portable.Ioc;

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
		}

		#endregion
	}
}