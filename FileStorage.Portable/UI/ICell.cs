// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICell.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Portable.UI
{
	using System;
	using System.Windows.Input;

	/// <summary>
	/// The ICell.
	/// </summary>
	public interface ICell
	{
		#region Properties

		/*/// <summary>
		/// Gets the cell identifier.
		/// </summary>
		/// <value>The cell identifier.</value>
		object CellId { get; }

		/// <summary>
		/// Gets the cell category.
		/// </summary>
		/// <value>The cell category.</value>
		object CellCategory { get; }

		/// <summary>
		/// Gets the cell description.
		/// </summary>
		/// <value>The cell description.</value>
		object CellDescription { get; }

		/// <summary>
		/// Gets the type of the cell.
		/// </summary>
		/// <value>The type of the cell.</value>
		Type CellType { get; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is rendered.
		/// </summary>
		/// <value><c>true</c> if this instance is rendered; otherwise, <c>false</c>.</value>
		bool IsRendered { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has rendered.
		/// </summary>
		/// <value><c>true</c> if this instance has rendered; otherwise, <c>false</c>.</value>
		bool HasRendered { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is in visible range.
		/// </summary>
		/// <value><c>true</c> if this instance is in visible range; otherwise, <c>false</c>.</value>
		bool IsInVisibleRange { get; set; }

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		int Position { get; set; }

		/// <summary>
		/// Gets or sets the index of the group.
		/// </summary>
		/// <value>The index of the group.</value>
		int GroupIndex { get; set; }

		/// <summary>
		/// Gets or sets the current top.
		/// </summary>
		/// <value>The current top.</value>
		int CurrentTop { get; set; }

		/// <summary>
		/// Gets or sets the current left.
		/// </summary>
		/// <value>The current top.</value>
		int CurrentLeft { get; set; }

		/// <summary>
		/// Gets or sets the height of the cell.
		/// </summary>
		/// <value>The height of the cell.</value>
		int CellHeight { get; set; }

		/// <summary>
		/// Gets or sets the width of the cell.
		/// </summary>
		/// <value>The height of the cell.</value>
		int CellWidth { get; set; }

		/// <summary>
		/// Gets the color of the cell background.
		/// </summary>
		/// <value>The color of the cell background.</value>
		string CellBackgroundColor { get; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is selected.
		/// </summary>
		/// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
		bool IsSelected { get; set;}

		/// <summary>
		/// Occurs when cell selected.
		/// </summary>
		event EventHandler<ICell> CellSelected;

		/// <summary>
		/// Gets the select command.
		/// </summary>
		/// <value>The select command.</value>
		ICommand SelectCommand { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Apply the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		void Apply (object item);

		/// <summary>
		/// Reset this instance.
		/// </summary>
		void Reset ();

		/// <summary>
		/// Load this instance.
		/// </summary>
		void Load ();

		/// <summary>
		/// Invalidate this instance.
		/// </summary>
		void Invalidate ();
*/
		#endregion
	}
}

