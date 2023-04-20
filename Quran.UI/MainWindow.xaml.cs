using Quran.Core.Model;
using Quran.UI.Data;
using Quran.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Quran.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel(new MainDataModel());
            this.DataContext = viewModel;
            viewModel.Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Load();
        }

        private void ListBox_ResultIndexs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox_ResultIndexs.SelectedItem == null)
                return;
            viewModel.SelectedResult = (Result)ListBox_ResultIndexs.SelectedItem;
            ListBoxVersesText.SelectedItem = ListBox_ResultIndexs.SelectedItem;
            ListBoxVersesText.ScrollIntoView(ListBox_ResultIndexs.SelectedItem);
        }

        private void ListBoxVersesText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox_ResultIndexs.SelectedItem = ListBoxVersesText.SelectedItem;
            ListBox_ResultIndexs.ScrollIntoView(ListBoxVersesText.SelectedItem);

        }
    }
}
