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
        int i = 0;

        string humanPlayer_card1 = "back";
        string humanPlayer_card2 = "back";
        string humanPlayer_card3 = "back";
        string humanPlayer_card4 = "back";
        string humanPlayer_card5 = "back";
        string humanPlayer_card6 = "back";
        string humanPlayer_card7 = "back";
        string humanPlayer_card8 = "back";
        string humanPlayer_card9 = "back";
        string humanPlayer_card10 = "back";
        string humanPlayer_card11 = "back";
        string humanPlayer_card12 = "back";
        string humanPlayer_card13 = "back";
        string humanPlayer_card14 = "back";
        string leftAIPlayer_card1 = "back";
        string leftAIPlayer_card2 = "back";
        string leftAIPlayer_card3 = "back";
        string leftAIPlayer_card4 = "back";
        string leftAIPlayer_card5 = "back";
        string leftAIPlayer_card6 = "back";
        string leftAIPlayer_card7 = "back";
        string leftAIPlayer_card8 = "back";
        string leftAIPlayer_card9 = "back";
        string leftAIPlayer_card10 = "back";
        string leftAIPlayer_card11 = "back";
        string leftAIPlayer_card12 = "back";
        string leftAIPlayer_card13 = "back";
        string rightAIPlayer_card1 = "back";
        string rightAIPlayer_card2 = "back";
        string rightAIPlayer_card3 = "back";
        string rightAIPlayer_card4 = "back";
        string rightAIPlayer_card5 = "back";
        string rightAIPlayer_card6 = "back";
        string rightAIPlayer_card7 = "back";
        string rightAIPlayer_card8 = "back";
        string rightAIPlayer_card9 = "back";
        string rightAIPlayer_card10 = "back";
        string rightAIPlayer_card11 = "back";
        string rightAIPlayer_card12 = "back";
        string rightAIPlayer_card13 = "back";
        string oppositeAIPlayer_card1 = "back";
        string oppositeAIPlayer_card2 = "back";
        string oppositeAIPlayer_card3 = "back";
        string oppositeAIPlayer_card4 = "back";
        string oppositeAIPlayer_card5 = "back";
        string oppositeAIPlayer_card6 = "back";
        string oppositeAIPlayer_card7 = "back";
        string oppositeAIPlayer_card8 = "back";
        string oppositeAIPlayer_card9 = "back";
        string oppositeAIPlayer_card10 = "back";
        string oppositeAIPlayer_card11 = "back";
        string oppositeAIPlayer_card12 = "back";
        string oppositeAIPlayer_card13 = "back";

        //fapai;
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox_humanPlayer_card1_Click(object sender, EventArgs e)
        {
            pictureBox_humanPlayer_card1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\wan1.jpg");
        }

        private void pictureBox_humanPlayer_card2_Click(object sender, EventArgs e)
        {
            pictureBox_humanPlayer_card1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\tiao1.jpg");
        }
    }
}
