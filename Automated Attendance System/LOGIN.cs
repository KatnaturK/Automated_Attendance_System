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
    public partial class LOGIN : Form
    {
        string userid, status;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KrutantaK\Desktop\Projects\Automated Attendance System\Automated Attendance System\AUTOMATED_ATTENDANCE_SYSTEM.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        DataTable dt;
        public LOGIN()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if( textBox1.Text.Length > 3 && textBox2.Text.Length > 3 && comboBox1.Text.Length > 1 )
            {
                sda = new SqlDataAdapter("SELECT status FROM LOGIN_Table WHERE user_id = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'", con);
                dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count >= 1)
                {
                    status = dt.Rows[0][0].ToString();
                    userid = textBox1.Text;
                    Hide();
                    if(status.Contains("ADMIN"))
                    {
                        ADMIN ss = new ADMIN(userid);
                        ss.Show();
                    }
                    if(status.Contains("TEACHER"))
                    {
                        TEACHER ss = new TEACHER(userid);
                        ss.Show();
                    }
                    if(status.Contains("STUDENT"))
                    {
                        STUDENT ss = new STUDENT(userid);
                        ss.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid User ID or Password !");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("User ID & Password Required !");
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
            }
        }
    }
}
