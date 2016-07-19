// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PortableModule.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Portable.Modules
{
	using System;

	using Autofac;

	using FileStorage.Portable.Ioc;
	using FileStorage.Portable.ViewModels;
	using FileStorage.Portable.UI;

	/// <summary>
	/// Portable module.
	/// </summary>
	public class PortableModule : IModule
	{
		#region Public Methods

		/// <summary>
		/// Register the specified builer.
		/// </summary>
		/// <param name="builer">Builer.</param>
		public void Register(ContainerBuilder builer)
		{
			builer.RegisterType<MainPageViewModel> ().SingleInstance();
			builer.RegisterType<FilesPageViewModel> ().SingleInstance();
			builer.RegisterType<EditFilePageViewModel>().SingleInstance();
		}

		#endregion
	}
}