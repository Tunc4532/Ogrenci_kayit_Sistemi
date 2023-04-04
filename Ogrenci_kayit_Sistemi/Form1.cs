using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ogrenci_kayit_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_ogrncidetay fr = new frm_ogrncidetay();
            fr.numara = maskedTextBox1.Text;
            fr.Show();

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text=="1111")
            {
                frm_ÖğretimElamanıDetay fre = new frm_ÖğretimElamanıDetay();
                fre.Show();

            }
        }
    }
}
