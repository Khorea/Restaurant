using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.Sql;
using System.Data.SqlClient;

namespace _2016_jud_GoodFood
{
    public partial class creareForm : Form
    {
        public creareForm()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;

        private bool IsEmail(string email)
        {
            try
            {
                var ma = new MailAddress(email);

                bool punct = false;
                bool ok = false;

                if (ma.Address != email)                 
                {
                    return false;
                }
                else
                {
                    string[] text = email.Split('@');
                    char[] cArray = text[1].ToCharArray();

                    if (cArray[0] == '.') return false;

                    for (int i = 0; i < cArray.Length; i++)
                    {
                        if (cArray[i] == '.' && punct) return false;
                        if (punct) ok = true;
                        if (cArray[i] == '.' && !punct) punct = true;
                    }
                }

                return ok;
            }
            catch
            {
                return false;
            }
        }

        private void creareButton_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {

            }

            if(numeTextBox.Text == "" || parolaTextBox.Text == "" || adresaTextBox.Text == "" || rparolaTextBox.Text == "" || emailTextBox.Text == "")
            {
                MessageBox.Show("Completati toate campurile");
            }
            else
            {
                if(parolaTextBox.Text != rparolaTextBox.Text)
                {
                    MessageBox.Show("Parolele nu coincid");
                }
                else
                {
                    if (!IsEmail(emailTextBox.Text))
                    {
                        MessageBox.Show("Introduceti o adresa de email valida");
                    }
                    else
                    {
                        using (con = new SqlConnection(Services.connectionString))
                        {
                            con.Open();

                            string sqlSelect = "SELECT count(*) FROM Clienti WHERE email = @email";

                            cmd = new SqlCommand(sqlSelect, con);
                            cmd.Parameters.AddWithValue("@email", emailTextBox.Text);

                            int count = (int)cmd.ExecuteScalar();

                            if (count == 1)
                            {
                                MessageBox.Show("Adresa de email este luata");
                            }
                            else
                            {
                                string sqlInsert = "INSERT INTO Clienti VALUES (@parola, @nume, @prenume, @adresa, @email, NULL)";
                                
                                cmd = new SqlCommand(sqlInsert, con);
                                cmd.Parameters.AddWithValue("@parola", parolaTextBox.Text);
                                cmd.Parameters.AddWithValue("@nume", numeTextBox.Text);
                                cmd.Parameters.AddWithValue("@prenume", prenumeTextBox.Text);
                                cmd.Parameters.AddWithValue("@adresa", adresaTextBox.Text);
                                cmd.Parameters.AddWithValue("@email", emailTextBox.Text);

                                if(cmd.ExecuteNonQuery() == 1)
                                {
                                    MessageBox.Show("Succes");
                                    Application.OpenForms["startForm"].Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Eroare la introducerea contului in baza de date");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
