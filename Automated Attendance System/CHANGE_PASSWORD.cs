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
    public partial class CHANGE_PASSWORD : Form
    {
        string userid, status;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KrutantaK\Desktop\Projects\Automated Attendance System\Automated Attendance System\AUTOMATED_ATTENDANCE_SYSTEM.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        DataTable dt;
        public CHANGE_PASSWORD(string userid, string status)
        {
            InitializeComponent();
            this.userid = userid;
            this.status = status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 3 && textBox2.Text.Length > 3 && textBox3.Text.Length > 3 )
            {
                sda = new SqlDataAdapter("SELECT password FROM LOGIN_Table WHERE user_id = '" + userid + "'", con);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == textBox1.Text)
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        sda = new SqlDataAdapter("UPDATE LOGIN_Table SET password = '" + textBox2.Text + "' WHERE user_id = '" + userid + "'", con);
                        con.Open();
                        sda.SelectCommand.ExecuteNonQuery();
                        con.Close();

                        if (status.Contains("TEACHER"))
                        {
                            sda = new SqlDataAdapter("UPDATE TEACHER_Table SET password = '" + textBox2.Text + "' WHERE teacher_id = '" + userid + "'", con);
                            con.Open();
                            sda.SelectCommand.ExecuteNonQuery();
                            con.Close();
                        }
                        if (status.Contains("STUDENT"))
                        {
                            sda = new SqlDataAdapter("UPDATE STUDENT_Table SET password = '" + textBox2.Text + "' WHERE student_id = '" + userid + "'", con);
                            con.Open();
                            sda.SelectCommand.ExecuteNonQuery();
                            con.Close();
                        }

                        MessageBox.Show("Password Successfully Changed");
                        Hide();
                        if (status.Contains("ADMIN"))
                        {
                            ADMIN ss = new ADMIN(userid);
                            ss.Show();
                        }
                        if (status.Contains("TEACHER"))
                        {
                            TEACHER ss = new TEACHER(userid);
                            ss.Show();
                        }
                        if (status.Contains("STUDENT"))
                        {
                            STUDENT ss = new STUDENT(userid);
                            ss.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password does not match");
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox2.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox1.Focus();
                }
            }
            else
            {
                MessageBox.Show("All Fields Required");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            if (status.Contains("ADMIN"))
            {
                ADMIN ss = new ADMIN(userid);
                ss.Show();
            }
            if (status.Contains("TEACHER"))
            {
                TEACHER ss = new TEACHER(userid);
                ss.Show();
            }
            if (status.Contains("STUDENT"))
            {
                STUDENT ss = new STUDENT(userid);
                ss.Show();
            }
        }
    }
}
