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
    /// Interaction logic for TwoVerseComparisonView.xaml
    /// </summary>
    public partial class TwoVerseComparisonView : UserControl
    {
        public TwoVerseComparisonView()
        {
            InitializeComponent();
        }

        private void ComboBox_Suras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxSender = (ComboBox)sender;

            if (comboBoxSender == null || comboBoxSender.SelectedItem == null)
            {
                return;
            }

            //ComboBox_verses1.Items.Clear();

        }
    }
}
