using System;
using System.Windows.Forms;
using FileHandle;

namespace Demo
{
    public partial class InfoOutput : Form
    {
        public InfoOutput()
        {
            InitializeComponent();
            foreach (var info in File.FuncInfo)
            {
                InfoBox.Text += info + '\n';
            }
        }

        private void InfoOutput_Load(object sender, EventArgs e)
        {
        }
    }
}