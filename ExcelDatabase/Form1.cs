using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Courses\C# 25\ExcelDatabase\Db_Excel.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;'");

        void list()
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("insert into [Sheet1$] (OrderDate, Region, Rep, Item, Units, UnitCost, Total) values (@p1,@p2,@p3@p4,@p5,@p6,@p7)", conn);
            cmd.Parameters.AddWithValue("@p1", txtDate.Text);
            cmd.Parameters.AddWithValue("@p2", txtRegion.Text);
            cmd.Parameters.AddWithValue("@p3", txtRep.Text);
            cmd.Parameters.AddWithValue("@p4", txtItems.Text);
            cmd.Parameters.AddWithValue("@p5", txtUnits.Text);
            cmd.Parameters.AddWithValue("@p6", txtUnitCost.Text);
            cmd.Parameters.AddWithValue("@p7", txtTotalCost.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            list();
        }
    }
}
