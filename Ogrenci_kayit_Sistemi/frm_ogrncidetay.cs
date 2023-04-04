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

namespace Ogrenci_kayit_Sistemi
{
    public partial class frm_ogrncidetay : Form
    {
        public frm_ogrncidetay()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=25ilkprojem;Integrated Security=True");
        public string numara;
        private void frm_ogrncidetay_Load(object sender, EventArgs e)
        {
            lblno.Text = numara;
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from tbl_ders1 where OGRNUMARA=@t1", baglanti);
            komut1.Parameters.AddWithValue("@t1", numara);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[2].ToString() + " "+ dr[3].ToString();
                lblvize.Text = dr[4].ToString();
                lblfinal.Text = dr[5].ToString();
                lblortalama.Text = dr[6].ToString();
                lbldurum.Text = dr[7].ToString();
            }
        }
    }
}
