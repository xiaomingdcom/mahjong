using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mahjong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }      

        private void pictureBox_humanPlayer_card1_Click(object sender, EventArgs e)
        {
            pictureBox_humanPlayer_card1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\wan1.jpg");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
