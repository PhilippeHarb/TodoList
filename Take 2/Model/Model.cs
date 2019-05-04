using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Take_2
{
    class Model
    {
        public List<String> elements;
        private static Model model = null;

        public static Model  getInstance()
        {
            if (model == null)
                model =new Model();
            return model;
            
             

        }
        private Model() { elements = new List<string>(); }
      
        public  void add(string s)
        {
            model.elements.Add(s);
            SQLiteConnection conn = openConnection();
            conn.Open();
          

            SQLiteCommand command = new SQLiteCommand("insert into todolist(id,task) values (@id,@tasktext)", conn);
            command.Parameters.AddWithValue("@tasktext", s);
            command.Parameters.AddWithValue("@id", model.elements.Count-1);

            command.ExecuteNonQuery();
        }
       
       
        public  SQLiteConnection openConnection()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=db.sql3;Version=3;");
            
            return conn;
        }
        public  void delete(int index)
        {
           model.elements.RemoveAt(index);
            SQLiteConnection conn = openConnection();
            conn.Open();

            SQLiteCommand command = new SQLiteCommand("delete from todolist", conn);
            command.ExecuteNonQuery();
            for (int i = 0; i <model.elements.Count; i++)
            {
                SQLiteParameter data = new SQLiteParameter();
               

                
                SQLiteCommand commandAdd = new SQLiteCommand("insert into todolist(id,task) values (@id,@tasktext)", conn);
                commandAdd.Parameters.AddWithValue("@tasktext", model.elements[i]);
                commandAdd.Parameters.AddWithValue("@id", i);
                commandAdd.ExecuteNonQuery();


            }
            


        }
        public  void update (string s, int index)
        {
            model.elements[index] = s;
            SQLiteConnection conn = openConnection();
           
            
            conn.Open();
            SQLiteCommand command = new SQLiteCommand("update todolist set task = @updatedText where id=@ID",conn);
            
          
            command.Parameters.AddWithValue("@updatedText", s);
            command.Parameters.AddWithValue("@ID",index);
            command.ExecuteNonQuery();
      


            
        }


    }
}
