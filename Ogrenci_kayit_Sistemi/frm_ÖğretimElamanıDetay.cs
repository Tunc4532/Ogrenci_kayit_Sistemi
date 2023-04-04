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
    public partial class frm_ÖğretimElamanıDetay : Form
    {
        public frm_ÖğretimElamanıDetay()
        {
            InitializeComponent();
        }

        private void frm_ÖğretimElamanıDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_25ilkprojemDataSet.tbl_ders1' table. You can move, or remove it, as needed.
            this.tbl_ders1TableAdapter.Fill(this._25ilkprojemDataSet.tbl_ders1);
            

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=25ilkprojem;Integrated Security=True");
        
        private void btnkaydet_Click(object sender, EventArgs e)
        {
          baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into tbl_ders1 (OGRNUMARA,OGRAD,OGRSOYAD) values (@t1,@t2,@t3)", baglanti);
            komut2.Parameters.AddWithValue("@t1", mskno.Text);
            komut2.Parameters.AddWithValue("@t2", txtad.Text);
            komut2.Parameters.AddWithValue("@t3", txtsoyad.Text);
            
            MessageBox.Show("Öğrenci kayıdı oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            komut2.ExecuteNonQuery();
        }





        string durum, geçen, kalan;
        private void btngüncelle_Click_1(object sender, EventArgs e)
        {
            double ort, vize, final;
            //string durum,geçen,kalan;
            vize = Convert.ToDouble(txtvize.Text);
            final =Convert.ToDouble(txtfinal.Text);
           
            ort = (vize * 0.4) + (final * 0.6);
            lblort.Text = ort.ToString();
            if (ort >= 50)
            {
                durum = "True";
            }
            else
            {
                durum= "False";

            }
            if (final < 50)
            {
                durum = "False";
                
            }
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("update tbl_ders1 set VİZE=@R1,FİNAL=@R2,ORTALAMA=@R5,DURUM=@R6 where OGRID=@R3", baglanti);
            komut3.Parameters.AddWithValue("@R1", txtvize.Text);
            komut3.Parameters.AddWithValue("@R2", txtfinal.Text);
            komut3.Parameters.AddWithValue("@R3", textBox1.Text);
            komut3.Parameters.AddWithValue("@R5",Decimal.Parse( lblort.Text));
            komut3.Parameters.AddWithValue("@R6",durum);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.tbl_ders1TableAdapter.Fill(this._25ilkprojemDataSet.tbl_ders1);
            if (durum == "False")
            {
                lblkalan.Text = "Kaldınız";
            }
            else
            {
                lblkalan.Text= "Geçtiniz";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[seçilen].Cells[0].Value.ToString();
            txtvize.Text = dataGridView1.Rows[seçilen].Cells[4].Value.ToString();
            txtfinal.Text = dataGridView1.Rows[seçilen].Cells[5].Value.ToString();
            txtad.Text = dataGridView1.Rows[seçilen].Cells[2].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[seçilen].Cells[3].Value.ToString();
            mskno.Text = dataGridView1.Rows[seçilen].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(durum == "False")
            {
                lblkalan.Text = "Kaldınız";
                MessageBox.Show("Bütünleme tarihleri sınavdan 28 gün sonradır");
            }
            else
            {
                lblkalan.Text = "Geçtiniz";
                MessageBox.Show("Bütünlemeye Kalmadınız Tebrikler");
            }
        }
    }
}
