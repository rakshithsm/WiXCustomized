using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceNameCustomAction
{
    public partial class FormServiceName : Form
    {

        public string ServiceName { get; set; }
        public FormServiceName()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            this.TopMost = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bool valid = !string.IsNullOrEmpty(textBox1.Text);

            if (!valid)
            {
                MessageBox.Show("Please enter a Service Name. It cannot be left blank", "Invalid Name!");
            }
            else
            {
                ServiceName = textBox1.Text;
                this.DialogResult = DialogResult.Yes;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
