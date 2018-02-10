using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb ;


namespace DBcode
{
    public partial class Form2 : Form
    {
        OleDbConnection conn = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        
        int Otag;
        public Form2()
        {
            InitializeComponent();
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Fast\\Documents\\DB11.mdb";
        
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {

                conn.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from userdata";
                cmd.Connection = conn;

                da.SelectCommand = cmd;
                da.Fill(ds, "UserTable");

                dataGridView1.DataSource = ds.Tables["usertable"];
                conn.Close();
            }
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text =dataGridView1[0, e.RowIndex].Value.ToString() ;
            textBox2.Text= dataGridView1[1, e.RowIndex].Value.ToString();
            textBox3.Text = dataGridView1[2, e.RowIndex].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Enabled = false;
            textBox2.Text = "";
            textBox3.Text = "";
            
            button3.Enabled = true;
            button6.Enabled = true;
            
            Otag = 0;
            
            button2.Enabled = false;
            button1.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.ClearSelection();

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                try
                {
                    if (Otag == 0)
                    {
                        cmd.CommandText = "Insert into userdata(uname,cnic) values('" + textBox2.Text + "','" + textBox3.Text + "')";
                        da.InsertCommand = cmd;
                        da.InsertCommand.ExecuteNonQuery();
                        MessageBox.Show("Row inserted successfully", "Insert Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cmd.CommandText = "update userdata set uname= '" + textBox2.Text + "',cnic='" + textBox3.Text + "' where uid =" + textBox1.Text;
                        da.UpdateCommand = cmd;
                        da.UpdateCommand.ExecuteNonQuery();
                        MessageBox.Show("Row Updated successfully", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception Mye)
                {
                    MessageBox.Show(Mye.ToString());
                }
                
                ds.Tables.Clear();
                ds.Clear();
                conn.Close();

            }
            
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true; 
            button3.Enabled = false;
            button6.Enabled = false;

            textBox1.Text = "";
            textBox1.Enabled = false;
            textBox2.Text = "";
            textBox3.Text = "";
     

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button6.Enabled = true;
            Otag = 1;
            button2.Enabled = false;
            button1.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete user = " + textBox2.Text, "Delete Recoed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridView1.DataSource = null;
                dataGridView1.ClearSelection();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    try
                    {
                        cmd.CommandText = "delete from userdata where uid=" + textBox1.Text ;
                        da.DeleteCommand = cmd;
                        da.DeleteCommand.ExecuteNonQuery();
                        MessageBox.Show("Row deleted successfully", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception Mye)
                    {
                        MessageBox.Show(Mye.ToString());
                    }

                    ds.Tables.Clear();
                    ds.Clear();
                    conn.Close();
                    
                    textBox1.Text = "";
                    textBox1.Enabled = false;
                    textBox2.Text = "";
                    textBox3.Text = "";
                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button6.Enabled = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            
            textBox1.Text = "";
            textBox1.Enabled = false;
            textBox2.Text = "";
            textBox3.Text = "";
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        
    }

    
}
