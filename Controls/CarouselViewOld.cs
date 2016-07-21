﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CarouselViewOld.cs" company="Flush Arcade Pty Ltd.">
//   Copyright (c) 2015 Flush Arcade Pty Ltd. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace FileStorage.Controls
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Collections.Specialized;

	using Xamarin.Forms;

	public class CarouselViewOld : ScrollView
	{
		public event EventHandler CollectionChanged;

		public enum IndicatorStyleEnum
		{
			None,
			Dots,
			Tabs
		}

		readonly StackLayout _stack;

		int _selectedIndex;

		public CarouselViewOld()
		{
			Orientation = ScrollOrientation.Horizontal;

			_stack = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Spacing = 0
			};

			Content = _stack;

			CollectionChanged += HandleCollectionChanged;
		}

		public IndicatorStyleEnum IndicatorStyle { get; set; }

		public IList<View> Children
		{
			get
			{
				return _stack.Children;
			}
		}

		private bool _layingOutChildren;
		protected override void LayoutChildren(double x, double y, double width, double height)
		{
			base.LayoutChildren(x, y, width, height);
			if (_layingOutChildren) return;

			_layingOutChildren = true;
			foreach (var child in Children) child.WidthRequest = width;
			_layingOutChildren = false;
		}

		public INotifyCollectionChanged ItemChangesSource
		{
			get
			{
				return (INotifyCollectionChanged)this.GetValue(CarouselViewOld.ItemsSourceProperty);
			}
			set
			{
				this.SetValue(CarouselViewOld.ItemsSourceProperty, (object)value);
			}
		}

		public static readonly BindableProperty SelectedIndexProperty =
			BindableProperty.Create(
				nameof(SelectedIndex),
				typeof(int),
				typeof(CarouselViewOld),
				0,
				BindingMode.TwoWay,
				propertyChanged: async (bindable, oldValue, newValue) =>
				{
					await ((CarouselViewOld)bindable).UpdateSelectedItem();
				}
			);

		public int SelectedIndex
		{
			get
			{
				return (int)GetValue(SelectedIndexProperty);
			}
			set
			{
				SetValue(SelectedIndexProperty, value);
			}
		}

		async Task UpdateSelectedItem()
		{
			await Task.Delay(300);
			SelectedItem = SelectedIndex > -1 ? Children[SelectedIndex].BindingContext : null;
		}

		public static readonly BindableProperty ItemsSourceProperty =
			BindableProperty.Create(
				nameof(ItemsSource),
				typeof(IList),
				typeof(CarouselViewOld),
				null,
				propertyChanging: (bindableObject, oldValue, newValue) =>
				{
					((CarouselViewOld)bindableObject).ItemsSourceChanging();
				},
				propertyChanged: (bindableObject, oldValue, newValue) =>
				{
					// everytime the itemssour
					((CarouselViewOld)bindableObject).ItemChangesSource.CollectionChanged -= ((CarouselViewOld)bindableObject).HandleCollectionChanged;
					((CarouselViewOld)bindableObject).ItemChangesSource.CollectionChanged += ((CarouselViewOld)bindableObject).HandleCollectionChanged;

					((CarouselViewOld)bindableObject).ItemsSourceChanged();
				}
			);

		public IList ItemsSource
		{
			get
			{
				return (IList)GetValue(ItemsSourceProperty);
			}
			set
			{
				SetValue(ItemsSourceProperty, value);
			}
		}

		void ItemsSourceChanging()
		{
			if (ItemsSource == null) return;

			_selectedIndex = ItemsSource.IndexOf(SelectedItem);
		}

		protected void HandleCollectionChanged(object sender, EventArgs e)
		{
			ItemsSourceChanged();
		}

		void ItemsSourceChanged()
		{
			_stack.Children.Clear();

			foreach (var item in ItemsSource)
			{
				var view = (View)ItemTemplate.CreateContent();
				var bindableObject = view as BindableObject;
				if (bindableObject != null)
					bindableObject.BindingContext = item;
				_stack.Children.Add(view);
			}

			if (_selectedIndex >= 0) SelectedIndex = _selectedIndex;
		}

		public DataTemplate ItemTemplate
		{
			get;
			set;
		}

		public static readonly BindableProperty SelectedItemProperty =
			BindableProperty.Create(
				nameof(SelectedItem),
				typeof(object),
				typeof(CarouselViewOld),
				null,
				BindingMode.TwoWay,
				propertyChanged: (bindable, oldValue, newValue) =>
				{
					((CarouselViewOld)bindable).UpdateSelectedIndex();
				}
			);

		public object SelectedItem
		{
			get
			{
				return GetValue(SelectedItemProperty);
			}
			set
			{
				SetValue(SelectedItemProperty, value);
			}
		}

		void UpdateSelectedIndex()
		{
			if (SelectedItem == BindingContext) return;

			SelectedIndex = Children
				.Select(c => c.BindingContext)
				.ToList()
				.IndexOf(SelectedItem);
		}
	}
}