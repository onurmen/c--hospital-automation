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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        public string tc;
        DatabaseConnection cmd= new DatabaseConnection();
        private void TxtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand inst = new SqlCommand("update Tbl_Randevular set RandevuDurum=1,HastaTC=@p1, HastaSikayet=@p2 where Randevuid=@p3", cmd.Connnection());
                
                inst.Parameters.AddWithValue("@p1", LblTC.Text);
                inst.Parameters.AddWithValue("@p2", RchSikayet.Text);
                inst.Parameters.AddWithValue("@p3", TxtID.Text);
            inst.ExecuteNonQuery();
            cmd.Connnection().Close();
            MessageBox.Show("BAŞARILI");
        }

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            LblTC.Text = tc;
            //AD SOYAD ÇEKME ALANI
            SqlCommand inst = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar where HastaTC=@p1", cmd.Connnection());
            inst.Parameters.AddWithValue("@p1",LblTC.Text);
            SqlDataReader dr = inst.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] + " " + dr[1];
            } cmd.Connnection().Close();

            //RANDEVULAR
            DataTable dt= new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where HastaTC=" + tc, cmd.Connnection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            //Branş alma
           
            SqlCommand inst2 = new SqlCommand("Select BransAd From Tbl_Branslar", cmd.Connnection());
            SqlDataReader dr2 = inst2.ExecuteReader(); 

            while ( dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            cmd.Connnection().Close();
                
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            SqlCommand inst3 = new SqlCommand("Select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1", cmd.Connnection());
            inst3.Parameters.AddWithValue("@p1", CmbBrans.Text);
            SqlDataReader dr3=inst3.ExecuteReader();
            while (dr3.Read())
            {
                CmbDoktor.Items.Add((string)dr3[0]+ " " + dr3[1]);
                cmd.Connnection().Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
           DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuBrans='" + CmbBrans.Text + "'", cmd.Connnection());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void LnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDüzenle fr = new FrmBilgiDüzenle();
            fr.TCno = LblTC.Text;
            fr.Show();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = dataGridView2.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView2.Rows[selected].Cells[0].Value.ToString();
        }
    }
}
 