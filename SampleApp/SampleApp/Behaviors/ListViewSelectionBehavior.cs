using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace SampleApp.Behaviors
{
    public class ListViewSelectionBehavior : Behavior<ListView>
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ListViewSelectionBehavior), new PropertyMetadata(null));


        protected override void OnAttached()
        {
            base.OnAttached();
            var listView = base.AssociatedObject as ListView;
            listView.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
            listView.PreviewKeyDown += OnPreviewKeyDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            var listView = base.AssociatedObject as ListView;
            listView.PreviewMouseLeftButtonDown -= OnPreviewMouseLeftButtonDown;
            listView.PreviewKeyDown -= OnPreviewKeyDown;
        }

        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            => SelectItem(e);

        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SelectItem(e);
                e.Handled = true;
            }
        }

        private void SelectItem(RoutedEventArgs args)
        {
            if (Command != null
                && args.OriginalSource is FrameworkElement selectedItem
                && Command.CanExecute(selectedItem.DataContext))
            {
                Command.Execute(selectedItem.DataContext);
            }
        }
    }
}
