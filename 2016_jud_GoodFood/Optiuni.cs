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
using System.Threading;

namespace _2016_jud_GoodFood
{
    public partial class optiuniForm : Form
    {
        public optiuniForm()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;

        DataTable clientiDT = new DataTable();
        DataTable comandaDT;

        vizualizareForm vf = new vizualizareForm();

        string client;

        int pret_total = 0;
        int kcal_total = 0;

        public void GetClient(string client)
        {
            this.client = client;
        }

        private void GetClientData()
        {
            try
            {
                using (con = new SqlConnection(Services.connectionString))
                {
                    con.Open();

                    string sqlSelect = "SELECT * FROM Clienti WHERE email = @email";

                    cmd = new SqlCommand(sqlSelect, con);
                    cmd.Parameters.AddWithValue("@email", client);

                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(clientiDT);

                    adapter.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Eroare");
            }
        }

        private void CreateComandaDT()
        {
            comandaDT = new DataTable();

            comandaDT.Columns.Add("Nume Produs");
            comandaDT.Columns.Add("Kcal");
            comandaDT.Columns.Add("Pret");
            comandaDT.Columns.Add("Cantitate");

            chart1.DataSource = comandaDT;
            chart1.Series[0].XValueMember = comandaDT.Columns[0].ToString();
            chart1.Series[0].YValueMembers = comandaDT.Columns[1].ToString();
            chart1.Series[0].LegendText = "Kcal";
        }

        private void optiuniForm_Load(object sender, EventArgs e)
        {
            
            comandaDT = new DataTable();

            meniuTableAdapter.Connection = new SqlConnection(Services.connectionString);
            tableAdapterManager.Connection = new SqlConnection(Services.connectionString);
            meniu_optimTableAdapter.Connection = new SqlConnection(Services.connectionString);

            // TODO: This line of code loads data into the 'gOOD_FOODDataSet.Meniu' table. You can move, or remove it, as needed.
            this.meniuTableAdapter.Fill(this.gOOD_FOODDataSet.Meniu);
            

            GetClientData();

            int rowcount = dataGridView1.Rows.Count;
        
            try
            {
                textBox4.Text = clientiDT.Rows[0][6].ToString();
                necesarzTextBox.Text = clientiDT.Rows[0][6].ToString();
                necesarzTextBox2.Text = clientiDT.Rows[0][6].ToString();
            }
            catch
            {

            }            

            CreateComandaDT();
            chart1.Text = "Grafic Kcal";
        }

        private void inregistrareButton_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Completati toate campurile");
            }
            else
            {
                try
                {
                    int v = Convert.ToInt32(textBox1.Text);
                    int i = Convert.ToInt32(textBox2.Text);
                    int g = Convert.ToInt32(textBox3.Text);

                    int s = v + i + g;

                    int kcal = 0;

                    if (s < 250)
                    {
                        kcal = 1800; 
                            
                    }
                    else if (s > 249 && s < 276)
                    {
                        kcal = 2200;
                    }
                    else
                    {
                        kcal = 2500;
                    }

                    try
                    {
                        using (con = new SqlConnection(Services.connectionString))
                        {
                            con.Open();

                            string sqlInsert = "UPDATE Clienti SET kcal_zilnice = @kcal WHERE email = @email";

                            cmd = new SqlCommand(sqlInsert, con);
                            cmd.Parameters.AddWithValue("@email", client);
                            cmd.Parameters.AddWithValue("@kcal", kcal);

                            if(cmd.ExecuteNonQuery() == 1)
                            {
                                GetClientData();
                                textBox4.Text = kcal.ToString();
                                necesarzTextBox.Text = kcal.ToString();
                                necesarzTextBox2.Text = kcal.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Eroare");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Eroare");
                    }
                }
                catch
                {
                    MessageBox.Show("Date invalide");

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();                  
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView d = (DataGridView)sender;

            if (d.CurrentCell.ColumnIndex == d.Columns[7].Index)
            {
                try
                {
                    int cantitate = 0;
                    cantitate = Convert.ToInt32(d.CurrentRow.Cells[6].Value.ToString());                  
                    
                    if (cantitate < 0)
                    {
                        MessageBox.Show("Cantitate negativa");
                    }
                    else if (cantitate > 0)
                    {
                        pret_total += cantitate * Convert.ToInt32(d.CurrentRow.Cells[3].Value.ToString());
                        kcal_total += cantitate * Convert.ToInt32(d.CurrentRow.Cells[4].Value.ToString());

                        pretTextBox.Text = pret_total.ToString();
                        totalKcalTextBox.Text = kcal_total.ToString();

                        DataRow datar = comandaDT.NewRow();
                        datar[0] = d.CurrentRow.Cells[1].Value.ToString();
                        datar[1] = d.CurrentRow.Cells[4].Value.ToString();
                        datar[2] = d.CurrentRow.Cells[3].Value.ToString();
                        datar[3] = d.CurrentRow.Cells[6].Value.ToString();

                        comandaDT.Rows.Add(datar);

                        chart1.DataSource = comandaDT;
                        chart1.Series[0].XValueMember = comandaDT.Columns[0].ToString();
                        chart1.Series[0].YValueMembers = comandaDT.Columns[1].ToString();
                        chart1.Series[0].LegendText = "Kcal";                      
                    }                           
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Introduceti un numar natural");
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void comandaButton_Click(object sender, EventArgs e)
        {
            if (vf.IsDisposed) vf = new vizualizareForm();
            vf.GetDT(comandaDT);
            vf.GetPret(pret_total);
            vf.GetKcal(kcal_total);
            vf.GetNecesarZilnic(textBox4.Text);
            vf.GetClient(client);
            CreateComandaDT();
            pretTextBox.Clear();
            totalKcalTextBox.Clear();
            pret_total = 0;
            kcal_total = 0;
            timer1.Start();
            vf.Show();
            this.Hide();
        }

        private void genereazaButton_Click(object sender, EventArgs e)
        {
            try
            {
                int buget = Convert.ToInt32(bugetTextBox.Text);
                int kcal = 0;
                try
                {
                    kcal = Convert.ToInt32(necesarzTextBox2.Text);
                }
                catch
                {
                    kcal = 0;
                }

                meniu_optimTableAdapter.Fill(gOOD_FOODDataSet.Meniu_optim, kcal, buget);

                MessageBox.Show(gOOD_FOODDataSet.Meniu_optim.Rows[0][0].ToString());
            }
            catch
            {
                MessageBox.Show("Introduceti un numar natural in campul 'Buget'");
            }         
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView d = (DataGridView)sender;

            if(d.CurrentCell.ColumnIndex == d.Columns[5].Index)
            {
                try
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

                    for (int i = 0; i < 3; i++)
                    {
                        using (con = new SqlConnection(Services.connectionString))
                        {
                            con.Open();

                            cmd = new SqlCommand(sqlInsert2, con);
                            cmd.Parameters.AddWithValue("@idc", idcomanda);
                            cmd.Parameters.AddWithValue("@denumire", d.CurrentRow.Cells[i].Value.ToString());
                            cmd.Parameters.AddWithValue("@cantitate", 1);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Comanda Trimisa");
                }
                catch
                {
                    MessageBox.Show("Eroare");
                }
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            TabControl t = (TabControl)sender;

            if(t.SelectedTab == t.TabPages["tabPage2"])
            {
                timer1.Start();               
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[6].Value = "1";               
            }
            timer1.Stop();
        }
    }
}
