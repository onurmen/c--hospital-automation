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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        DatabaseConnection bgl = new DatabaseConnection();
        public string TC;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = TC;
            // doktor ad soyad çekme
            SqlCommand inst= new SqlCommand("Select DoktorAD,DoktorSoyad From Tbl_Doktorlar where DoktorTC=@p1",bgl.Connnection());
            inst.Parameters.AddWithValue("p1",LblTC.Text);
            SqlDataReader dr = inst.ExecuteReader();
            while(dr.Read())  
                {
                LblAdSoyad.Text= dr[0] + " " + dr[1];
            }
            bgl.Connnection().Close();

            // randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuDoktor='" + LblAdSoyad.Text + "'",bgl.Connnection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle fr = new FrmDoktorBilgiDuzenle();
            fr.TCNO=LblTC.Text;
            fr.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
