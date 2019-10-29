using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;

namespace _2016_jud_GoodFood
{
    public partial class startForm : Form
    {
        public startForm()
        {
            InitializeComponent();
        }

        creareForm cf = new creareForm();
        autentificareForm af = new autentificareForm();

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;

        StreamReader sr;

        private void inregistrareButton_Click(object sender, EventArgs e)
        {
            if (cf.IsDisposed)
            {
                cf = new creareForm();
                cf.Show();
                this.Hide();
            }
            else if (cf.Visible == false)
            {
                cf.Show();
                this.Hide();
            }
        }

        private void autentificareButton_Click(object sender, EventArgs e)
        {
            if (af.IsDisposed)
            {
                af = new autentificareForm();
                af.Show();
                this.Hide();
            }
            else if (cf.Visible == false)
            {
                af.Show();
                this.Hide();
            }
        }

        private void GetData()
        {           
            char[] c = new char[1];
            c[0] = ';';

            try
            {
                using (sr = new StreamReader(Environment.CurrentDirectory.Replace(@"\bin\Debug", @"\Resurse_C#") + @"\meniu.txt"))
                {
                    sr.ReadLine();

                    while(!sr.EndOfStream)
                    {
                        string[] date = new string[15];

                        date = sr.ReadLine().Split(c, StringSplitOptions.RemoveEmptyEntries);

                        using (con = new SqlConnection(Services.connectionString))
                        {
                            con.Open();

                            string sqlInsert = "INSERT INTO Meniu VALUES (@id, @den, @des, @pret, @kcal, @fel)";

                            cmd = new SqlCommand(sqlInsert, con);
                            cmd.Parameters.AddWithValue("@id", date[0]);
                            cmd.Parameters.AddWithValue("@den", date[1]);
                            cmd.Parameters.AddWithValue("@des", date[2]);
                            cmd.Parameters.AddWithValue("@pret", date[3]);
                            cmd.Parameters.AddWithValue("@kcal", date[4]);
                            cmd.Parameters.AddWithValue("@fel", date[5]);

                            cmd.ExecuteNonQuery();
                        }                       
                    }
                }
            }
            catch
            {
                
            }                
        }
        

        private void startForm_Load(object sender, EventArgs e)
        {
            //GetData();     
        }
    }
}
