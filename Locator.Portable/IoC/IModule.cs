// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModule.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.Ioc
{
	using Autofac;

	public interface IModule
	{
		void Register(ContainerBuilder builer);
	}
}

