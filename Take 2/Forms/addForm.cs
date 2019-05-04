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
    public partial class addForm : Form
    {
        Form1 baseForm;
        public addForm(Form form)
        {
            baseForm = (Form1)form;
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            baseForm.addToModel(textBox1.Text);
            this.Close();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
