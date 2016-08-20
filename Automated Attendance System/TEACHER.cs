using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automated_Attendance_System
{
    public partial class TEACHER : Form
    {
        string userid;
        public TEACHER(string userid)
        {
            InitializeComponent();
            this.userid = userid;
        }

        private void TEACHER_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            LOGIN ss = new LOGIN();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            CHANGE_PASSWORD ss = new CHANGE_PASSWORD(userid, "TEACHER");
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            VIEW_ATTENDANCE ss = new VIEW_ATTENDANCE(userid);
            ss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            UPDATE_ATTENDANCE ss = new UPDATE_ATTENDANCE(userid);
            ss.Show();
        }
    }
}
