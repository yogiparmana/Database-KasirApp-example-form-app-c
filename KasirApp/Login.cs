using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//database Sql import class
using System.Data.SqlClient;

namespace KasirApp
{
    public partial class Login : Form
    {
        SqlCommand sCmd;
        DataSet ds;
        SqlDataAdapter sDa;
        SqlDataReader sRd;
        string kodeKasir;
        
        Conn conn = new Conn(); //mengambil class conn
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlDataReader reader = null;
            SqlConnection connection = conn.GetConn();

            connection.Open();
            string query = "select * from TB_KASIR where KodeKasir = '" + usernameTb.Text + 
                "' and PasswordKasir = '" + passwordTb.Text + "'";
            sCmd = new SqlCommand(query,connection);
            sCmd.ExecuteNonQuery();
            reader = sCmd.ExecuteReader();
            if (reader.Read())
            {
                kodeKasir = usernameTb.Text;
                Enable();
                this.Close();
            }
            else
            {
               MessageBox.Show("Username / Password Salah!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Enable()
        { 
            Main_Menu.MainMenuStatic.masterMenu.Enabled = true;
            Main_Menu.MainMenuStatic.transaksiMenu.Enabled = true;
            Main_Menu.MainMenuStatic.laporanMenu.Enabled = true;
            Main_Menu.MainMenuStatic.utilityMenu.Enabled = true;
            Main_Menu.MainMenuStatic.logoutMenu.Enabled = true;
            Main_Menu.MainMenuStatic.loginMenu.Enabled = false;
            Main_Menu.MainMenuStatic.panel1.Visible = false;
            Main_Menu.MainMenuStatic.kodeKasir = kodeKasir;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            usernameTb.Text = "KSR002";
            passwordTb.Text = "12345";
        }
    }
}
