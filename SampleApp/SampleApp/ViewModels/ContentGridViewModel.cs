using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SampleApp.Contracts.Services;
using SampleApp.Contracts.ViewModels;
using SampleApp.Core.Contracts.Services;
using SampleApp.Core.Models;
using SampleApp.Helpers;

namespace SampleApp.ViewModels
{
    public class ContentGridViewModel : Observable, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly ISampleDataService _sampleDataService;
        private ICommand _selectItemCommand;

        public ICommand SelectItemCommand => _selectItemCommand ?? (_selectItemCommand = new RelayCommand<SampleOrder>(OnSelectItem));        

        public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

        public ContentGridViewModel(INavigationService navigationService, ISampleDataService sampleDataService)
        {
            _navigationService = navigationService;
            _sampleDataService = sampleDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            var data = await _sampleDataService.GetContentGridDataAsync();
            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        private void OnSelectItem(SampleOrder order)
        {
            _navigationService.NavigateTo(typeof(ContentGridDetailViewModel).FullName, order.OrderID);
        }
    }
}
