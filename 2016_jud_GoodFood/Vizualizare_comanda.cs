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
    public partial class vizualizareForm : Form
    {
        public vizualizareForm()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;

        DataTable comandaDT = new DataTable();

        int pret_total = 0;
        int kcal_total = 0;

        string necesar_zilnic;
        string client;

        public void GetDT(DataTable dt)
        {
            comandaDT = dt;
        }

        public void GetPret(int pret)
        {
            pret_total = pret;
        }

        public void GetKcal(int kcal)
        {
            kcal_total = kcal;
        }

        public void GetNecesarZilnic(string necesar)
        {
            necesar_zilnic = necesar;
        }

        public void GetClient(string email)
        {
            client = email;
        }

        private void vizualizareForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = comandaDT;
            dataGridView1.Refresh();
            dataGridView1.Update();

            dataGridView1.Columns[0].DisplayIndex = 4;

            necesarzTextBox.Text = necesar_zilnic;
            pretTextBox.Text = pret_total.ToString();
            totalKcalTextBox.Text = kcal_total.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView d = (DataGridView)sender;

            if (d.CurrentCell.ColumnIndex == d.Columns[0].Index)
            {
                comandaDT.Rows[d.CurrentRow.Index].Delete();
            }
        }

        private void finalizareButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                string sqlInsert1 = "INSERT INTO Comenzi VALUES (@id, (SELECT id_client FROM Clienti WHERE email = @email), @data)";
                string sqlInsert2 = "INSERT INTO SubComenzi VALUES (@idc, (SELECT id_produs FROM Meniu WHERE denumire_produs = @denumire), @cantitate)";

                string idcomanda = "Comanda" + "   " + DateTime.Now.ToLongDateString() + "   " + DateTime.Now.ToLongTimeString();

                using (con = new SqlConnection(Services.connectionString))
                {
                    con.Open();
                  
                    cmd = new SqlCommand(sqlInsert1, con);
                    cmd.Parameters.AddWithValue("@id", idcomanda);
                    cmd.Parameters.AddWithValue("@email", client);
                    cmd.Parameters.AddWithValue("@data", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }

                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    using (con = new SqlConnection(Services.connectionString))
                    {
                        con.Open();

                        cmd = new SqlCommand(sqlInsert2, con);
                        cmd.Parameters.AddWithValue("@idc", idcomanda);
                        cmd.Parameters.AddWithValue("@denumire", dr.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@cantitate", dr.Cells[4].Value.ToString());

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Comanda trimisa!");
                            Application.OpenForms["optiuniForm"].Show();
                            this.Close();                           
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Alegeti produse");
                Application.OpenForms["optiuniForm"].Show();
                this.Close();
            }          
        }
    }
}
