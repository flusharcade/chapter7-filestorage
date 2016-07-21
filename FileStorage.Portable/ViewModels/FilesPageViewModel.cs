﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilesPageViewModel.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Portable.ViewModels
{
	using System;
	using System.Reactive.Linq;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using System.Collections.ObjectModel;
	using System.Collections.Generic;
	using System.Threading;

	using FileStorage.Portable.UI;
	using FileStorage.Portable.Enums;
	using FileStorage.Portable.Extras;
	using FileStorage.Portable.DataAccess.Storage;
	using FileStorage.Portable.DataAccess.Storable;

	/// <summary>
	/// Files page view model.
	/// </summary>
	public class FilesPageViewModel : ViewModelBase
	{
		#region Private Properties

		/// <summary>
		/// The file factory.
		/// </summary>
		private readonly Func<FileItemViewModel> _fileFactory;

		/// <summary>
		/// The storage.
		/// </summary>
		private readonly ISQLiteStorage _storage;

		/// <summary>
		/// The create command.
		/// </summary>
		private ICommand _editFileCommand;

		/// <summary>
		/// The create file command.
		/// </summary>
		private ICommand _createFileCommand;

		/// <summary>
		/// The no files.
		/// </summary>
		private bool _noFiles;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the create command.
		/// </summary>
		/// <value>The create command.</value>
		public ICommand EditFileCommand
		{
			get
			{
				return _editFileCommand;
			}

			set
			{
				if (value.Equals(_editFileCommand))
				{
					return;
				}

				_editFileCommand = value;
				OnPropertyChanged("EditFileCommand");
			}
		}

		/// <summary>
		/// Gets or sets the create file command.
		/// </summary>
		/// <value>The create file command.</value>
		public ICommand CreateFileCommand
		{
			get
			{
				return _createFileCommand;
			}

			set
			{
				if (value.Equals(_createFileCommand))
				{
					return;
				}

				_createFileCommand = value;
				OnPropertyChanged("CreateFileCommand");
			}
		}

		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		/// <value>The address.</value>
		public bool AnyFiles
		{
			get
			{
				return _noFiles;
			}

			set
			{
				if (value.Equals(_noFiles))
				{
					return;
				}

				_noFiles = value;
				OnPropertyChanged("AnyFiles");
			}
		}

		/// <summary>
		/// Gets or sets the files.
		/// </summary>
		/// <value>The files.</value>
		public ObservableCollection<FileItemViewModel> Files { get; set; }

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FileStorage.Portable.ViewModels.MapPageViewModel"/> class.
		/// </summary>
		/// <param name="navigation">Navigation.</param>
		/// <param name="commandFactory">Command factory.</param>
		public FilesPageViewModel(INavigationService navigation, Func<Action, ICommand> commandFactory,
								   IMethods methods, ISQLiteStorage storage, Func<FileItemViewModel> fileFactory)
			: base(navigation, methods)
		{
			_storage = storage;
			_fileFactory = fileFactory;

			Files = new ObservableCollection<FileItemViewModel>();

			_editFileCommand = commandFactory(async () =>
			{
				await Navigation.Navigate(PageNames.EditFilePage, null);
			});

			_createFileCommand = commandFactory(async () =>
			{
				var fileName = await ShowEntryAlert("Enter file name:");

				if (!string.IsNullOrEmpty(fileName))
				{
					await Navigation.Navigate(PageNames.EditFilePage, new Dictionary<string, object>()
					{
						{"filename", fileName}
					});
				}
			});
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Updates the files.
		/// </summary>
		/// <returns>The files.</returns>
		private async Task UpdateFiles()
		{
			var files = await _storage.GetTable<FileStorable>(CancellationToken.None);

			Files.Clear();

			foreach (var file in files)
			{
				var fileModel = _fileFactory();
				fileModel.Apply(file);
				Files.Add(fileModel);
			}

			AnyFiles = Files.Any();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Ons the appear.
		/// </summary>
		/// <returns>The appear.</returns>
		public async void OnAppear()
		{
			await UpdateFiles();
		}

		/// <summary>
		/// Ons the disppear.
		/// </summary>
		/// <returns>The disppear.</returns>
		public void OnDisppear()
		{

		}

		/// <summary>
		/// Loads the async.
		/// </summary>
		/// <returns>The async.</returns>
		/// <param name="parameters">Parameters.</param>
		protected override async Task LoadAsync (IDictionary<string, object> parameters)
		{
			await UpdateFiles();
		}

		#endregion
	}
}