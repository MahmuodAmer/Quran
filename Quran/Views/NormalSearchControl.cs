using Newtonsoft.Json;
using Quran.Core;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quran.Views
{
    public partial class NormalSearchControl : UserControl
    {

        public NormalSearchControl()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            //Change the Tab Name 
            ((TabPage)this.Parent).Text = comboBox_names.Text;



            //Clear the RichTextBox
            rtb_result.Text = string.Empty;



            int id = ((int)((LightItem)comboBox_names.SelectedItem).Id);
            var result = MainParser.Parse(id.SuraIdToString(), textBox_search.Text);

            var values_splited = result.OutputString.Split(textBox_search.Text);
            int length = values_splited.Length;
            int counter = 0;

            //Color the searched text
            foreach (var item in values_splited)
            {
                counter++;
                if (counter == length)
                {
                    rtb_result.AppendText(item);
                    break;
                }
                rtb_result.AppendText(item);

                rtb_result.AppendText(textBox_search.Text, Color.SkyBlue);

            }

            richTextBox_series.Text = JsonConvert.SerializeObject(result.Series);
            richTextBox_matches.Text = JsonConvert.SerializeObject(result.Matches);
        }

        private void NormalSearchControl_Load(object sender, EventArgs e)
        {
            comboBox_names.DataSource = ImportGeneralDataExtentions.GetNames();
            comboBox_names.DisplayMember = "Name";
            comboBox_names.ValueMember = "Id";
        }

        private void button_addTab_Click(object sender, EventArgs e)
        {
            AddTabToTheMainTabControl();
        }
        private void AddTabToTheMainTabControl()
        {
            TabPage page = new TabPage($"New Page {Form1.PageId}");
            page.Controls.Add(new NormalSearchControl());
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Add(page);
            Form1.PageId++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((TabControl)(((TabPage)this.Parent)).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int id = ((int)((LightItem)comboBox_names.SelectedItem).Id);
            //var start = int.Parse(textBox1.Text);
            //var length = int.Parse(textBox2.Text)- int.Parse(textBox1.Text) ;
            //var result = id.SuraIdToString().Substring(start, length);
            //richTextBox1.Text = result;
        }
    }
}
