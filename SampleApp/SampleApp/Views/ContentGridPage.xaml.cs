﻿using System.Windows.Controls;
using SampleApp.Core.Models;
using SampleApp.ViewModels;

namespace SampleApp.Views
{
    public partial class ContentGridPage : Page
    {
        private readonly ContentGridViewModel _viewModel;

        public ContentGridPage(ContentGridViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void OnListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListView listView && listView.SelectedIndex != -1)
            {
                if (e.AddedItems[0] is SampleOrder order)
                {
                    _viewModel.OnSelectionChanged(order.OrderID);
                    listView.SelectedIndex = -1;
                }
            }
        }
    }
}
