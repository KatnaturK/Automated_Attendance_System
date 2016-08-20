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
    public partial class UPDATE_ATTENDANCE : Form
    {
        string userid;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KrutantaK\Desktop\Projects\Automated Attendance System\Automated Attendance System\AUTOMATED_ATTENDANCE_SYSTEM.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        DataTable dt;
        int n;
        Label[] l1 = new Label[1000];
        Label[] l2 = new Label[1000];
        RadioButton[] rb1 = new RadioButton[1000];
        RadioButton[] rb2 = new RadioButton[1000];
        public UPDATE_ATTENDANCE(string userid)
        {
            InitializeComponent();
            this.userid = userid;
            textBox1.Text = DateTime.Now.ToString("MM/dd/yyyy");

            sda = new SqlDataAdapter("SELECT COUNT(student_id) FROM STUDENT_Table WHERE course = '" + comboBox1.Text + "'", con);
            dt = new DataTable();
            sda.Fill(dt);
            int n = Int32.Parse(dt.Rows[0][0].ToString());
            this.n = n;
            dt.Rows[0].Delete();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int i;

            if ( comboBox1.Text.Length > 0)
            {
                TableLayoutPanel tp = new TableLayoutPanel();
                tp.BackColor = Color.White;
                tp.AutoScroll = true;
                tp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                tp.Size = new Size(570,270);
                tp.Location = new Point(5, 90);
                tp.ColumnCount = 4;
                tp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                this.Controls.Add(tp);

                Label l;
                l = new Label();
                l.Text = "TEACHER_ID";
                tp.Controls.Add(l, 0, 0);
                l = new Label();
                l.Text = "STUDENT_ROll_No.";
                tp.Controls.Add(l, 1, 0);
                l = new Label();
                l.Text = "STATUS-P";
                tp.Controls.Add(l, 2, 0);
                l = new Label();
                l.Text = "STATUS-A";
                tp.Controls.Add(l, 3, 0);
                
                sda = new SqlDataAdapter("SELECT roll_no FROM STUDENT_Table WHERE course = '" + comboBox1.Text + "'", con);
                dt = new DataTable();
                sda.Fill(dt);
                for ( i=0; i<n; i++)
                {
                    l1[i] = new Label();
                    l1[i].Text = userid;
                    l1[i].Name = "label1" + i;
                    tp.Controls.Add(l1[i], 0, i+1);
                    l2[i] = new Label();
                    l2[i].Name = "label2" + i;
                    l2[i].Text = dt.Rows[0][i].ToString();
                    tp.Controls.Add(l2[i], 1, i+1);

                    rb1[i] = new RadioButton();
                    rb1[i].Name = "radiobutton1" + i;
                    rb1[i].Text = "PRESENT";
                    tp.Controls.Add(rb1[i], 2, i+1);
                    rb2[i] = new RadioButton();
                    rb2[i].Name = "radiobutton2" + i;
                    rb2[i].Text = "ABSENT";
                    tp.Controls.Add(rb2[i], 3, i+1);
                }
            }
            else
            {
                MessageBox.Show("Select appropriate course");
                comboBox1.Focus();
            }
        }

        private void UPDATE_ATTENDANCE_Load(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            sda = new SqlDataAdapter("SELECT roll_no FROM STUDENT_Table WHERE course = '" + comboBox1.Text + "'", con);
            dt = new DataTable();
            sda.Fill(dt);
            for( i=0; i<n; i++)
            {
                string name = l2[i].Text;
                string status="ABSENT";
                if (rb1[i].Checked){
                    status = "Present";
                }
                sda = new SqlDataAdapter("INSERT INTO ATTENDANCE_Table values('', '" + userid + "', '" + textBox1.Text + "', '" + name + "', '" + status + "' )", con);
                con.Open();
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();

            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            TEACHER ss = new TEACHER(userid);
            ss.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
