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

namespace Automated_Attendance_System
{
    public partial class ADD_STUDENT : Form
    {
        string userid;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KrutantaK\Desktop\Projects\Automated Attendance System\Automated Attendance System\AUTOMATED_ATTENDANCE_SYSTEM.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        public ADD_STUDENT(string userid)
        {
            InitializeComponent();
            this.userid = userid;
        }

        private void ADD_STUDENT_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1 && textBox2.Text.Length > 3 && textBox3.Text.Length == 10 && textBox4.Text.Length > 3 & textBox5.Text.Length > 3 )
            {
                sda = new SqlDataAdapter("INSERT INTO STUDENT_Table VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "','" + comboBox1.Text + "','STUDENT')", con);
                con.Open();
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();

                sda = new SqlDataAdapter("INSERT INTO LOGIN_Table VALUES('" + textBox1.Text + "','" + textBox2.Text + "','STUDENT')", con);
                con.Open();
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();

                Hide();
                ADMIN ss = new ADMIN(userid);
                ss.Show();
            }
            else
            {
                MessageBox.Show("All Fields Required!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox1.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            ADMIN ss = new ADMIN(userid);
            ss.Show();
        }
    }
}
