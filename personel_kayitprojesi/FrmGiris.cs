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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
            SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-5MSOFLT1\\SQLEXPRESS03;Initial Catalog=PersonelVeritabani;Integrated Security=True");
        }
    }
}
