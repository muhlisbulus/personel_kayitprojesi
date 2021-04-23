using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace personel_kayitprojesi
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-5MSOFLT1\\SQLEXPRESS03;Initial Catalog=PersonelVeritabani;Integrated Security=True");
        void temizle()
        {
            Txtad.Text = "";
            Txtid.Text = "";
            Txtmeslek.Text = "";
            Txtsoyad.Text = "";
            Mskmaas.Text = "";
            Cmbsehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            Txtad.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.tbl_personelTableAdapter.Fill(this.personelVeritabaniDataSet.Tbl_personel);
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personelVeritabaniDataSet.Tbl_personel);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_personel (PerAd,PerSoyad,Persehir,Permaas,PerdMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", Txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", Cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", Mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", Txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");

            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
                
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }

        }

        private void Btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            Txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            Txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
           Cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            Mskmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            Txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void Btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_personel Where Perid=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1", Txtid.Text);
            komutsil.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Silindi");
            baglanti.Close();
        }

        private void Btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_personel Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerdMeslek=@a6 where Perid=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", Txtad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", Txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", Cmbsehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4",Mskmaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", Txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", Txtid.Text);
            komutguncelle.ExecuteNonQuery();
           

            baglanti.Close();
            MessageBox.Show("Personel Bilgi Güncellendi");

        }

        private void Btnistatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr = new Frmistatistik();
            fr.Show();
                
        }

        private void Btngrafikler_Click(object sender, EventArgs e)
        {
            Frmgrafikler fr1 = new Frmgrafikler();
            fr1.Show();
        }
    }
}
