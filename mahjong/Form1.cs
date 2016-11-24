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
using System.Media;
using System.Runtime.InteropServices;
using TableCPPDLL;

namespace mahjong
{
    public partial class Form1 : Form
    {
        #region//变量定义
        //cTable ta = new cTable();
        protected bool humanPlayer_gameover = false;
        protected bool rightAIPlayer_gameover = false;
        protected bool oppositeAIPlayer_gameover = false;
        protected bool leftAIPlayer_gameover = false;
        protected int intgameover = 0;//gameover=3时游戏结束，三个人胡了
        protected bool rightAIPlayer_chupai_cancel = false;
        protected bool oppositeAIPlayer_chupai_cancel = false;


        public static int D_X = 2;//location.x的改变
        public static int D_Y = 6;//location.y的改变
        public static int D_WIDTH = 4;//width的改变
        public static int D_HEIGHT = 6;//height的改变

        public bool humanPlayerdone = false;
        public bool rightAIPlayerdone = false;
        public bool oppositeAIPlayerdone = false;
        public bool leftAIPlayerdone = false;

        public static int TIME_MAX = 100;

        int humanPlayer_havePlayedcard_num = 0;//玩家已出牌计数
        int leftAIPlayer_havePlayedcard_num = 0;
        int rightAIPlayer_havePlayedcard_num = 0;
        int oppositeAIPlayer_havePlayedcard_num = 0;
        public bool humanPlayer_start = false;//从哪位玩家开始
        bool rightAIPlayer_start = false;
        bool oppositeAIPlayer_start = false;
        bool leftAIPlayer_start = false;

        protected SoundPlayer sp;
        #endregion

        #region//get方法
        public PictureBox gethumanpb1()//返回return pictureBox_humanPlayer_cardi
        {
            return pictureBox_humanPlayer_card1;
        }
        public PictureBox gethumanpb2()
        {
            return pictureBox_humanPlayer_card2;
        }
        public PictureBox gethumanpb3()
        {
            return pictureBox_humanPlayer_card3;
        }
        public PictureBox gethumanpb4()
        {
            return pictureBox_humanPlayer_card4;
        }
        public PictureBox gethumanpb5()
        {
            return pictureBox_humanPlayer_card5;
        }
        public PictureBox gethumanpb6()
        {
            return pictureBox_humanPlayer_card6;
        }
        public PictureBox gethumanpb7()
        {
            return pictureBox_humanPlayer_card7;
        }
        public PictureBox gethumanpb8()
        {
            return pictureBox_humanPlayer_card8;
        }
        public PictureBox gethumanpb9()
        {
            return pictureBox_humanPlayer_card9;
        }
        public PictureBox gethumanpb10()
        {
            return pictureBox_humanPlayer_card10;
        }
        public PictureBox gethumanpb11()
        {
            return pictureBox_humanPlayer_card11;
        }
        public PictureBox gethumanpb12()
        {
            return pictureBox_humanPlayer_card12;
        }
        public PictureBox gethumanpb13()
        {
            return pictureBox_humanPlayer_card13;
        }
        public PictureBox gethumanpb14()
        {
            return pictureBox_humanPlayer_card14;
        }
        public PictureBox gethumanhaveplayedpb1()
        {
            return pictureBox_humanPlayer_havePlayedcard1;
        }
        public PictureBox gethumanhaveplayedpb2()
        {
            return pictureBox_humanPlayer_havePlayedcard2;
        }
        public PictureBox gethumanhaveplayedpb3()
        {
            return pictureBox_humanPlayer_havePlayedcard3;
        }
        public PictureBox gethumanhaveplayedpb4()
        {
            return pictureBox_humanPlayer_havePlayedcard4;
        }
        public PictureBox gethumanhaveplayedpb5()
        {
            return pictureBox_humanPlayer_havePlayedcard5;
        }
        public PictureBox gethumanhaveplayedpb6()
        {
            return pictureBox_humanPlayer_havePlayedcard6;
        }
        public PictureBox gethumanhaveplayedpb7()
        {
            return pictureBox_humanPlayer_havePlayedcard7;
        }
        public PictureBox gethumanhaveplayedpb8()
        {
            return pictureBox_humanPlayer_havePlayedcard8;
        }
        public PictureBox gethumanhaveplayedpb9()
        {
            return pictureBox_humanPlayer_havePlayedcard9;
        }
        public PictureBox gethumanhaveplayedpb10()
        {
            return pictureBox_humanPlayer_havePlayedcard10;
        }
        public PictureBox gethumanhaveplayedpb11()
        {
            return pictureBox_humanPlayer_havePlayedcard11;
        }
        public PictureBox gethumanhaveplayedpb12()
        {
            return pictureBox_humanPlayer_havePlayedcard12;
        }
        public PictureBox gethumanhaveplayedpb13()
        {
            return pictureBox_humanPlayer_havePlayedcard13;
        }
        public PictureBox gethumanhaveplayedpb14()
        {
            return pictureBox_humanPlayer_havePlayedcard14;
        }
        #endregion

        public void whostart()//从哪个玩家开始
        {
            humanPlayer_start = true;
        }

        public void fapai()//发牌程序
        {
            pictureBox_humanPlayer_card1.Name = "b3";
            pictureBox_humanPlayer_card2.Name = "t2";
            pictureBox_humanPlayer_card3.Name = "t1";
            pictureBox_humanPlayer_card4.Name = "t4";
            pictureBox_humanPlayer_card5.Name = "t5";
            pictureBox_humanPlayer_card6.Name = "t6";
            pictureBox_humanPlayer_card7.Name = "t7";
            pictureBox_humanPlayer_card8.Name = "t8";
            pictureBox_humanPlayer_card9.Name = "t9";
            pictureBox_humanPlayer_card10.Name = "w1";
            pictureBox_humanPlayer_card11.Name = "w2";
            pictureBox_humanPlayer_card12.Name = "w3";
            pictureBox_humanPlayer_card13.Name = "w4";
            pictureBox_humanPlayer_card14.Name = "blank";
        }

        public void human_picturebox_enablef()
        {
            pictureBox_humanPlayer_card1.Enabled = false;//start之前不可响应
            pictureBox_humanPlayer_card2.Enabled = false;
            pictureBox_humanPlayer_card3.Enabled = false;
            pictureBox_humanPlayer_card4.Enabled = false;
            pictureBox_humanPlayer_card5.Enabled = false;
            pictureBox_humanPlayer_card6.Enabled = false;
            pictureBox_humanPlayer_card7.Enabled = false;
            pictureBox_humanPlayer_card8.Enabled = false;
            pictureBox_humanPlayer_card9.Enabled = false;
            pictureBox_humanPlayer_card10.Enabled = false;
            pictureBox_humanPlayer_card11.Enabled = false;
            pictureBox_humanPlayer_card12.Enabled = false;
            pictureBox_humanPlayer_card13.Enabled = false;
            pictureBox_humanPlayer_card14.Enabled = false;
        }

        public void human_picturebox_enablet()
        {
            pictureBox_humanPlayer_card1.Enabled = true;//start之前不可响应
            pictureBox_humanPlayer_card2.Enabled = true;
            pictureBox_humanPlayer_card3.Enabled = true;
            pictureBox_humanPlayer_card4.Enabled = true;
            pictureBox_humanPlayer_card5.Enabled = true;
            pictureBox_humanPlayer_card6.Enabled = true;
            pictureBox_humanPlayer_card7.Enabled = true;
            pictureBox_humanPlayer_card8.Enabled = true;
            pictureBox_humanPlayer_card9.Enabled = true;
            pictureBox_humanPlayer_card10.Enabled = true;
            pictureBox_humanPlayer_card11.Enabled = true;
            pictureBox_humanPlayer_card12.Enabled = true;
            pictureBox_humanPlayer_card13.Enabled = true;
            pictureBox_humanPlayer_card14.Enabled = true;
        }   

        protected void my_initialize()//自定义初始化内容
        {
            humanPlayer_gameover = false;
            rightAIPlayer_gameover = false;
            oppositeAIPlayer_gameover = false;
            leftAIPlayer_gameover = false;
            intgameover = 0;

            humanPlayer_money.Visible = false;
            rightAIPlayer_money.Visible = false;
            oppositeAIPlayer_money.Visible = false;
            leftAIPlayer_money.Visible = false;

            humanPlayer_start = false;
            rightAIPlayer_start = false;
            oppositeAIPlayer_start = false;
            leftAIPlayer_start = false;

            human_peng.Enabled = false;
            human_gang.Enabled = false;
            human_hu.Enabled = false;
            human_guo.Enabled = false;

            human_peng.Name = "no";
            human_gang.Name = "no";
            human_hu.Name = "no";
            human_guo.Name = "no";

            game_start.Visible = true;

            human_picturebox_enablef();

            //三个AIPlayer手牌只显示背面
            pictureBox_leftAIPlayer_card1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_leftAIPlayer_card13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");

            pictureBox_rightAIPlayer_card1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_rightAIPlayer_card13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");

            pictureBox_oppositeAIPlayer_card1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");
            pictureBox_oppositeAIPlayer_card13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\cardback.jpg");

            //出过得牌数置零
            humanPlayer_havePlayedcard_num = 0;
            leftAIPlayer_havePlayedcard_num = 0;
            rightAIPlayer_havePlayedcard_num = 0;
            oppositeAIPlayer_havePlayedcard_num = 0;

            //humanPlayer手牌初始为blank
            pictureBox_humanPlayer_card1.Name = "blank";
            pictureBox_humanPlayer_card2.Name = "blank";
            pictureBox_humanPlayer_card3.Name = "blank";
            pictureBox_humanPlayer_card4.Name = "blank";
            pictureBox_humanPlayer_card5.Name = "blank";
            pictureBox_humanPlayer_card6.Name = "blank";
            pictureBox_humanPlayer_card7.Name = "blank";
            pictureBox_humanPlayer_card8.Name = "blank";
            pictureBox_humanPlayer_card9.Name = "blank";
            pictureBox_humanPlayer_card10.Name = "blank";
            pictureBox_humanPlayer_card11.Name = "blank";
            pictureBox_humanPlayer_card12.Name = "blank";
            pictureBox_humanPlayer_card13.Name = "blank";
            pictureBox_humanPlayer_card14.Name = "blank";

            //四位玩家已打出的牌初始化
            pictureBox_humanPlayer_havePlayedcard1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_humanPlayer_havePlayedcard14.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");

            pictureBox_rightAIPlayer_havePlayedcard1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_rightAIPlayer_havePlayedcard14.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");

            pictureBox_oppositeAIPlayer_havePlayedcard1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_oppositeAIPlayer_havePlayedcard14.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");

            pictureBox_leftAIPlayer_havePlayedcard1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
            pictureBox_leftAIPlayer_havePlayedcard14.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\blank.jpg");
        }

        protected void gameover()//游戏结束要执行的操作
        {
            humanPlayer_money.Text = "money:100";//赢/输多少钱
            rightAIPlayer_money.Text = "money:100";
            oppositeAIPlayer_money.Text = "money:100";
            leftAIPlayer_money.Text = "money:100";

            humanPlayer_money.Visible = true;
            rightAIPlayer_money.Visible = true;
            oppositeAIPlayer_money.Visible = true;
            leftAIPlayer_money.Visible = true;

            if (true)//如果赢
            {
                MessageBox.Show("you win", "", MessageBoxButtons.OK);
            }
            else//输
            {
                MessageBox.Show("you lose", "", MessageBoxButtons.OK);
            }
            if (MessageBox.Show("是否重新开始游戏", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //初始化
                my_initialize();
            }
            else
            {
                mediaplayer_backgroundmusic.Ctlcontrols.stop();
                Application.Exit();//退出游戏
            }
        }

        public void human_mopai()//摸牌程序
        {
            pictureBox_humanPlayer_card14.Name = "t1";
        }

        public void humanPlayer_chupai(string pai)//出牌程序
        {
            #region//出牌
            humanPlayer_havePlayedcard_num++;
            switch (humanPlayer_havePlayedcard_num)
            {
                case 1:
                    pictureBox_humanPlayer_havePlayedcard1.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 2:
                    pictureBox_humanPlayer_havePlayedcard2.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 3:
                    pictureBox_humanPlayer_havePlayedcard3.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 4:
                    pictureBox_humanPlayer_havePlayedcard4.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 5:
                    pictureBox_humanPlayer_havePlayedcard5.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 6:
                    pictureBox_humanPlayer_havePlayedcard6.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 7:
                    pictureBox_humanPlayer_havePlayedcard7.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 8:
                    pictureBox_humanPlayer_havePlayedcard8.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 9:
                    pictureBox_humanPlayer_havePlayedcard9.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 10:
                    pictureBox_humanPlayer_havePlayedcard10.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 11:
                    pictureBox_humanPlayer_havePlayedcard11.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 12:
                    pictureBox_humanPlayer_havePlayedcard12.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 13:
                    pictureBox_humanPlayer_havePlayedcard13.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 14:
                    pictureBox_humanPlayer_havePlayedcard14.Name = pai;
                    pictureBox_humanPlayer_havePlayedcard14.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                default:
                    //gameover
                    break;
            }
            sp=new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\humanPlayer\\" + pai + ".wav");
            sp.PlaySync();
            #endregion

            #region//ask           
            if (rightAIPlayer_gameover == false)
            {
                //ask_rightAIPlayer_gang();
                //ask_rightAIPlayer_peng();
                ask_rightAIPlayer_hu();
            }
            if (oppositeAIPlayer_gameover == false)
            {
                //ask_oppositeAIPlayer_peng();
                //ask_oppositeAIPlayer_gang();
                //ask_oppositeAIPlayer_hu();
            }
            if (leftAIPlayer_gameover == false)
            {
                //ask_leftAIPlayer_peng();
                //ask_leftAIPlayer_gang();
                //ask_leftAIPlayer_hu();
            }
            #endregion

            humanPlayerdone = true;
            leftAIPlayerdone = false;
        }

        public void human_play(object param)
        {
            for (int i = 0; ; i++)
            {
                if (leftAIPlayerdone == false)
                {
                    Thread.Sleep(500);
                }
                else
                {
                    break;
                }
            }
            if (humanPlayer_gameover == true)
            {
                humanPlayerdone = true;
                leftAIPlayerdone = false;
                Thread.CurrentThread.Abort();
            }
            human_mopai();
            my_show();
            ask_humanPlayer_hu();
            if (humanPlayer_gameover == false)
            {
                human_picturebox_enablet();
            }
            Thread.CurrentThread.Abort();
        }

        protected void rightAIPlayer_next()
        {
            rightAIPlayerdone = true;
            humanPlayerdone = false;
            Thread.CurrentThread.Abort();
        }

        public void rightAIPlayer_chupai(object param)
        {
            Thread.Sleep(500);
            for (int i = 0; ; i++)
            {
                if (humanPlayerdone == false)//humanplayer未出牌
                {
                    Thread.Sleep(500);
                }
                else
                {
                    break;
                }
            }

            if (rightAIPlayer_gameover == true||rightAIPlayer_chupai_cancel==true)
            {
                rightAIPlayer_chupai_cancel = false;
                rightAIPlayer_next();
            }

            #region//出牌
            string pai = "t1";
            Image picture_ro = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
            rightAIPlayer_havePlayedcard_num++;
            switch (rightAIPlayer_havePlayedcard_num)
            {
                case 1:
                    pictureBox_rightAIPlayer_havePlayedcard1.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard1.Image = picture_ro;
                    break;
                case 2:
                    pictureBox_rightAIPlayer_havePlayedcard2.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard2.Image = picture_ro;
                    break;
                case 3:
                    pictureBox_rightAIPlayer_havePlayedcard3.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard3.Image = picture_ro;
                    break;
                case 4:
                    pictureBox_rightAIPlayer_havePlayedcard4.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard4.Image = picture_ro;
                    break;
                case 5:
                    pictureBox_rightAIPlayer_havePlayedcard5.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard5.Image = picture_ro;
                    break;
                case 6:
                    pictureBox_rightAIPlayer_havePlayedcard6.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard6.Image = picture_ro;
                    break;
                case 7:
                    pictureBox_rightAIPlayer_havePlayedcard7.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard7.Image = picture_ro;
                    break;
                case 8:
                    pictureBox_rightAIPlayer_havePlayedcard8.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard8.Image = picture_ro;
                    break;
                case 9:
                    pictureBox_rightAIPlayer_havePlayedcard9.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard9.Image = picture_ro;
                    break;
                case 10:
                    pictureBox_rightAIPlayer_havePlayedcard10.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard10.Image = picture_ro;
                    break;
                case 11:
                    pictureBox_rightAIPlayer_havePlayedcard11.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard11.Image = picture_ro;
                    break;
                case 12:
                    pictureBox_rightAIPlayer_havePlayedcard12.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard12.Image = picture_ro;
                    break;
                case 13:
                    pictureBox_rightAIPlayer_havePlayedcard13.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard13.Image = picture_ro;
                    break;
                case 14:
                    pictureBox_rightAIPlayer_havePlayedcard14.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard14.Image = picture_ro;
                    break;
                default:
                    break;
            }
            sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\rightAIPlayer\\" + pai + ".wav");
            sp.PlaySync();
            #endregion


            #region//ask
            if (oppositeAIPlayer_gameover == false)
            {
                //ask_oppositeAIPlayer_gang();
                //ask_oppositeAIPlayer_peng();
                //ask_oppositeAIPlayer_hu();
            }
            if (leftAIPlayer_gameover == false)
            {
                //ask_leftAIPlayer_gang();
                //ask_leftAIPlayer_peng();
                //ask_leftAIPlayer_hu();
            }
            if (humanPlayer_gameover == false)
            {
                //ask_humanPlayer_peng();
                //ask_humanPlayer_gang();
                ask_humanPlayer_hu();
            }
            #endregion

            rightAIPlayer_next();
        }

        protected void oppsiteAIPlayer_next()
        {
            oppositeAIPlayerdone = true;
            rightAIPlayerdone = false;
            Thread.CurrentThread.Abort();
        }

        public void oppositeAIPlayer_chupai(object param)
        {
            Thread.Sleep(1000);
            for (int i = 0; ; i++)
            {
                if (rightAIPlayerdone == false)//humanplayer未出牌
                {
                    Thread.Sleep(500);
                }
                else
                {
                    break;
                }
            }

            if (oppositeAIPlayer_gameover == true||oppositeAIPlayer_chupai_cancel==true)
            {
                oppositeAIPlayer_chupai_cancel = false;
                oppsiteAIPlayer_next();//下一个玩家开始
            }

            #region//出牌
            string pai = "t1";
            Image picture_ro = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);
            oppositeAIPlayer_havePlayedcard_num++;
            switch (oppositeAIPlayer_havePlayedcard_num)
            {
                case 1:
                    pictureBox_oppositeAIPlayer_havePlayedcard1.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard1.Image = picture_ro;
                    break;
                case 2:
                    pictureBox_oppositeAIPlayer_havePlayedcard2.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard2.Image = picture_ro;
                    break;
                case 3:
                    pictureBox_oppositeAIPlayer_havePlayedcard3.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard3.Image = picture_ro;
                    break;
                case 4:
                    pictureBox_oppositeAIPlayer_havePlayedcard4.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard4.Image = picture_ro;
                    break;
                case 5:
                    pictureBox_oppositeAIPlayer_havePlayedcard5.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard5.Image = picture_ro;
                    break;
                case 6:
                    pictureBox_oppositeAIPlayer_havePlayedcard6.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard6.Image = picture_ro;
                    break;
                case 7:
                    pictureBox_oppositeAIPlayer_havePlayedcard7.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard7.Image = picture_ro;
                    break;
                case 8:
                    pictureBox_oppositeAIPlayer_havePlayedcard8.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard8.Image = picture_ro;
                    break;
                case 9:
                    pictureBox_oppositeAIPlayer_havePlayedcard9.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard9.Image = picture_ro;
                    break;
                case 10:
                    pictureBox_oppositeAIPlayer_havePlayedcard10.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard10.Image = picture_ro;
                    break;
                case 11:
                    pictureBox_oppositeAIPlayer_havePlayedcard11.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard11.Image = picture_ro;
                    break;
                case 12:
                    pictureBox_oppositeAIPlayer_havePlayedcard12.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard12.Image = picture_ro;
                    break;
                case 13:
                    pictureBox_oppositeAIPlayer_havePlayedcard13.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard13.Image = picture_ro;
                    break;
                case 14:
                    pictureBox_oppositeAIPlayer_havePlayedcard14.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard14.Image = picture_ro;
                    break;
                default:
                    break;
            }
            sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\oppositeAIPlayer\\" + pai + ".wav");
            sp.PlaySync();
            #endregion

            #region//ask
            if (leftAIPlayer_gameover == false)
            {
                //ask_leftAIPlayer_gang();
                //ask_leftAIPlayer_peng();
                //ask_leftAIPlayer_hu();
            }
            if (humanPlayer_gameover == false)
            {
                //ask_humanPlayer_peng();
                //ask_humanPlayer_gang();
                ask_humanPlayer_hu();
            }
            if (rightAIPlayer_gameover == false)
            {
                //ask_rightAIPlayer_gang();
                //ask_rightAIPlayer_peng();
                //ask_rightAIPlayer_hu();
            }
            #endregion

            oppsiteAIPlayer_next();            
        }

        protected void leftAIPlayer_next()
        {
            leftAIPlayerdone = true;
            oppositeAIPlayerdone = false;
            Thread.CurrentThread.Abort();
        }

        public void leftAIPlayer_chupai(object param)
        {
            Thread.Sleep(1500);
            for (int i = 0; ; i++)
            {
                if (oppositeAIPlayerdone == false)//humanplayer未出牌
                {
                    Thread.Sleep(500);
                }
                else
                {
                    break;
                }
            }

            if (leftAIPlayer_gameover == true)
            {
                leftAIPlayer_next();
            }

            #region//出牌
            string pai = "t1";
            Image picture_ro = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate90FlipNone);
            leftAIPlayer_havePlayedcard_num++;
            switch (leftAIPlayer_havePlayedcard_num)
            {
                case 1:
                    pictureBox_leftAIPlayer_havePlayedcard1.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard1.Image = picture_ro;
                    break;
                case 2:
                    pictureBox_leftAIPlayer_havePlayedcard2.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard2.Image = picture_ro;
                    break;
                case 3:
                    pictureBox_leftAIPlayer_havePlayedcard3.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard3.Image = picture_ro;
                    break;
                case 4:
                    pictureBox_leftAIPlayer_havePlayedcard4.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard4.Image = picture_ro;
                    break;
                case 5:
                    pictureBox_leftAIPlayer_havePlayedcard5.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard5.Image = picture_ro;
                    break;
                case 6:
                    pictureBox_leftAIPlayer_havePlayedcard6.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard6.Image = picture_ro;
                    break;
                case 7:
                    pictureBox_leftAIPlayer_havePlayedcard7.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard7.Image = picture_ro;
                    break;
                case 8:
                    pictureBox_leftAIPlayer_havePlayedcard8.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard8.Image = picture_ro;
                    break;
                case 9:
                    pictureBox_leftAIPlayer_havePlayedcard9.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard9.Image = picture_ro;
                    break;
                case 10:
                    pictureBox_leftAIPlayer_havePlayedcard10.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard10.Image = picture_ro;
                    break;
                case 11:
                    pictureBox_leftAIPlayer_havePlayedcard11.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard11.Image = picture_ro;
                    break;
                case 12:
                    pictureBox_leftAIPlayer_havePlayedcard12.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard12.Image = picture_ro;
                    break;
                case 13:
                    pictureBox_leftAIPlayer_havePlayedcard13.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard13.Image = picture_ro;
                    break;
                case 14:
                    pictureBox_leftAIPlayer_havePlayedcard14.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard14.Image = picture_ro;
                    break;
                default:
                    break;
            }
            sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\leftAIPlayer\\" + pai + ".wav");
            sp.PlaySync();
            #endregion

            #region//ask
            if (humanPlayer_gameover == false)
            {
                //ask_humanPlayer_peng();
                //ask_humanPlayer_gang();
                ask_humanPlayer_hu();
            }
            if (rightAIPlayer_gameover == false)
            {
                //ask_rightAIPlayer_gang();
                //ask_rightAIPlayer_peng();
                //ask_rightAIPlayer_hu();
            }
            if (oppositeAIPlayer_gameover == false)
            {
                //ask_oppositeAIPlayer_peng();
                //ask_oppositeAIPlayer_gang();
                //ask_oppositeAIPlayer_hu();
            }
            #endregion

            leftAIPlayer_next();
        }

        public void remind_play()//长时间不出牌提醒
        {
            human_guo.BackColor = Color.Green;
            Thread.Sleep(500);
            human_guo.BackColor = Color.Transparent;
            if (humanPlayerdone == true)
            {
                sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\rightAIPlayer\\remind_play.wav");
                sp.PlaySync();
            }
            if (rightAIPlayerdone == true)
            {
                sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\oppositeAIPlayer\\remind_play.wav");
                sp.PlaySync();
            }
            if (oppositeAIPlayerdone == true)
            {
                sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\leftAIPlayer\\remind_play.wav");
                sp.PlaySync();
            }
            if (leftAIPlayerdone == true)
            {
                sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\humanPlayer\\remind_play.wav");
                sp.PlaySync();
            }
            //兵贵神速
            //soundplay
        }

        protected void ask_rightAIPlayer_peng()
        {

        }//问右手玩家碰杠胡过

        protected void ask_rightAIPlayer_gang()
        {

        }

        protected void ask_rightAIPlayer_hu()
        {
            if (true)//能胡
            {
                if (true)//胡
                {
                    intgameover++;
                    rightAIPlayer_gameover = true;//已胡
                    if (intgameover == 3)
                    {
                        gameover();//游戏结束
                    }
                    else
                    {
                        if (leftAIPlayerdone == true)//human玩家问胡的（上家）
                        {

                        }
                        if (rightAIPlayerdone == true)//opposite玩家问胡的（下家）
                        {
                            Thread to = new Thread(oppositeAIPlayer_chupai);
                            to.Start();
                            Thread.CurrentThread.Abort();
                        }
                        if (oppositeAIPlayerdone == true)//left玩家问胡的（下下家）
                        {
                            oppositeAIPlayerdone = false;
                            rightAIPlayerdone = true;
                            Thread to = new Thread(oppositeAIPlayer_chupai);
                            to.Start();
                            Thread tl = new Thread(leftAIPlayer_chupai);
                            tl.Start();
                            Thread.CurrentThread.Abort();
                        }
                    }
                }
                else//不胡
                {

                }
            }
        }

        protected void ask_oppositeAIPlayer_peng()
        {

        }//问对面玩家碰杠胡过

        protected void ask_oppositeAIPlayer_gang()
        {

        }

        protected void ask_oppositeAIPlayer_hu()
        {
            if (true)//能胡
            {
                if (true)//胡
                {
                    intgameover++;
                    oppositeAIPlayer_gameover = true;//已胡
                    if (intgameover == 3)
                    {
                        gameover();//游戏结束
                    }
                    else
                    {
                        if (leftAIPlayerdone == true)//human玩家问胡的（上上家）
                        {
                            rightAIPlayer_chupai_cancel = true;//rightAIPlayer出牌线程取消
                        }
                        if (humanPlayerdone == true)//right玩家问胡的（上家）
                        {

                        }
                        if (oppositeAIPlayerdone == true)//left玩家问胡的（下家）
                        {
                            Thread tl = new Thread(leftAIPlayer_chupai);
                            tl.Start();
                            Thread.CurrentThread.Abort();
                        }
                    }
                }
                else//不胡
                {

                }
            }
        }

        protected void ask_leftAIPlayer_peng()
        {

        }//问左手玩家碰杠胡过

        protected void ask_leftAIPlayer_gang()
        {

        }

        protected void ask_leftAIPlayer_hu()
        {
            if (true)//能胡
            {
                if (true)//胡
                {
                    intgameover++;
                    oppositeAIPlayer_gameover = true;//已胡
                    if (intgameover == 3)
                    {
                        gameover();//游戏结束
                    }
                    else
                    {
                        if (leftAIPlayerdone == true)//human玩家问胡的(下家）
                        {
                            Thread t = new Thread(human_play);
                            t.Start();
                            Thread.CurrentThread.Abort();
                        }
                        if (humanPlayerdone == true)//right玩家问胡的（上上家）
                        {
                            oppositeAIPlayer_chupai_cancel = true;//rightAIPlayer出牌线程取消
                        }
                        if (rightAIPlayerdone == true)//opposite玩家问胡的（上家）
                        {

                        }
                    }
                }
                else//不胡
                {

                }
            }
        }

        public void ask_humanPlayer_peng()
        {
            int i = 0;
            if (false)//能碰
            {
                human_peng.Enabled = true;
                human_guo.Enabled = true;
                for (i = 0; i < TIME_MAX; i++)//有bug，需改进
                {
                    Thread.Sleep(500);
                    if (human_peng.Name == "yes" || human_guo.Name == "yes")
                    {
                        break;
                    }
                    if (i % 10 == 0)//一段时间不点，提醒
                    {
                        remind_play();
                    }
                }
                if (i == TIME_MAX)//长时间不出即为过
                {
                    human_guo.Name = "yes";
                }

                if (human_peng.Name == "yes")
                {
                    //碰
                }
                else
                {
                    //不碰
                }
                human_peng.Name = "no";
                human_guo.Name = "no";
                human_peng.Enabled = false;
                human_guo.Enabled = false;
            }
        }//询问human玩家碰杠胡过

        public void ask_humanPlayer_gang()
        {
            int i = 0;
            if (false)//能杠
            {
                human_gang.Enabled = true;
                human_guo.Enabled = true;
                for (i = 0; i < TIME_MAX; i++)//有bug，需改进
                {
                    Thread.Sleep(500);
                    if (human_gang.Name == "yes" || human_guo.Name == "yes")
                    {
                        break;
                    }
                    if (i % 10 == 0)//一段时间不点，提醒
                    {
                        remind_play();
                    }
                }
                if (i == TIME_MAX)//长时间不出即为过
                {
                    human_guo.Name = "yes";
                }

                if (human_gang.Name == "yes")
                {
                    //杠
                }
                else
                {
                    //不杠
                }
                human_gang.Name = "no";
                human_guo.Name = "no";
                human_gang.Enabled = false;
                human_guo.Enabled = false;
            }
        }

        public void ask_humanPlayer_hu()
        {
            int i = 0;
            if (true)//能胡
            {
                human_hu.Enabled = true;
                human_guo.Enabled = true;
                for (i = 0; i < TIME_MAX; i++)//有bug，需改进
                {
                    Thread.Sleep(500);
                    if (human_hu.Name == "yes" || human_guo.Name == "yes")
                    {
                        break;
                    }
                    if (i % 10 == 0&&i>20)//一段时间不点，提醒
                    {
                        remind_play();
                    }
                }
                if (i == TIME_MAX)//长时间不出即为过
                {
                    human_guo.Name = "yes";
                }

                human_hu.Enabled = false;
                human_guo.Enabled = false;
                if (human_hu.Name == "yes")//胡
                {
                    intgameover++;
                    humanPlayer_gameover = true;
                    human_picturebox_enablef();
                    if (intgameover==3)
                    {
                        gameover();
                    }
                    else
                    {
                        for(i=0; ; i++)
                        {
                            #region//出牌
                            string pai = "t1";
                            Image picture_ro = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                            rightAIPlayer_havePlayedcard_num++;
                            switch (rightAIPlayer_havePlayedcard_num)
                            {
                                case 1:
                                    pictureBox_rightAIPlayer_havePlayedcard1.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard1.Image = picture_ro;
                                    break;
                                case 2:
                                    pictureBox_rightAIPlayer_havePlayedcard2.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard2.Image = picture_ro;
                                    break;
                                case 3:
                                    pictureBox_rightAIPlayer_havePlayedcard3.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard3.Image = picture_ro;
                                    break;
                                case 4:
                                    pictureBox_rightAIPlayer_havePlayedcard4.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard4.Image = picture_ro;
                                    break;
                                case 5:
                                    pictureBox_rightAIPlayer_havePlayedcard5.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard5.Image = picture_ro;
                                    break;
                                case 6:
                                    pictureBox_rightAIPlayer_havePlayedcard6.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard6.Image = picture_ro;
                                    break;
                                case 7:
                                    pictureBox_rightAIPlayer_havePlayedcard7.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard7.Image = picture_ro;
                                    break;
                                case 8:
                                    pictureBox_rightAIPlayer_havePlayedcard8.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard8.Image = picture_ro;
                                    break;
                                case 9:
                                    pictureBox_rightAIPlayer_havePlayedcard9.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard9.Image = picture_ro;
                                    break;
                                case 10:
                                    pictureBox_rightAIPlayer_havePlayedcard10.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard10.Image = picture_ro;
                                    break;
                                case 11:
                                    pictureBox_rightAIPlayer_havePlayedcard11.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard11.Image = picture_ro;
                                    break;
                                case 12:
                                    pictureBox_rightAIPlayer_havePlayedcard12.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard12.Image = picture_ro;
                                    break;
                                case 13:
                                    pictureBox_rightAIPlayer_havePlayedcard13.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard13.Image = picture_ro;
                                    break;
                                case 14:
                                    pictureBox_rightAIPlayer_havePlayedcard14.Name = pai;
                                    pictureBox_rightAIPlayer_havePlayedcard14.Image = picture_ro;
                                    break;
                                default:
                                    break;
                            }
                            sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\rightAIPlayer\\" + pai + ".wav");
                            sp.PlaySync();
                            #endregion

                            #region//ask需要重写
                            if (oppositeAIPlayer_gameover == false)
                            {
                                //ask_oppositeAIPlayer_gang();
                                //ask_oppositeAIPlayer_peng();
                                //ask_oppositeAIPlayer_hu();
                            }
                            if (leftAIPlayer_gameover == false)
                            {
                                //ask_leftAIPlayer_gang();
                                //ask_leftAIPlayer_peng();
                                //ask_leftAIPlayer_hu();
                            }
                            if (humanPlayer_gameover == false)
                            {
                                //ask_humanPlayer_peng();
                                //ask_humanPlayer_gang();
                                ask_humanPlayer_hu();
                            }
                            #endregion

                            #region//出牌
                            pai = "t1";
                            picture_ro = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                            picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            oppositeAIPlayer_havePlayedcard_num++;
                            switch (oppositeAIPlayer_havePlayedcard_num)
                            {
                                case 1:
                                    pictureBox_oppositeAIPlayer_havePlayedcard1.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard1.Image = picture_ro;
                                    break;
                                case 2:
                                    pictureBox_oppositeAIPlayer_havePlayedcard2.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard2.Image = picture_ro;
                                    break;
                                case 3:
                                    pictureBox_oppositeAIPlayer_havePlayedcard3.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard3.Image = picture_ro;
                                    break;
                                case 4:
                                    pictureBox_oppositeAIPlayer_havePlayedcard4.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard4.Image = picture_ro;
                                    break;
                                case 5:
                                    pictureBox_oppositeAIPlayer_havePlayedcard5.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard5.Image = picture_ro;
                                    break;
                                case 6:
                                    pictureBox_oppositeAIPlayer_havePlayedcard6.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard6.Image = picture_ro;
                                    break;
                                case 7:
                                    pictureBox_oppositeAIPlayer_havePlayedcard7.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard7.Image = picture_ro;
                                    break;
                                case 8:
                                    pictureBox_oppositeAIPlayer_havePlayedcard8.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard8.Image = picture_ro;
                                    break;
                                case 9:
                                    pictureBox_oppositeAIPlayer_havePlayedcard9.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard9.Image = picture_ro;
                                    break;
                                case 10:
                                    pictureBox_oppositeAIPlayer_havePlayedcard10.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard10.Image = picture_ro;
                                    break;
                                case 11:
                                    pictureBox_oppositeAIPlayer_havePlayedcard11.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard11.Image = picture_ro;
                                    break;
                                case 12:
                                    pictureBox_oppositeAIPlayer_havePlayedcard12.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard12.Image = picture_ro;
                                    break;
                                case 13:
                                    pictureBox_oppositeAIPlayer_havePlayedcard13.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard13.Image = picture_ro;
                                    break;
                                case 14:
                                    pictureBox_oppositeAIPlayer_havePlayedcard14.Name = pai;
                                    pictureBox_oppositeAIPlayer_havePlayedcard14.Image = picture_ro;
                                    break;
                                default:
                                    break;
                            }
                            sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\oppositeAIPlayer\\" + pai + ".wav");
                            sp.PlaySync();
                            #endregion

                            #region//ask
                            if (leftAIPlayer_gameover == false)
                            {
                                //ask_leftAIPlayer_gang();
                                //ask_leftAIPlayer_peng();
                                //ask_leftAIPlayer_hu();
                            }
                            if (humanPlayer_gameover == false)
                            {
                                //ask_humanPlayer_peng();
                                //ask_humanPlayer_gang();
                                ask_humanPlayer_hu();
                            }
                            if (rightAIPlayer_gameover == false)
                            {
                                //ask_rightAIPlayer_gang();
                                //ask_rightAIPlayer_peng();
                                //ask_rightAIPlayer_hu();
                            }
                            #endregion

                            #region//出牌
                            pai = "t1";
                            picture_ro = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                            picture_ro.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            leftAIPlayer_havePlayedcard_num++;
                            switch (leftAIPlayer_havePlayedcard_num)
                            {
                                case 1:
                                    pictureBox_leftAIPlayer_havePlayedcard1.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard1.Image = picture_ro;
                                    break;
                                case 2:
                                    pictureBox_leftAIPlayer_havePlayedcard2.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard2.Image = picture_ro;
                                    break;
                                case 3:
                                    pictureBox_leftAIPlayer_havePlayedcard3.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard3.Image = picture_ro;
                                    break;
                                case 4:
                                    pictureBox_leftAIPlayer_havePlayedcard4.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard4.Image = picture_ro;
                                    break;
                                case 5:
                                    pictureBox_leftAIPlayer_havePlayedcard5.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard5.Image = picture_ro;
                                    break;
                                case 6:
                                    pictureBox_leftAIPlayer_havePlayedcard6.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard6.Image = picture_ro;
                                    break;
                                case 7:
                                    pictureBox_leftAIPlayer_havePlayedcard7.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard7.Image = picture_ro;
                                    break;
                                case 8:
                                    pictureBox_leftAIPlayer_havePlayedcard8.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard8.Image = picture_ro;
                                    break;
                                case 9:
                                    pictureBox_leftAIPlayer_havePlayedcard9.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard9.Image = picture_ro;
                                    break;
                                case 10:
                                    pictureBox_leftAIPlayer_havePlayedcard10.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard10.Image = picture_ro;
                                    break;
                                case 11:
                                    pictureBox_leftAIPlayer_havePlayedcard11.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard11.Image = picture_ro;
                                    break;
                                case 12:
                                    pictureBox_leftAIPlayer_havePlayedcard12.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard12.Image = picture_ro;
                                    break;
                                case 13:
                                    pictureBox_leftAIPlayer_havePlayedcard13.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard13.Image = picture_ro;
                                    break;
                                case 14:
                                    pictureBox_leftAIPlayer_havePlayedcard14.Name = pai;
                                    pictureBox_leftAIPlayer_havePlayedcard14.Image = picture_ro;
                                    break;
                                default:
                                    break;
                            }
                            sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\leftAIPlayer\\" + pai + ".wav");
                            sp.PlaySync();
                            #endregion

                            #region//ask
                            if (humanPlayer_gameover == false)
                            {
                                //ask_humanPlayer_peng();
                                //ask_humanPlayer_gang();
                                ask_humanPlayer_hu();
                            }
                            if (rightAIPlayer_gameover == false)
                            {
                                //ask_rightAIPlayer_gang();
                                //ask_rightAIPlayer_peng();
                                //ask_rightAIPlayer_hu();
                            }
                            if (oppositeAIPlayer_gameover == false)
                            {
                                //ask_oppositeAIPlayer_peng();
                                //ask_oppositeAIPlayer_gang();
                                //ask_oppositeAIPlayer_hu();
                            }
                            #endregion
                        }
                    }             
                }
                else
                {
                    //不胡
                }
                human_hu.Name = "no";
                human_guo.Name = "no";
            }
        }

        protected bool my_compare(string pb1, string pb2)//比较pb1和pb2，如果pb1>pb2，return true,小于等于return false                 
        {
            if (pb1 == "blank")
            {
                return true;
            }
            else
            {
                if (pb2 == "blank")
                {
                    return false;
                }
                else if (pb1.CompareTo(pb2) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void my_show()//整理手牌并显示图片
        {
            string pb;
            for (int i = 1; i < 14; i++)
            {
                for (int j = 1; j <= 14 - i; j++)
                {
                    switch (j)
                    {
                        case 1:
                            if (my_compare(pictureBox_humanPlayer_card1.Name, pictureBox_humanPlayer_card2.Name))
                            {
                                pb = pictureBox_humanPlayer_card1.Name;
                                pictureBox_humanPlayer_card1.Name = pictureBox_humanPlayer_card2.Name;
                                pictureBox_humanPlayer_card2.Name = pb;
                            }
                            break;
                        case 2:
                            if (my_compare(pictureBox_humanPlayer_card2.Name, pictureBox_humanPlayer_card3.Name))
                            {
                                pb = pictureBox_humanPlayer_card2.Name;
                                pictureBox_humanPlayer_card2.Name = pictureBox_humanPlayer_card3.Name;
                                pictureBox_humanPlayer_card3.Name = pb;
                            }
                            break;
                        case 3:
                            if (my_compare(pictureBox_humanPlayer_card3.Name, pictureBox_humanPlayer_card4.Name))
                            {
                                pb = pictureBox_humanPlayer_card3.Name;
                                pictureBox_humanPlayer_card3.Name = pictureBox_humanPlayer_card4.Name;
                                pictureBox_humanPlayer_card4.Name = pb;
                            }
                            break;
                        case 4:
                            if (my_compare(pictureBox_humanPlayer_card4.Name, pictureBox_humanPlayer_card5.Name))
                            {
                                pb = pictureBox_humanPlayer_card4.Name;
                                pictureBox_humanPlayer_card4.Name = pictureBox_humanPlayer_card5.Name;
                                pictureBox_humanPlayer_card5.Name = pb;
                            }
                            break;
                        case 5:
                            if (my_compare(pictureBox_humanPlayer_card5.Name, pictureBox_humanPlayer_card6.Name))
                            {
                                pb = pictureBox_humanPlayer_card5.Name;
                                pictureBox_humanPlayer_card5.Name = pictureBox_humanPlayer_card6.Name;
                                pictureBox_humanPlayer_card6.Name = pb;
                            }
                            break;
                        case 6:
                            if (my_compare(pictureBox_humanPlayer_card6.Name, pictureBox_humanPlayer_card7.Name))
                            {
                                pb = pictureBox_humanPlayer_card6.Name;
                                pictureBox_humanPlayer_card6.Name = pictureBox_humanPlayer_card7.Name;
                                pictureBox_humanPlayer_card7.Name = pb;
                            }
                            break;
                        case 7:
                            if (my_compare(pictureBox_humanPlayer_card7.Name, pictureBox_humanPlayer_card8.Name))
                            {
                                pb = pictureBox_humanPlayer_card7.Name;
                                pictureBox_humanPlayer_card7.Name = pictureBox_humanPlayer_card8.Name;
                                pictureBox_humanPlayer_card8.Name = pb;
                            }
                            break;
                        case 8:
                            if (my_compare(pictureBox_humanPlayer_card8.Name, pictureBox_humanPlayer_card9.Name))
                            {
                                pb = pictureBox_humanPlayer_card8.Name;
                                pictureBox_humanPlayer_card8.Name = pictureBox_humanPlayer_card9.Name;
                                pictureBox_humanPlayer_card9.Name = pb;
                            }
                            break;
                        case 9:
                            if (my_compare(pictureBox_humanPlayer_card9.Name, pictureBox_humanPlayer_card10.Name))
                            {
                                pb = pictureBox_humanPlayer_card9.Name;
                                pictureBox_humanPlayer_card9.Name = pictureBox_humanPlayer_card10.Name;
                                pictureBox_humanPlayer_card10.Name = pb;
                            }
                            break;
                        case 10:
                            if (my_compare(pictureBox_humanPlayer_card10.Name, pictureBox_humanPlayer_card11.Name))
                            {
                                pb = pictureBox_humanPlayer_card10.Name;
                                pictureBox_humanPlayer_card10.Name = pictureBox_humanPlayer_card11.Name;
                                pictureBox_humanPlayer_card11.Name = pb;
                            }
                            break;
                        case 11:
                            if (my_compare(pictureBox_humanPlayer_card11.Name, pictureBox_humanPlayer_card12.Name))
                            {
                                pb = pictureBox_humanPlayer_card11.Name;
                                pictureBox_humanPlayer_card11.Name = pictureBox_humanPlayer_card12.Name;
                                pictureBox_humanPlayer_card12.Name = pb;
                            }
                            break;
                        case 12:
                            if (my_compare(pictureBox_humanPlayer_card12.Name, pictureBox_humanPlayer_card13.Name))
                            {
                                pb = pictureBox_humanPlayer_card12.Name;
                                pictureBox_humanPlayer_card12.Name = pictureBox_humanPlayer_card13.Name;
                                pictureBox_humanPlayer_card13.Name = pb;
                            }
                            break;
                        case 13:
                            if (my_compare(pictureBox_humanPlayer_card13.Name, pictureBox_humanPlayer_card14.Name))
                            {
                                pb = pictureBox_humanPlayer_card13.Name;
                                pictureBox_humanPlayer_card13.Name = pictureBox_humanPlayer_card14.Name;
                                pictureBox_humanPlayer_card14.Name = pb;
                            }
                            break;
                    }
                }
            }

            pictureBox_humanPlayer_card1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card1.Name + ".jpg");
            pictureBox_humanPlayer_card2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card2.Name + ".jpg");
            pictureBox_humanPlayer_card3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card3.Name + ".jpg");
            pictureBox_humanPlayer_card4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card4.Name + ".jpg");
            pictureBox_humanPlayer_card5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card5.Name + ".jpg");
            pictureBox_humanPlayer_card6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card6.Name + ".jpg");
            pictureBox_humanPlayer_card7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card7.Name + ".jpg");
            pictureBox_humanPlayer_card8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card8.Name + ".jpg");
            pictureBox_humanPlayer_card9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card9.Name + ".jpg");
            pictureBox_humanPlayer_card10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card10.Name + ".jpg");
            pictureBox_humanPlayer_card11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card11.Name + ".jpg");
            pictureBox_humanPlayer_card12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card12.Name + ".jpg");
            pictureBox_humanPlayer_card13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card13.Name + ".jpg");
            pictureBox_humanPlayer_card14.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pictureBox_humanPlayer_card14.Name + ".jpg");
        }

        public Form1()//初始化
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//忽略跨线程错误
            my_initialize();//自定义的初始化内容   
            mediaplayer_backgroundmusic.URL="C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\backgroundmusic.wav";
            mediaplayer_backgroundmusic.Ctlcontrols.play();
            mediaplayer_backgroundmusic.settings.setMode("loop", true);
        }

        private void pictureBox_humanPlayer_card_Click(object sender, EventArgs e)//点击picturebox事件
        {
            PictureBox pb = (PictureBox)sender;
            humanPlayer_chupai(pb.Name);
            pb.Name = "blank";
            my_show();
            human_picturebox_enablef();

            Thread tr = new Thread(rightAIPlayer_chupai);
            tr.Start();

            Thread to = new Thread(oppositeAIPlayer_chupai);
            to.Start();

            Thread tl = new Thread(leftAIPlayer_chupai);
            tl.Start();

            Thread t = new Thread(human_play);
            t.Start();
        }

        private void game_start_Click(object sender, EventArgs e)//点击start事件
        {
            game_start.Visible = false;

            whostart();
            #region//根据谁开始初始化
            if (rightAIPlayer_start == true)
            {
                humanPlayerdone = true;
                rightAIPlayerdone = false;
                oppositeAIPlayerdone = false;
                leftAIPlayerdone = false;

                rightAIPlayer_havePlayedcard_num++;
                ThreadPool.QueueUserWorkItem(new WaitCallback(rightAIPlayer_chupai));

                oppositeAIPlayer_havePlayedcard_num++;
                ThreadPool.QueueUserWorkItem(new WaitCallback(oppositeAIPlayer_chupai));

                leftAIPlayer_havePlayedcard_num++;
                ThreadPool.QueueUserWorkItem(new WaitCallback(leftAIPlayer_chupai));
            }
            else
            {
                if (oppositeAIPlayer_start == true)
                {
                    humanPlayerdone = false;
                    rightAIPlayerdone = true;
                    oppositeAIPlayerdone = false;
                    leftAIPlayerdone = false;

                    oppositeAIPlayer_havePlayedcard_num++;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(oppositeAIPlayer_chupai));

                    leftAIPlayer_havePlayedcard_num++;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(leftAIPlayer_chupai));
                }
                else
                {
                    if (leftAIPlayer_start == true)
                    {
                        humanPlayerdone = false;
                        rightAIPlayerdone = false;
                        oppositeAIPlayerdone = true;
                        leftAIPlayerdone = false;

                        leftAIPlayer_havePlayedcard_num++;
                        ThreadPool.QueueUserWorkItem(new WaitCallback(leftAIPlayer_chupai));
                    }
                    else
                    {
                        if (humanPlayer_start == true)
                        {
                            humanPlayerdone = false;
                            rightAIPlayerdone = false;
                            oppositeAIPlayerdone = false;
                            leftAIPlayerdone = true;
                        }
                    }
                }
            }
            #endregion
            fapai();
            my_show();
            Thread.Sleep(500);

            //ThreadPool.QueueUserWorkItem(new WaitCallback(human_play));//这里不用线程池，卡住的情况未出现
            Thread t = new Thread(human_play);
            t.Start();
        }

        private void human_ask_Click(object sender, EventArgs e)//判断是碰杠胡过
        {
            Button button = (Button)sender;
            button.Name = "yes";
        }

        private void human_picturebox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Location = new Point(pb.Location.X - D_X, pb.Location.Y - D_Y);
            pb.Size = new Size(pb.Width + D_WIDTH, pb.Height + D_HEIGHT);
        }

        private void human_picturebox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Location = new Point(pb.Location.X + D_X, pb.Location.Y + D_Y);
            pb.Size = new Size(pb.Width - D_WIDTH, pb.Height - D_HEIGHT);
        }

        private void human_ask_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Location = new Point(button.Location.X - D_X, button.Location.Y - D_Y);
            button.Size = new Size(button.Width + D_WIDTH, button.Height + D_HEIGHT);
        }

        private void human_ask_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Location = new Point(button.Location.X + D_X, button.Location.Y + D_Y);
            button.Size = new Size(button.Width - D_WIDTH, button.Height - D_HEIGHT);
        }
    }
}