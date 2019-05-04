using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Take_2
{
    public partial class Form1 : Form
    {
        private Model model;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            model = Model.getInstance();
            TaskList.View = View.List;
          
            SQLiteConnection conn;
            if (!File.Exists("db.sql3"))
            {
                SQLiteConnection.CreateFile("db.sql3");
              


                conn = new SQLiteConnection("Data Source = db.sql3; Version = 3;");
                conn.Open();
                SQLiteCommand command = new SQLiteCommand("create table todolist (id integer primary key  ,task text)", conn);
                command.ExecuteNonQuery();
            }
            conn = new SQLiteConnection("Data Source = db.sql3; Version = 3;");
            conn.Open();

           
            SQLiteCommand read = new SQLiteCommand("select * from todolist", conn);

            SQLiteDataReader reader = read.ExecuteReader();
          
       
            while(reader.Read())
            {
                model.elements.Add((string)reader["task"]);
            }
            refreshTaskList();

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            addForm form = new addForm(this);
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;

            form.ShowDialog();
        }
        public void addToModel(string s)
        {
            model.add(s);
            refreshTaskList();

        }
        public void refreshTaskList()
        {
            TaskList.Items.Clear();
            for (int i = 0; i < model.elements.Count; i++)
            {
                TaskList.Items.Add(model.elements[i]);


            }
        }

        private void TaskList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (TaskList.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure ? ", "Removing Selected Item.", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int index = TaskList.FocusedItem.Index;
                    model.delete(index);
                    TaskList.Items.RemoveAt(index);

                }
            }
        }
        public void editModel(string s,int index)
        {
            model.update(s, index);
            refreshTaskList();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            int index = TaskList.FocusedItem.Index;
            string s = model.elements[index];
            editForm form = new editForm(this, s,index);
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowDialog();
        }
    }
}
