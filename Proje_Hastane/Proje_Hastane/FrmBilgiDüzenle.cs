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

namespace Proje_Hastane
{
    public partial class FrmBilgiDüzenle : Form
    {
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }

        public string TCno;
        DatabaseConnection bgl=new DatabaseConnection();
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = TCno;

            SqlCommand inst = new SqlCommand("Select * From Tbl_Hastalar where HastaTC=@p1", bgl.Connnection());
            inst.Parameters.AddWithValue("@p1",MskTC.Text);
            SqlDataReader dr = inst.ExecuteReader();

            while(dr.Read())
            
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                MskTC.Text = dr[3].ToString(); 
                MskTelefon.Text = dr[4].ToString();
                TxtSifre.Text = dr[5].ToString();   
                CmbCinsiyet.Text = dr[6].ToString();
            }
            bgl.Connnection().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand inst2 = new SqlCommand("update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTc=@p6",bgl.Connnection());   
           
            inst2.Parameters.AddWithValue("@p1",TxtAd.Text);
            inst2.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            inst2.Parameters.AddWithValue("@p3",MskTelefon.Text);
            inst2.Parameters.AddWithValue("@p4",TxtSifre.Text);
            inst2.Parameters.AddWithValue("@p5",CmbCinsiyet.Text);
            inst2.Parameters.AddWithValue("@p6", MskTC.Text);
            inst2.ExecuteNonQuery();
            bgl.Connnection().Close();
            MessageBox.Show("Bilgiler Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
