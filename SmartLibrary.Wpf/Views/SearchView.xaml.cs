using SmartLibrary.Common.Models;
using SmartLibrary.Common.ViewModels;
using System.Windows.Controls;

namespace SmartLibrary.Wpf.Views;
/// <summary>
/// Interaction logic for SearchView.xaml
/// </summary>
public partial class SearchView : UserControl
{
    public SearchView()
    {
        InitializeComponent();
    }

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        (DataContext as SearchViewModel)?.ShowBookCommand?.Execute((sender as ListView)?.SelectedItem as Book);
    }
}
