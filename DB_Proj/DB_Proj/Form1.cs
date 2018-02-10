using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace DBcode
{
    public partial class Form1 : Form
    {
        OleDbConnection  conn = new OleDbConnection();

        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataTable tab = new DataTable();
        DataSet ds = new DataSet();
        int row = 0;

        public Form1()
        {
            InitializeComponent();
            conn.ConnectionString ="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Fast\\Documents\\DB11.mdb";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
                MessageBox.Show("Connection Open");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmd.CommandType = CommandType.Text ;
            cmd.CommandText =  textBox4.Text;
            cmd.Connection = conn;
           
            da.SelectCommand = cmd;
            da.Fill(ds);
            
            tab = ds.Tables[0];

            OleDbDataReader  dread = cmd.ExecuteReader();
            
            textBox1.Text = (ds.Tables[0].Rows[row ]["uid"]).ToString();
            textBox2.Text = (ds.Tables[0].Rows[row]["uname"]).ToString();
            textBox3.Text = (ds.Tables[0].Rows[row]["cnic"]).ToString();

            foreach (DataRow dr in tab.Rows)
            {
                MessageBox.Show(dr["uid"].ToString());

            }
          

          /*  while (dread.Read())
            {
                MessageBox.Show(dread[0].ToString());

            }*/      
        }

        private void button3_Click(object sender, EventArgs e)
        {
            row= row + 1;
            textBox1.Text = (ds.Tables[0].Rows[row]["uid"]).ToString();
            textBox2.Text = (ds.Tables[0].Rows[row]["uname"]).ToString();
            textBox3.Text = (ds.Tables[0].Rows[row]["cnic"]).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            row = row - 1;
            textBox1.Text = (ds.Tables[0].Rows[row]["uid"]).ToString();
            textBox2.Text = (ds.Tables[0].Rows[row]["uname"]).ToString();
            textBox3.Text = (ds.Tables[0].Rows[row]["cnic"]).ToString();

        }
    }
}
