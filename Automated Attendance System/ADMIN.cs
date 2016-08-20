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
    public partial class ADMIN : Form
    {
        string userid, status;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\KrutantaK\Desktop\Projects\Automated Attendance System\Automated Attendance System\AUTOMATED_ATTENDANCE_SYSTEM.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter sda;
        DataTable dt;
        public ADMIN(string userid)
        {
            InitializeComponent();
            this.userid = userid;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            LOGIN ss = new LOGIN();
            ss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            ADD_STUDENT ss = new ADD_STUDENT(userid);
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            ADD_TEACHER ss = new ADD_TEACHER(userid);
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            CHANGE_PASSWORD ss = new CHANGE_PASSWORD(userid, "ADMIN");
            ss.Show();
        }

        private void ADMIN_Load(object sender, EventArgs e)
        {

        }
    }
}
