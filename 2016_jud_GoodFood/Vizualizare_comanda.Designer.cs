namespace _2016_jud_GoodFood
{
    partial class vizualizareForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.finalizareButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pretTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.totalKcalTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.necesarzTextBox = new System.Windows.Forms.TextBox();
            this.eliminaColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eliminaColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(810, 315);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // finalizareButton
            // 
            this.finalizareButton.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalizareButton.Location = new System.Drawing.Point(389, 350);
            this.finalizareButton.Name = "finalizareButton";
            this.finalizareButton.Size = new System.Drawing.Size(186, 38);
            this.finalizareButton.TabIndex = 23;
            this.finalizareButton.Text = "Finalizare Comanda";
            this.finalizareButton.UseVisualStyleBackColor = true;
            this.finalizareButton.Click += new System.EventHandler(this.finalizareButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "Pret Total";
            // 
            // pretTextBox
            // 
            this.pretTextBox.Location = new System.Drawing.Point(132, 401);
            this.pretTextBox.Name = "pretTextBox";
            this.pretTextBox.ReadOnly = true;
            this.pretTextBox.Size = new System.Drawing.Size(184, 20);
            this.pretTextBox.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 23);
            this.label6.TabIndex = 20;
            this.label6.Text = "Total Kcal";
            // 
            // totalKcalTextBox
            // 
            this.totalKcalTextBox.Location = new System.Drawing.Point(132, 361);
            this.totalKcalTextBox.Name = "totalKcalTextBox";
            this.totalKcalTextBox.ReadOnly = true;
            this.totalKcalTextBox.Size = new System.Drawing.Size(184, 20);
            this.totalKcalTextBox.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 23);
            this.label5.TabIndex = 18;
            this.label5.Text = "Necesar zilnic";
            // 
            // necesarzTextBox
            // 
            this.necesarzTextBox.Location = new System.Drawing.Point(132, 321);
            this.necesarzTextBox.Name = "necesarzTextBox";
            this.necesarzTextBox.ReadOnly = true;
            this.necesarzTextBox.Size = new System.Drawing.Size(184, 20);
            this.necesarzTextBox.TabIndex = 17;
            // 
            // eliminaColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "Elimina";
            this.eliminaColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.eliminaColumn.HeaderText = "Elimina";
            this.eliminaColumn.Name = "eliminaColumn";
            this.eliminaColumn.ReadOnly = true;
            this.eliminaColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.eliminaColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // vizualizareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 430);
            this.Controls.Add(this.finalizareButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pretTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.totalKcalTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.necesarzTextBox);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "vizualizareForm";
            this.Text = "Vizualizare comanda";
            this.Load += new System.EventHandler(this.vizualizareForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button finalizareButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox pretTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox totalKcalTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox necesarzTextBox;
        private System.Windows.Forms.DataGridViewButtonColumn eliminaColumn;
    }
}