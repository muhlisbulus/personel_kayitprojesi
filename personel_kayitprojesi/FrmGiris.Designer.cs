using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace personel_kayitprojesi
{
    partial class FrmGiris
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
            this.label1 = new System.Windows.Forms.Label();
            this.Txtkullaniciad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Txtsifre = new System.Windows.Forms.TextBox();
            this.Btngirisyap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı:";
            // 
            // Txtkullaniciad
            // 
            this.Txtkullaniciad.Location = new System.Drawing.Point(165, 84);
            this.Txtkullaniciad.Name = "Txtkullaniciad";
            this.Txtkullaniciad.Size = new System.Drawing.Size(178, 29);
            this.Txtkullaniciad.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ravie", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(519, 43);
            this.label3.TabIndex = 4;
            this.label3.Text = "Personel Takip Sistemi";
            // 
            // Txtsifre
            // 
            this.Txtsifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Txtsifre.Location = new System.Drawing.Point(165, 161);
            this.Txtsifre.Name = "Txtsifre";
            this.Txtsifre.PasswordChar = '*';
            this.Txtsifre.Size = new System.Drawing.Size(178, 40);
            this.Txtsifre.TabIndex = 5;
            // 
            // Btngirisyap
            // 
            this.Btngirisyap.Location = new System.Drawing.Point(165, 249);
            this.Btngirisyap.Name = "Btngirisyap";
            this.Btngirisyap.Size = new System.Drawing.Size(178, 56);
            this.Btngirisyap.TabIndex = 6;
            this.Btngirisyap.Text = "Giriş";
            this.Btngirisyap.UseVisualStyleBackColor = true;
            this.Btngirisyap.Click += new System.EventHandler(this.Btngirisyap_Click);
            // 
            // FrmGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(556, 373);
            this.Controls.Add(this.Btngirisyap);
            this.Controls.Add(this.Txtsifre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txtkullaniciad);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmGiris";
            this.Text = "FrmGiris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-5MSOFLT1\\SQLEXPRESS03;Initial Catalog=PersonelVeritabani;Integrated Security=True");
        private void Btngirisyap_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_yonetici where KullanıciAd=@p1 and Sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", Txtkullaniciad.Text);
            komut.Parameters.AddWithValue("@p2", Txtsifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı şifre veya Kullanıcı adı girildi....");
            }
            
            baglanti.Close();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txtkullaniciad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txtsifre;
        private System.Windows.Forms.Button Btngirisyap;
    }
}