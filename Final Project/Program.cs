using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Final_Project
{
    static class Program
    {
        public static OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.15.0;data source=mydata.accdb");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        public static OleDbDataReader readData(string sqlCode)
        {
            OleDbDataReader reader;
            Program.con.Open();
            OleDbCommand cmd = new OleDbCommand("", Program.con);
            cmd.CommandText = sqlCode;
            reader = cmd.ExecuteReader();
            return reader;
        }

        public static void readToDGV(string sql, DataGridView dgv)
        {
            OleDbCommand cmd = new OleDbCommand("", Program.con);
            cmd.CommandText = sql;
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int i = dgv.Rows.Add(reader[0]);
                for(int n = 1; n < -dgv.Columns.Count - 1; n++)
                {
                    dgv.Rows[i].Cells[n].Value = reader[n];
                }
            }

            reader.Close();
            Program.con.Close();
        }
    }
}
