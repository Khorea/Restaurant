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

namespace _2016_jud_GoodFood
{
    public partial class autentificareForm : Form
    {
        public autentificareForm()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;

        optiuniForm of = new optiuniForm();

        private void inregistrareButton_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Completati toate campurile");
            }
            else
            {
                using (con = new SqlConnection(Services.connectionString))
                {
                    con.Open();

                    string sqlSelect = "SELECT count(*) FROM Clienti WHERE email = @email AND parola = @parola";

                    SqlCommand cmd = new SqlCommand(sqlSelect, con);
                    cmd.Parameters.AddWithValue("@email", textBox1.Text);
                    cmd.Parameters.AddWithValue("@parola", textBox2.Text);

                    int count = (int)cmd.ExecuteScalar();

                    if(count == 1)
                    {
                        of.GetClient(textBox1.Text);
                        of.Show();
                        
                        this.Close();                      
                    }
                    else
                    {
                        MessageBox.Show("Eroare autentificare!");
                        textBox1.Clear();
                        textBox2.Clear();                                                 
                    }
                }
            }
                    
        }
    }
}
