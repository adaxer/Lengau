using SmartLibrary.Common.Models;
using SmartLibrary.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartLibrary.Wpf.Views;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class ShellWindow : Window
{
    public ShellWindow(ShellViewModel shell)
    {
        InitializeComponent();
        DataContext = shell;
    }

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        (DataContext as ShellViewModel).CurrentViewModel = ((sender as ListView)?.SelectedItem as BaseViewModel);
    }
}
