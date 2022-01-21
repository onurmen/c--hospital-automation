﻿using System;
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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        DatabaseConnection cmd = new DatabaseConnection();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand inst = new SqlCommand("Select * From Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", cmd.Connnection());
            inst.Parameters.AddWithValue("@p1",MskTC.Text);
            inst.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = inst.ExecuteReader();
            if (dr.Read())
            {
                FrmSekreterDetay frs = new FrmSekreterDetay();
                frs.TCnumara=MskTC.Text;   
                frs.Show();
                this.Hide();
            }
            else
            
            {
                MessageBox.Show("Hatalı TC veya Şifre");
                 
            }
            cmd.Connnection().Close();
        }

        private void FrmSekreterGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
