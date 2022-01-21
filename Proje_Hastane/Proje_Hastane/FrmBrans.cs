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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }
        DatabaseConnection bgl=new DatabaseConnection();
        private void FrmBrans_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar",bgl.Connnection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand inst = new SqlCommand("insert into Tbl_Branslar(BransAd) values (@b1)", bgl.Connnection());
            inst.Parameters.AddWithValue("@b1",TxtBrans.Text);
            inst.ExecuteNonQuery();
            bgl.Connnection().Close();
            MessageBox.Show("Branş Eklenmiştir");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtId.Text=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtBrans.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand inst = new SqlCommand("delete From Tbl_branslar where Bransid=@b1", bgl.Connnection());
            
            inst.Parameters.AddWithValue("@b1", TxtId.Text);
            inst.ExecuteNonQuery();
            bgl.Connnection().Close();
            MessageBox.Show(" Silme Başarılı");
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand inst = new SqlCommand("update Tbl_Branslar set bransAd=@c1 where Bransid=@c2",bgl.Connnection());
            inst.Parameters.AddWithValue("@c1", TxtBrans.Text);
            inst.Parameters.AddWithValue("@c2", TxtId.Text);
            inst.ExecuteNonQuery();
            bgl.Connnection().Close();
            MessageBox.Show("Kayıt Yenilendi");
        }
       
    }
}
