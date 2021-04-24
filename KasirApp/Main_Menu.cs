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
    public partial class Main_Menu : Form
    {
        Login formLogin;
        FormGantiPass FormGantiPass;
        public static Main_Menu MainMenuStatic;

        int check;

        SqlCommand sCmd;
        public string kodeKasir;
        DataSet ds;
        SqlDataAdapter sDa;
        SqlDataReader sRd;

        Conn conn = new Conn(); //mengambil class conn
        void formclose(object sender, FormClosedEventArgs e)
        {
            formLogin = null;
            FormGantiPass = null;
        }

        public Main_Menu()
        {
            InitializeComponent();
            
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {
            splitContainer1.Visible = false;
            Disable();
            ClearTextBox();
            ClearBoxBarang();
            MainMenuStatic = this;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult d = MessageBox.Show("Yakin Ingin Keluar?", "Keluar", btn, icon);
            if (d == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        void Disable()
        {
            masterMenu.Enabled = false;
            transaksiMenu.Enabled = false;
            laporanMenu.Enabled = false;
            utilityMenu.Enabled = false;
            logoutMenu.Enabled = false;
        }

        void ClearTextBox()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "Admin";
            textBox4.Text = "";
        }

       

        private void button1_Click(object sender, EventArgs e)
        {


            if (formLogin == null)
            {
                formLogin = new Login();
                formLogin.FormClosed += new FormClosedEventHandler(formclose);
                formLogin.ShowDialog();
            }
            else
            {
                formLogin.Activate();
            }

        }

        private void loginMenu_Click(object sender, EventArgs e)
        {


            if (formLogin == null)
            {
                formLogin = new Login();
                formLogin.FormClosed += new FormClosedEventHandler(formclose);
                formLogin.ShowDialog();
            }
            else
            {
                formLogin.Activate();
            }
        }

        private void logoutMenu_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            DialogResult d = MessageBox.Show("Yakin Ingin LogOut?", "Log Out", btn, icon);
            if (d == DialogResult.Yes)
            {
                MessageBox.Show("Berhasil Logout", "Log Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Disable();
                loginMenu.Enabled = true;
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kasirMenu_Click(object sender, EventArgs e)
        {
            check = 0;
            label3.Text = "Data Pegawai Kasir";
            splitContainer1.Visible = true;
            panel6.Visible = false;
            label2.Visible = false;
            

            TampilData("TB_KASIR");
           

        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Validasi())
            {
                TambahData();
            }
  

        }
        void TampilData(string table)
        {
            
            SqlConnection connection = conn.GetConn();

            try
            {
                connection.Open();
                string query = "select * from "+table;
                sCmd = new SqlCommand(query, connection);
                ds = new DataSet();
                sDa = new SqlDataAdapter(sCmd);
                sDa.Fill(ds, table);

                //masukkan ke grid
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = table;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        void CariData(string table,string a, string b)
        {

            SqlConnection connection = conn.GetConn();

            try
            {
                connection.Open();
                string query = "select * from "+table+" where " +
                     a + " like '%"+textBox4.Text+"%' " +
                    "or "+b+" like '%"+textBox4.Text+"%'";
                sCmd = new SqlCommand(query, connection);
                ds = new DataSet();
                sDa = new SqlDataAdapter(sCmd);
                sDa.Fill(ds, table);

                //masukkan ke grid
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = table;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
        void TambahData()
        {
            
                SqlConnection connection = conn.GetConn();
                try
                {
                    string query = "insert into TB_KASIR values('" +
                        textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" +
                        comboBox1.Text + "')";
                    connection.Open();
                    sCmd = new SqlCommand(query, connection);
                    sCmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Di tambah!");
                    TampilData("TB_KASIR");
                    ClearTextBox();
                }
                catch (Exception G)
                {
                    MessageBox.Show(G.ToString());
                }

          
        }
        void ClearBoxBarang()
        {
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "0";
            textBox8.Text = "0";
            textBox10.Text = "0";
            comboBox2.Text = "PCS";

        }
        void TambahDataBarang()
        {

            SqlConnection connection = conn.GetConn();
            try
            {
                string query = "insert into TBL_BARANG values('" +
                    textBox7.Text + "','" + 
                    textBox6.Text + "','" + 
                    textBox5.Text + "','" + 
                    textBox8.Text + "','" +
                    textBox10.Text + "','" +
                    comboBox1.Text + "')";
                connection.Open();
                sCmd = new SqlCommand(query, connection);
                sCmd.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Di tambah!");
                TampilData("TBL_BARANG");
                ClearBoxBarang();
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }


        }

        bool Validasi()
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                if (textBox1.Text.Trim() == "")
                {
                    errorProvider1.SetError(textBox1, "Form Kosong!");
                }
                else
                {
                    errorProvider1.Clear();
                }
                if (textBox2.Text.Trim() == "")
                {
                    errorProvider2.SetError(textBox2, "Form Kosong!");
                }
                else
                {

                    errorProvider2.Clear();
                }
                if (textBox3.Text.Trim() == "")
                {
                    errorProvider3.SetError(textBox3, "Form Kosong!");
                }
                else
                {

                    errorProvider3.Clear();
                }
                return false;
            }
            else
            {
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();

                return true;
            }
        }

        bool ValidasiBarang()
        {
            if (textBox7.Text.Trim() == "" || textBox6.Text.Trim() == "" || textBox5.Text.Trim() == "" || textBox8.Text.Trim() == "" || textBox10.Text.Trim() == "")
            {
                if (textBox7.Text.Trim() == "")
                {
                    errorProvider1.SetError(textBox7, "Form Kosong!");
                }
                else
                {
                    errorProvider1.Clear();
                }
                if (textBox6.Text.Trim() == "")
                {
                    errorProvider2.SetError(textBox6, "Form Kosong!");
                }
                else
                {

                    errorProvider2.Clear();
                }
                if (textBox5.Text.Trim() == "")
                {
                    errorProvider3.SetError(textBox5, "Form Kosong!");
                }
                else
                {

                    errorProvider3.Clear();
                }
                if (textBox8.Text.Trim() == "")
                {
                    errorProvider4.SetError(textBox8, "Form Kosong!");
                }
                else
                {

                    errorProvider4.Clear();
                }
                if (textBox10.Text.Trim() == "")
                {
                    errorProvider5.SetError(textBox10, "Form Kosong!");
                }
                else
                {

                    errorProvider5.Clear();
                }
                return false;
            }
            else
            {
                errorProvider1.Clear();
                errorProvider2.Clear();
                errorProvider3.Clear();
                errorProvider4.Clear();
                errorProvider5.Clear();

                return true;
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                if(check == 0)
                {
                    textBox1.Text = row.Cells["KodeKasir"].Value.ToString();
                    textBox1.Enabled = false;
                    textBox2.Text = row.Cells["NamaKasir"].Value.ToString();
                    textBox3.Text = row.Cells["PasswordKasir"].Value.ToString();
                    comboBox1.Text = row.Cells["LevelKasir"].Value.ToString();
                    button2.Enabled = false;
                }

                if(check == 1)
                {
                    textBox7.Text = row.Cells["KodeBrg"].Value.ToString();
                    textBox7.Enabled = false;
                    textBox6.Text = row.Cells["NamaBrg"].Value.ToString();
                    textBox5.Text = row.Cells["HargaBeli"].Value.ToString();
                    textBox8.Text = row.Cells["HargaJual"].Value.ToString();
                    textBox10.Text = row.Cells["JumlahBrg"].Value.ToString();
                    comboBox2.Text = row.Cells["SatuanBrg"].Value.ToString();
                    button9.Enabled = false;
                }

               
            }catch(Exception g)
            {
                MessageBox.Show(g.ToString());
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (Validasi())
            {
                UpdateData(0);
                textBox1.Enabled = true;
            }
        }

        void UpdateData(int i)
        {
            string query = "";
            SqlConnection connection = conn.GetConn();
                try
                {
                
                if (i == 0)
                {
                    query = "Update TB_KASIR set NamaKasir='" + textBox2.Text + "',PasswordKasir='" + textBox3.Text + "',LevelKasir='" +
                        comboBox1.Text + "' Where KodeKasir='" + textBox1.Text + "'";
                    connection.Open();
                    sCmd = new SqlCommand(query, connection);
                    sCmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Di Update!");
                    TampilData("TB_KASIR");
                    ClearTextBox();
                }
                if (i == 1)
                {
                    query = "Update TBL_BARANG set NamaBrg='" + textBox6.Text + 
                        "',HargaBeli='" + textBox5.Text +
                        "',HargaJual='" + textBox8.Text +
                        "',JumlahBrg='" + textBox10.Text +
                        "',SatuanBrg='" + comboBox2.Text + 
                        "' Where KodeBrg='" + textBox7.Text + "'";
                    connection.Open();
                    sCmd = new SqlCommand(query, connection);
                    sCmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Di Update!");
                    TampilData("TBL_BARANG");
                    ClearBoxBarang();
                }

                   
            }
                catch (Exception G)
                {
                    MessageBox.Show(G.ToString());
                }
            
        }
        void HapusData(int i)
        {
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            
            if(i == 0)
            {
                DialogResult d = MessageBox.Show("Yakin Ingin Hapus?", "Hapus Data User : " + textBox2.Text, btn, icon);
                if (d == DialogResult.Yes)
                {
                    SqlConnection connection = conn.GetConn();
                    string query = "delete TB_KASIR Where KodeKasir='" + textBox1.Text + "'";
                    connection.Open();
                    sCmd = new SqlCommand(query, connection);
                    sCmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Di Hapus!");
                    TampilData("TB_KASIR");
                    ClearTextBox();
                }
            }
            if(i == 1)
            {
                DialogResult d = MessageBox.Show("Yakin Ingin Hapus?", "Hapus Data User : " + textBox6.Text, btn, icon);
                if (d == DialogResult.Yes)
                {
                    SqlConnection connection = conn.GetConn();
                    string query = "delete TBL_BARANG Where KodeBrg='" + textBox7.Text + "'";
                    connection.Open();
                    sCmd = new SqlCommand(query, connection);
                    sCmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Di Hapus!");
                    TampilData("TBL_BARANG");
                    ClearBoxBarang();
                }
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            HapusData(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            ClearTextBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            if(check == 0)
            {
                CariData("TB_KASIR","KodeKasir","NamaKasir");
            }

            if(check == 1)
            {
                CariData("TBL_BARANG","KodeBrg","NamaBrg");
            }
            
        }

        private void barangMenu_Click(object sender, EventArgs e)
        {
            check = 1;
            label3.Text = "Data Barang";
            splitContainer1.Visible = true;
            panel6.Visible = true;
            label2.Visible = true;
            TampilData("TBL_BARANG");

        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (ValidasiBarang())
            {
                TambahDataBarang();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ClearBoxBarang();
            button2.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (ValidasiBarang())
            {
                UpdateData(1);
                textBox7.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HapusData(1);
        }

        private void gantiPasswordMenu_Click(object sender, EventArgs e)
        {

            if (FormGantiPass == null)
            {
                FormGantiPass = new FormGantiPass(kodeKasir);
                FormGantiPass.FormClosed += new FormClosedEventHandler(formclose);
                FormGantiPass.ShowDialog();
            }
            else
            {
                FormGantiPass.Activate();
            }
        }

        private void penjualanMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dalam Proses...","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void laporanMasterMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dalam Proses...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LaporanPenjualanMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dalam Proses...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nama : I Wayan Yogi Parmana\n" +
                "NIM : 180030514","Pembuat",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
