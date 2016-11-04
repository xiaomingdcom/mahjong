using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace mahjong
{
    public partial class Form1 : Form
    {
        int i = 0;

        string humanPlayer_card1 = "blank";
        string humanPlayer_card2 = "blank";
        string humanPlayer_card3 = "blank";
        string humanPlayer_card4 = "blank";
        string humanPlayer_card5 = "blank";
        string humanPlayer_card6 = "blank";
        string humanPlayer_card7 = "blank";
        string humanPlayer_card8 = "blank";
        string humanPlayer_card9 = "blank";
        string humanPlayer_card10 = "blank";
        string humanPlayer_card11 = "blank";
        string humanPlayer_card12 = "blank";
        string humanPlayer_card13 = "blank";
        string humanPlayer_card14 = "blank";
        string leftAIPlayer_card1 = "cardback";
        string leftAIPlayer_card2 = "cardback";
        string leftAIPlayer_card3 = "cardback";
        string leftAIPlayer_card4 = "cardback";
        string leftAIPlayer_card5 = "cardback";
        string leftAIPlayer_card6 = "cardback";
        string leftAIPlayer_card7 = "cardback";
        string leftAIPlayer_card8 = "cardback";
        string leftAIPlayer_card9 = "cardback";
        string leftAIPlayer_card10 = "cardback";
        string leftAIPlayer_card11 = "cardback";
        string leftAIPlayer_card12 = "cardback";
        string leftAIPlayer_card13 = "cardback";
        string rightAIPlayer_card1 = "cardback";
        string rightAIPlayer_card2 = "cardback";
        string rightAIPlayer_card3 = "cardback";
        string rightAIPlayer_card4 = "cardback";
        string rightAIPlayer_card5 = "cardback";
        string rightAIPlayer_card6 = "cardback";
        string rightAIPlayer_card7 = "cardback";
        string rightAIPlayer_card8 = "cardback";
        string rightAIPlayer_card9 = "cardback";
        string rightAIPlayer_card10 = "cardback";
        string rightAIPlayer_card11 = "cardback";
        string rightAIPlayer_card12 = "cardback";
        string rightAIPlayer_card13 = "cardback";
        string oppositeAIPlayer_card1 = "cardback";
        string oppositeAIPlayer_card2 = "cardback";
        string oppositeAIPlayer_card3 = "cardback";
        string oppositeAIPlayer_card4 = "cardback";
        string oppositeAIPlayer_card5 = "cardback";
        string oppositeAIPlayer_card6 = "cardback";
        string oppositeAIPlayer_card7 = "cardback";
        string oppositeAIPlayer_card8 = "cardback";
        string oppositeAIPlayer_card9 = "cardback";
        string oppositeAIPlayer_card10 = "cardback";
        string oppositeAIPlayer_card11 = "cardback";
        string oppositeAIPlayer_card12 = "cardback";
        string oppositeAIPlayer_card13 = "cardback";

        public void fapai()//发牌程序
        {
            humanPlayer_card1 = "w1";
            humanPlayer_card2 = "w1";
            humanPlayer_card3 = "w1";
            humanPlayer_card4 = "w1";
            humanPlayer_card5 = "w1";
            humanPlayer_card6 = "w1";
            humanPlayer_card7 = "w1";
            humanPlayer_card8 = "w1";
            humanPlayer_card9 = "w1";
            humanPlayer_card10 = "w1";
            humanPlayer_card11 = "w1";
            humanPlayer_card12 = "w1";
            humanPlayer_card13 = "w1";
            humanPlayer_card14 = "w1";
        }

        public void mopai(string pai)//摸牌程序
        {
            humanPlayer_card14 = "w1";
        }

        public void chupai(string pai)//出牌程序
        {

        }

        public void ask()//询问是否碰，杠
        {

        }

        public void hupai()//判断是否和牌
        {

        }

        public void my_show()//整理手牌并显示图片
        {
            pictureBox_humanPlayer_card1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card1 + ".jpg");
            pictureBox_humanPlayer_card2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card2 + ".jpg");
            pictureBox_humanPlayer_card3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card3 + ".jpg");
            pictureBox_humanPlayer_card4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card4 + ".jpg");
            pictureBox_humanPlayer_card5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card5 + ".jpg");
            pictureBox_humanPlayer_card6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card6 + ".jpg");
            pictureBox_humanPlayer_card7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card7 + ".jpg");
            pictureBox_humanPlayer_card8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card8 + ".jpg");
            pictureBox_humanPlayer_card9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card9 + ".jpg");
            pictureBox_humanPlayer_card10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card10 + ".jpg");
            pictureBox_humanPlayer_card11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card11 + ".jpg");
            pictureBox_humanPlayer_card12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card12 + ".jpg");
            pictureBox_humanPlayer_card13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card13 + ".jpg");
            pictureBox_humanPlayer_card14.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + humanPlayer_card14 + ".jpg");
        }

        public Form1()
        {
            InitializeComponent();
            pictureBox_leftAIPlayer_card1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card1 + ".jpg");
            pictureBox_leftAIPlayer_card2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card2 + ".jpg");
            pictureBox_leftAIPlayer_card3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card3 + ".jpg");
            pictureBox_leftAIPlayer_card4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card4 + ".jpg");
            pictureBox_leftAIPlayer_card5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card5 + ".jpg");
            pictureBox_leftAIPlayer_card6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card6 + ".jpg");
            pictureBox_leftAIPlayer_card7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card7 + ".jpg");
            pictureBox_leftAIPlayer_card8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card8 + ".jpg");
            pictureBox_leftAIPlayer_card9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card9 + ".jpg");
            pictureBox_leftAIPlayer_card10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card10 + ".jpg");
            pictureBox_leftAIPlayer_card11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card11 + ".jpg");
            pictureBox_leftAIPlayer_card12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card12 + ".jpg");
            pictureBox_leftAIPlayer_card13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + leftAIPlayer_card13 + ".jpg");

            pictureBox_rightAIPlayer_card1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card1 + ".jpg");
            pictureBox_rightAIPlayer_card2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card2 + ".jpg");
            pictureBox_rightAIPlayer_card3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card3 + ".jpg");
            pictureBox_rightAIPlayer_card4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card4 + ".jpg");
            pictureBox_rightAIPlayer_card5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card5 + ".jpg");
            pictureBox_rightAIPlayer_card6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card6 + ".jpg");
            pictureBox_rightAIPlayer_card7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card7 + ".jpg");
            pictureBox_rightAIPlayer_card8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card8 + ".jpg");
            pictureBox_rightAIPlayer_card9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card9 + ".jpg");
            pictureBox_rightAIPlayer_card10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card10 + ".jpg");
            pictureBox_rightAIPlayer_card11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card11 + ".jpg");
            pictureBox_rightAIPlayer_card12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card12 + ".jpg");
            pictureBox_rightAIPlayer_card13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + rightAIPlayer_card13 + ".jpg");

            pictureBox_oppositeAIPlayer_card1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card1 + ".jpg");
            pictureBox_oppositeAIPlayer_card2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card2 + ".jpg");
            pictureBox_oppositeAIPlayer_card3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card3 + ".jpg");
            pictureBox_oppositeAIPlayer_card4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card4 + ".jpg");
            pictureBox_oppositeAIPlayer_card5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card5 + ".jpg");
            pictureBox_oppositeAIPlayer_card6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card6 + ".jpg");
            pictureBox_oppositeAIPlayer_card7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card7 + ".jpg");
            pictureBox_oppositeAIPlayer_card8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card8 + ".jpg");
            pictureBox_oppositeAIPlayer_card9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card9 + ".jpg");
            pictureBox_oppositeAIPlayer_card10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card10 + ".jpg");
            pictureBox_oppositeAIPlayer_card11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card11 + ".jpg");
            pictureBox_oppositeAIPlayer_card12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card12 + ".jpg");
            pictureBox_oppositeAIPlayer_card13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + oppositeAIPlayer_card13 + ".jpg");
            fapai();
            my_show();
            Thread.Sleep(500);
            mopai();
            my_show();
        }

        private void pictureBox_humanPlayer_card1_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card1);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card1);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card2_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card2);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card2);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card3_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card3);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card3);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card4_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card4);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card4);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card5_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card5);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card5);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card6_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card6);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card6);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card7_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card7);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card7);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card8_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card8);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card8);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card9_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card9);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card9);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card10_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card10);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card10);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card11_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card11);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card11);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card12_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card12);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card12);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card13_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card13);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card13);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card14_Click(object sender, EventArgs e)
        {
            chupai(humanPlayer_card14);
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }
    }
}
