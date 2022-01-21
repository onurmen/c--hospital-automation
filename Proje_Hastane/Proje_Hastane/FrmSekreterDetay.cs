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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string TCnumara;
        DatabaseConnection cmd = new DatabaseConnection();
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = TCnumara;

            // AD SOYAD
            SqlCommand inst1 = new SqlCommand("Select SekreterAdSoyad From Tbl_Sekreter where SekreterTC=@p1", cmd.Connnection());
            inst1.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr1 = inst1.ExecuteReader();
            while (dr1.Read())
            {
                LblAdSoyad.Text= dr1[0].ToString();
            }
            cmd.Connnection().Close();

            //Branş listesi aktarma
           DataTable dt1 = new DataTable();
           SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar ", cmd.Connnection());
            da.Fill(dt1);
            dataGridView2.DataSource = dt1;

            //Doktorların liste aktarımı
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select DoktorAd + ' '+DoktorSoyad as ' Doktorlar', DoktorBrans From Tbl_Doktorlar", cmd.Connnection());
            da2.Fill(dt2);
            dataGridView3.DataSource = dt2;

            //Branş aktarımı
            SqlCommand inst3 = new SqlCommand("Select BransAd From Tbl_Branslar",cmd.Connnection());
            SqlDataReader dr2 = inst3.ExecuteReader();
            while (dr2.Read())
                {
                CmbBrans.Items.Add(dr2[0]);
                cmd.Connnection().Close();
            }

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand instkyd = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor)values (@a1,@a2,@a3,@a4)", cmd.Connnection());

            instkyd.Parameters.AddWithValue("@a1", MskTarih.Text);
            instkyd.Parameters.AddWithValue("@a2",MskSaat.Text);
            instkyd.Parameters.AddWithValue("@a3",CmbBrans.Text);
            instkyd.Parameters.AddWithValue("@a4",CmbDoktor.Text);
            instkyd.ExecuteNonQuery();
            cmd.Connnection().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();

            SqlCommand inst = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar Where DoktorBrans=@s1", cmd.Connnection());
            inst.Parameters.AddWithValue("@s1", CmbBrans.Text);
            SqlDataReader dr = inst.ExecuteReader();
            while (dr.Read()) 
            
            {
                CmbDoktor.Items.Add(dr[0] + " " + dr[1]);
                cmd.Connnection().Close();
            }
        }

        private void BtnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand inst = new SqlCommand("insert into Tbl_Duyurular(duyuru) values (@d1)", cmd.Connnection());
            inst.Parameters.AddWithValue("@d1", RchDuyuru.Text);
            inst.ExecuteNonQuery();
            cmd.Connnection().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void BtnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli dr = new FrmDoktorPaneli();
            dr.Show();
        }

        private void BtnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBrans frb = new FrmBrans();
            frb.Show();
        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi fr = new FrmRandevuListesi();
            fr.Show(); 
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }
    }
}
