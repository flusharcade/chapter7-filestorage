// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Flush Arcade">
//   Copyright (c) 2015 Flush Arcade All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Portable.Ioc
{
	using System;
	using System.Collections.Generic;

	using Autofac;

	public static class IoC
	{
		public static IContainer Container { get; private set; }

		private static ContainerBuilder builder;

		public static void CreateContainer() 
		{
			builder = new ContainerBuilder();
		}

		public static void StartContainer()
		{
			Container = builder.Build();
		}

		public static void RegisterModule(IModule module)
		{
			module.Register (builder);
		}

		public static void RegisterModules(IEnumerable<IModule> modules)
		{
			foreach (var module in modules) 
			{
				module.Register (builder);
			}
		}

		public static T Resolve<T>()
		{
			return Container.Resolve<T> ();
		}
	}
}

