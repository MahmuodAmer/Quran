using Quran.Core;
using Quran.Core.Model;
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

namespace Quran.UI.Views
{
    /// <summary>
    /// Interaction logic for SearchInVerseView.xaml
    /// </summary>
    public partial class SearchInVerseView : UserControl
    {
        private readonly QuranLoader loader;
        public SearchInVerseView()
        {
            InitializeComponent();
            loader= new QuranLoader();
        }
        public SearchInVerseView(QuranLoader loader)
        {
            InitializeComponent();
            this.loader = loader;
        }

        private void ComboBox_Suras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(ComboBox_Suras.SelectedItem == null)
            //{
            //    return;
            //}

            //ComboBox_verses.Items.Clear();

            //var suraId = (ComboBox_Suras.SelectedItem as LightItem).Id;


            //ComboBox_verses.ItemsSource =  loader.Suras[suraId].verses;
        }
    }
}
