// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileStorable.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Portable.DataAccess.Storable
{
	using Newtonsoft.Json;

    /// <summary>
    /// File storable.
    /// </summary>
	public class FileStorable : IStorable
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FileStorage.Portable.DataAccess.Storable.FileStorable"/> class.
        /// </summary>
		public FileStorable()
        {
			this.Data = string.Empty;
        }

        #endregion

        #region Public Properties

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>The key.</value>
        public string Key { get; set; }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>The data.</value>
		public string Data { get; set; }

		/// <summary>
		/// Gets or sets the auth token.
		/// </summary>
		/// <value>The auth token.</value>
		public string AuthToken { get; set; }

		/// <summary>
		/// Gets or sets the app auth token.
		/// </summary>
		/// <value>The app auth toekn.</value>
		public string AppAuthToken { get; set; }

		/// <summary>
		/// Gets or sets the application identifier.
		/// </summary>
		/// <value>The application identifier.</value>
		public string ApplicationId { get; set; }

		/// <summary>
		/// Gets or sets the name of the application.
		/// </summary>
		/// <value>The name of the application.</value>
		public string ApplicationName { get; set; }

		/// <summary>
		/// Gets or sets the provider image.
		/// </summary>
		/// <value>The provider image.</value>
		public string ProviderImage { get; set; }

		/// <summary>
		/// Gets or sets the number records.
		/// </summary>
		/// <value>The number records.</value>
		public int NumRecords { get; set; }

        #endregion

		#region Public Methods

		/// <summary>
		/// Serialize this instance.
		/// </summary>
		public void Serialize ()
		{
			Data = JsonConvert.SerializeObject (this);
		}

		#endregion
    }
}