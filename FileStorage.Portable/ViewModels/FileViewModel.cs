// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileItemViewModel.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Portable.ViewModels
{
	using FileStorage.Portable.Enums;
	using FileStorage.Portable.UI;
	using FileStorage.Portable.Extras;

	/// <summary>
	/// File item view model.
	/// </summary>
	public class FileItemViewModel : ViewModelBase
	{
		#region Private Properties

		/// <summary>
		/// The identifier.
		/// </summary>
		private int _id;

		/// <summary>
		/// The name.
		/// </summary>
		private string _fileName;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public int Id
		{
			get
			{
				return _id;
			}

			set
			{
				if (value.Equals(_id))
				{
					return;
				}

				_id = value;
				OnPropertyChanged("Id");
			}
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string FileName
		{
			get
			{
				return _fileName;
			}

			set
			{
				if (value.Equals(_fileName))
				{
					return;
				}

				_fileName = value;
				OnPropertyChanged("Name");
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Apply the specified contract.
		/// </summary>
		/// <param name="contract">Contract.</param>
		public void Apply()
		{

		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FileStorage.Portable.ViewModels.FileItemViewModel"/> class.
		/// </summary>
		/// <param name="navigation">Navigation.</param>
		public FileItemViewModel(INavigationService navigation) : base(navigation)
		{
		}

		#endregion
	}
}