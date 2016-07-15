// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SharedNetworkModule.cs" company="Flush Arcade Pty Ltd">
//   Copyright (c) 2015 Flush Arcade Pty Ltd All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Locator.Shared.Modules
{
	using System;
	using System.Net;
	using System.Net.Http;

	using ModernHttpClient;

	using Autofac;

	using Locator.Portable.Ioc;

	public sealed class SharedModule : IModule
	{
		#region Fields

		private bool _isWindows;

		#endregion

		#region Constructors and Destructors

		public SharedModule(bool isWindows)
		{
			_isWindows = isWindows;
		}

		#endregion

		#region Public Methods and Operators

		public void Register(ContainerBuilder builder)
		{
			HttpClientHandler clientHandler = _isWindows ? new HttpClientHandler() : new NativeMessageHandler();
			clientHandler.UseCookies = false;
			clientHandler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
			builder.Register(cb => clientHandler).As<HttpClientHandler>().SingleInstance();
		}
			
		#endregion
	}
}