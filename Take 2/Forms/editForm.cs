using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Take_2
{
    public partial class editForm : Form
    {
        Form1 baseForm;
        string s;
        int index;
        public editForm(Form form,string s,int index)
        {
            this.s = s;
            this.index = index;
            baseForm = (Form1)form;
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = s;

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            baseForm.editModel(textBox1.Text, index);
            this.Close();
        }
    }
}
