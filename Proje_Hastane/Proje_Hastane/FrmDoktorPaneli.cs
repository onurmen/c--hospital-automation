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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        DatabaseConnection cmd= new DatabaseConnection();
        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tbl_Doktorlar", cmd.Connnection());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            //bRANŞ ÇEKME(COMBOBOX)
            SqlCommand instm = new SqlCommand("Select BransAd From Tbl_Branslar", cmd.Connnection());
            SqlDataReader dr2 = instm.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
                cmd.Connnection().Close();
            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand inst = new SqlCommand(" insert into Tbl_Doktorlar( DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values(@d1,@d2,@d3,@d4,@d5)", cmd.Connnection());
            inst.Parameters.AddWithValue("@d1", TxtAd.Text);
            inst.Parameters.AddWithValue("@d2", TxtSOyad.Text);
            inst.Parameters.AddWithValue("@d3", CmbBrans.Text);
            inst.Parameters.AddWithValue("@d4", MskTC.Text);
            inst.Parameters.AddWithValue("@d5" ,TxtSifre.Text);
            inst.ExecuteNonQuery();
            cmd.Connnection().Close();
            MessageBox.Show("Doktor Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
        }

        private void TxtSifre_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected= dataGridView1.SelectedCells[0].RowIndex;
          
             TxtAd.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
             TxtSOyad.Text = dataGridView1.Rows[selected].Cells[2].Value.ToString();
             CmbBrans.Text = dataGridView1.Rows[selected].Cells[3].Value.ToString();
             MskTC.Text = dataGridView1.Rows[selected].Cells[4].Value.ToString();
             TxtSifre.Text = dataGridView1.Rows[selected].Cells[5].Value.ToString();




        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand inst = new SqlCommand("Delete from Tbl_Doktorlar where DoktorTC=@p1", cmd.Connnection());
            inst.Parameters.AddWithValue("@p1", MskTC.Text);
            inst.ExecuteNonQuery();
            cmd.Connnection().Close();
            MessageBox.Show("Kayıt silindi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand inst = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1,DoktorSoyad=@d2,DoktorBrans=@d3,DoktorSifre=@d5 where DoktorTC=@d4",cmd.Connnection());

            inst.Parameters.AddWithValue("@d1", TxtAd.Text);
            inst.Parameters.AddWithValue("@d2", TxtSOyad.Text);
            inst.Parameters.AddWithValue("@d3", CmbBrans.Text);
            inst.Parameters.AddWithValue("@d4", MskTC.Text);
            inst.Parameters.AddWithValue("@d5", TxtSifre.Text);
            inst.ExecuteNonQuery();
            cmd.Connnection().Close();
            MessageBox.Show("Doktor Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
