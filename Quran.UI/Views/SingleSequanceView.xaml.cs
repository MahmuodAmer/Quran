using Quran.UI.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Quran.UI.Views
{
    /// <summary>
    /// Interaction logic for SingleSequanceView.xaml
    /// </summary>
    public partial class SingleSequanceView : UserControl
    {
        public SingleSequanceView()
        {
            InitializeComponent();
        }
        public SingleSequanceViewModel viewModel
        {
            get
            {
                return (SingleSequanceViewModel)DataContext;
            }
        }

        private void ListBox_ResultIndexs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox_ResultIndexs.SelectedItem == null)
                return;

            var selectedItem = ((ListBox)sender).SelectedItem;
            //////
            ListBoxVersesText.SelectedItem = selectedItem;
            ListBoxVersesText.ScrollIntoView(selectedItem);
            ////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
            ListBox_ResultIndexs.SelectedItem = selectedItem;
            ListBox_ResultIndexs.ScrollIntoView(selectedItem);
            ////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\


        }

        private void ListBoxVersesText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox_ResultIndexs.SelectedItem = ListBoxVersesText.SelectedItem;
            ListBox_ResultIndexs.ScrollIntoView(ListBoxVersesText.SelectedItem);
        }

        private void ListBoxDiffrences_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = ListBoxDiffrences.SelectedIndex;

            if (selectedIndex == -1) return;

            //Clear the selected elements 
            ListBoxVersesText.SelectedItems.Clear();

            //Get the items to select 

            var firstItem = viewModel.Results.SearchResults[selectedIndex];
            var secondItem = viewModel.Results.SearchResults[selectedIndex + 1];
            ListBoxVersesText.SelectedItems.Add(firstItem);
            ListBoxVersesText.SelectedItems.Add(secondItem);
        }

        private void ButtonSearchForSimilar_Click(object sender, RoutedEventArgs e)
        {
            //var results = viewModel.SearchForSimilar();
            //var stringRepresentation = JsonConvert.SerializeObject(results);
            //File.WriteAllText("SerializedFile.txt", stringRepresentation);
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var richTextBox = (RichTextBox)sender;
            var text = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
            var index = text.IndexOf(viewModel.SearchText, StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                var start = richTextBox.Document.ContentStart.GetPositionAtOffset(index);
                var end = richTextBox.Document.ContentStart.GetPositionAtOffset(index + viewModel.SearchText.Length);
                var textRange = new TextRange(start, end);
                textRange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
            }
        }



        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    viewModel.Load();

        //    //Save the search value in the HighlightConverter converter
        //    HighlightConverter.SearchText = viewModel.SearchText;
        //}
    }
}
