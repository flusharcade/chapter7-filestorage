// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModule.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.Ioc
{
	using Autofac;

	/// <summary>
	/// Module.
	/// </summary>
	public interface IModule
	{
		#region Methods

		/// <summary>
		/// Register the specified builer.
		/// </summary>
		/// <param name="builer">Builer.</param>
		void Register(ContainerBuilder builer);

		#endregion
	}
}