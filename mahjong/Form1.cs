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
        int humanPlayer_havePlayedcard_num = 0;
        int leftAIPlayer_havePlayedcard_num = 0;
        int rightAIPlayer_havePlayedcard_num = 0;
        int oppositeAIPlayer_havePlayedcard_num = 0;

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

        string humanPlayer_havePlayedcard1 = "blank";
        string humanPlayer_havePlayedcard2 = "blank";
        string humanPlayer_havePlayedcard3 = "blank";
        string humanPlayer_havePlayedcard4 = "blank";
        string humanPlayer_havePlayedcard5 = "blank";
        string humanPlayer_havePlayedcard6 = "blank";
        string humanPlayer_havePlayedcard7 = "blank";
        string humanPlayer_havePlayedcard8 = "blank";
        string humanPlayer_havePlayedcard9 = "blank";
        string humanPlayer_havePlayedcard10 = "blank";
        string humanPlayer_havePlayedcard11 = "blank";
        string humanPlayer_havePlayedcard12 = "blank";
        string humanPlayer_havePlayedcard13 = "blank";
        string humanPlayer_havePlayedcard14 = "blank";

        string leftAIPlayer_havePlayedcard1 = "blank";
        string leftAIPlayer_havePlayedcard2 = "blank";
        string leftAIPlayer_havePlayedcard3 = "blank";
        string leftAIPlayer_havePlayedcard4 = "blank";
        string leftAIPlayer_havePlayedcard5 = "blank";
        string leftAIPlayer_havePlayedcard6 = "blank";
        string leftAIPlayer_havePlayedcard7 = "blank";
        string leftAIPlayer_havePlayedcard8 = "blank";
        string leftAIPlayer_havePlayedcard9 = "blank";
        string leftAIPlayer_havePlayedcard10 = "blank";
        string leftAIPlayer_havePlayedcard11 = "blank";
        string leftAIPlayer_havePlayedcard12 = "blank";
        string leftAIPlayer_havePlayedcard13 = "blank";
        string leftAIPlayer_havePlayedcard14 = "blank";

        string rightAIPlayer_havePlayedcard1 = "blank";
        string rightAIPlayer_havePlayedcard2 = "blank";
        string rightAIPlayer_havePlayedcard3 = "blank";
        string rightAIPlayer_havePlayedcard4 = "blank";
        string rightAIPlayer_havePlayedcard5 = "blank";
        string rightAIPlayer_havePlayedcard6 = "blank";
        string rightAIPlayer_havePlayedcard7 = "blank";
        string rightAIPlayer_havePlayedcard8 = "blank";
        string rightAIPlayer_havePlayedcard9 = "blank";
        string rightAIPlayer_havePlayedcard10 = "blank";
        string rightAIPlayer_havePlayedcard11 = "blank";
        string rightAIPlayer_havePlayedcard12 = "blank";
        string rightAIPlayer_havePlayedcard13 = "blank";
        string rightAIPlayer_havePlayedcard14 = "blank";

        string oppositeAIPlayer_havePlayedcard1 = "blank";
        string oppositeAIPlayer_havePlayedcard2 = "blank";
        string oppositeAIPlayer_havePlayedcard3 = "blank";
        string oppositeAIPlayer_havePlayedcard4 = "blank";
        string oppositeAIPlayer_havePlayedcard5 = "blank";
        string oppositeAIPlayer_havePlayedcard6 = "blank";
        string oppositeAIPlayer_havePlayedcard7 = "blank";
        string oppositeAIPlayer_havePlayedcard8 = "blank";
        string oppositeAIPlayer_havePlayedcard9 = "blank";
        string oppositeAIPlayer_havePlayedcard10 = "blank";
        string oppositeAIPlayer_havePlayedcard11 = "blank";
        string oppositeAIPlayer_havePlayedcard12 = "blank";
        string oppositeAIPlayer_havePlayedcard13 = "blank";
        string oppositeAIPlayer_havePlayedcard14 = "blank";

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

        public void chupai(string pai ,int N)//出牌程序
        {
            switch (N)
            {
                case 1:
                    humanPlayer_havePlayedcard1 = pai;
                    pictureBox_humanPlayer_havePlayedcard1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 2:
                    humanPlayer_havePlayedcard2 = pai;
                    pictureBox_humanPlayer_havePlayedcard2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 3:
                    humanPlayer_havePlayedcard3 = pai;
                    pictureBox_humanPlayer_havePlayedcard3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 4:
                    humanPlayer_havePlayedcard4 = pai;
                    pictureBox_humanPlayer_havePlayedcard4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 5:
                    humanPlayer_havePlayedcard5 = pai;
                    pictureBox_humanPlayer_havePlayedcard5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 6:
                    humanPlayer_havePlayedcard6 = pai;
                    pictureBox_humanPlayer_havePlayedcard6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 7:
                    humanPlayer_havePlayedcard7 = pai;
                    pictureBox_humanPlayer_havePlayedcard7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 8:
                    humanPlayer_havePlayedcard8 = pai;
                    pictureBox_humanPlayer_havePlayedcard8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 9:
                    humanPlayer_havePlayedcard9 = pai;
                    pictureBox_humanPlayer_havePlayedcard9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 10:
                    humanPlayer_havePlayedcard10 = pai;
                    pictureBox_humanPlayer_havePlayedcard10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 11:
                    humanPlayer_havePlayedcard11 = pai;
                    pictureBox_humanPlayer_havePlayedcard11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 12:
                    humanPlayer_havePlayedcard12 = pai;
                    pictureBox_humanPlayer_havePlayedcard12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 13:
                    humanPlayer_havePlayedcard13 = pai;
                    pictureBox_humanPlayer_havePlayedcard13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 14:
                    humanPlayer_havePlayedcard14 = pai;
                    pictureBox_humanPlayer_havePlayedcard14.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
            }
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
            mopai(humanPlayer_card14);
            my_show();
        }

        private void pictureBox_humanPlayer_card1_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card1,humanPlayer_havePlayedcard_num);
            humanPlayer_card1 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card2_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card2, humanPlayer_havePlayedcard_num);
            humanPlayer_card2 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card3_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card3, humanPlayer_havePlayedcard_num);
            humanPlayer_card3 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card4_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card4, humanPlayer_havePlayedcard_num);
            humanPlayer_card4 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card5_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card5, humanPlayer_havePlayedcard_num);
            humanPlayer_card5 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card6_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card6, humanPlayer_havePlayedcard_num);
            humanPlayer_card6 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card7_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card7, humanPlayer_havePlayedcard_num);
            humanPlayer_card7 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card8_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card8, humanPlayer_havePlayedcard_num);
            humanPlayer_card8 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card9_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card9, humanPlayer_havePlayedcard_num);
            humanPlayer_card9 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card10_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card10, humanPlayer_havePlayedcard_num);
            humanPlayer_card10 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card11_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card11, humanPlayer_havePlayedcard_num);
            humanPlayer_card11 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card12_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card12, humanPlayer_havePlayedcard_num);
            humanPlayer_card12 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card13_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card13, humanPlayer_havePlayedcard_num);
            humanPlayer_card13 = "blank";
            my_show();
            Thread.Sleep(500);
            ask();
            Thread.Sleep(500);
            mopai(humanPlayer_card14);
            hupai();
            my_show();
        }

        private void pictureBox_humanPlayer_card14_Click(object sender, EventArgs e)
        {
            humanPlayer_havePlayedcard_num++;
            chupai(humanPlayer_card14, humanPlayer_havePlayedcard_num);
            humanPlayer_card14 = "blank";
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
