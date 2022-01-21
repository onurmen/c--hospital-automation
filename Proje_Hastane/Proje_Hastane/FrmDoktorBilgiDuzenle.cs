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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        DatabaseConnection bgl= new DatabaseConnection();
        public string TCNO;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
           MskTC.Text = TCNO;
            SqlCommand inst = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTC=@p1", bgl.Connnection());
            inst.Parameters.AddWithValue("@p1", MskTC.Text);
            SqlDataReader dr = inst.ExecuteReader();
            while (dr.Read())
            {
                Txtad.Text=dr[1].ToString();
                Txtsoyad.Text=dr[2].ToString();
                CmbBrans.Text=dr[3].ToString();
                TxtSifre.Text=dr[5].ToString();
            }
              bgl.Connnection().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand inst = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4,DoktorTC=@p5",bgl.Connnection());
            inst.Parameters.AddWithValue("@p1", Txtad.Text);
            inst.Parameters.AddWithValue("@p2",Txtsoyad.Text);
            inst.Parameters.AddWithValue("@p3",CmbBrans.Text);
            inst.Parameters.AddWithValue("@p4",TxtSifre.Text);
            inst.Parameters.AddWithValue("@p5",MskTC.Text);
            inst.ExecuteNonQuery();
            bgl.Connnection().Close();
            MessageBox.Show("Kayıt Güncellendi");
        }
    }
}
