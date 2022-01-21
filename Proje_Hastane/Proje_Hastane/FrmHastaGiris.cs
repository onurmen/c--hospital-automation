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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        DatabaseConnection cmd=new DatabaseConnection();
        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayıt fr = new FrmHastaKayıt();
            fr.Show();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand inst = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2", cmd.Connnection());

            inst.Parameters.AddWithValue("@p1", MskTC.Text);
            inst.Parameters.AddWithValue("p2", TxtSifre.Text);
            SqlDataReader dr = inst.ExecuteReader();
            if (dr.Read())
            {
                FrmHastaDetay fr =new FrmHastaDetay();
                fr.tc=MskTC.Text;
                fr.Show();
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre");

            }       cmd.Connnection().Close();
        }

        private void FrmHastaGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
