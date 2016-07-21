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
		/// Gets or sets the contents.
		/// </summary>
		/// <value>The contents.</value>
		public string Contents { get; set; }

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