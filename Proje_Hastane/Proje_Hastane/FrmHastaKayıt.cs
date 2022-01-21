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
    public partial class FrmHastaKayıt : Form
    {
        public FrmHastaKayıt()
        {
            InitializeComponent();
        }

        DatabaseConnection cmd =new DatabaseConnection();

        private void BtnKayıtYap_Click(object sender, EventArgs e)
        {
            SqlCommand inst=new SqlCommand("insert into Tbl_Hastalar(HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet )values(@p1,@p2,@p3,@p4,@p5,@p6)",cmd.Connnection());
                inst.Parameters.AddWithValue("@p1", TxtAd.Text);
                inst.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                inst.Parameters.AddWithValue("@p3", MskTC.Text);
                inst.Parameters.AddWithValue("@p4", MskTelefon.Text); 
                inst.Parameters.AddWithValue("@p5", TxtSifre.Text);
                inst.Parameters.AddWithValue("@p6", CmbCinsiyet.Text);
                inst.ExecuteNonQuery();
            cmd.Connnection().Close();
            MessageBox.Show("Kayıt Başarılı... Şifreniz:" + TxtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void FrmHastaKayıt_Load(object sender, EventArgs e)
        {

        }
    }
}
