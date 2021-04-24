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
    public partial class FormGantiPass : Form
    {
        string kodeKasir;
        public FormGantiPass(string kodeKasir)
        {
            InitializeComponent();
            this.kodeKasir = kodeKasir;
        }

        private void FormGantiPass_Load(object sender, EventArgs e)
        {
            
            
            label2.Text = "KodeKasir Anda : " + kodeKasir;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            UpdatePass();
            this.Close();
        }
        void UpdatePass()
        {
            Conn conn = new Conn();
            SqlConnection connection = conn.GetConn();
            SqlCommand sCmd;
            try
            {
                string query = "Update TB_KASIR set PasswordKasir='" + textBox1.Text + 
                    "' Where KodeKasir='" + kodeKasir + "'";
                connection.Open();
                sCmd = new SqlCommand(query, connection);
                sCmd.ExecuteNonQuery();
                MessageBox.Show("Password Berhasil Di Update!");
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }

        }
    }
}
