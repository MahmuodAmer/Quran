using Quran.Core;
using Quran.Views;

namespace Quran
{
    public partial class Form1 : Form
    {
        public static int PageId { get; set; }
        public Form1()
        {
            InitializeComponent();
            AddTabToTheMainTabControl();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTabToTheMainTabControl();
        }

        private void AddTabToTheMainTabControl()
        {
            TabPage page = new TabPage($"New Page {PageId}");
            page.Controls.Add(new NormalSearchControl());
            tabControl_main.TabPages.Add(page);
            PageId++;
        }
    }
}