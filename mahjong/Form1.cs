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

namespace mahjong
{
    public partial class Form1 : Form
    {
        int humanPlayer_havePlayedcard_num = 0;//玩家已出牌计数
        int leftAIPlayer_havePlayedcard_num = 0;
        int rightAIPlayer_havePlayedcard_num = 0;
        int oppositeAIPlayer_havePlayedcard_num = 0;
        public bool humanPlayer_start = false;//从哪位玩家开始
        bool rightAIPlayer_start = false;
        bool oppositeAIPlayer_start = false;
        bool leftAIPlayer_start = false;

        private SoundPlayer sp;

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

        public void whostart()//从哪个玩家开始
        {
            humanPlayer_start = true;
        }

        public void fapai()//发牌程序
        {
            pictureBox_humanPlayer_card1.Name = "t1";
            pictureBox_humanPlayer_card2.Name = "t1";
            pictureBox_humanPlayer_card3.Name = "t1";
            pictureBox_humanPlayer_card4.Name = "t1";
            pictureBox_humanPlayer_card5.Name = "t1";
            pictureBox_humanPlayer_card6.Name = "t1";
            pictureBox_humanPlayer_card7.Name = "t1";
            pictureBox_humanPlayer_card8.Name = "t1";
            pictureBox_humanPlayer_card9.Name = "t1";
            pictureBox_humanPlayer_card10.Name = "t1";
            pictureBox_humanPlayer_card11.Name = "t1";
            pictureBox_humanPlayer_card12.Name = "t1";
            pictureBox_humanPlayer_card13.Name = "t1";
            pictureBox_humanPlayer_card14.Name = "blank";
        }

        public void my_initialize()//自定义初始化内容
        {
            humanPlayer_start = false;
            rightAIPlayer_start = false;
            oppositeAIPlayer_start = false;
            leftAIPlayer_start = false;

            game_start.Visible = true;

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

        public void human_mopai()//摸牌程序
        {
            pictureBox_humanPlayer_card14.Name = "w1";
        }

        public void humanPlayer_chupai(string pai ,int N)//出牌程序
        {
            switch (N)
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
            //sp=new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\" + pai + ".wav");
            //sp.PlaySync();
        }

        public void rightAIPlayer_chupai(string pai, int N)
        {
            switch (N)
            {
                case 1:
                    pictureBox_rightAIPlayer_havePlayedcard1.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 2:
                    pictureBox_rightAIPlayer_havePlayedcard2.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 3:
                    pictureBox_rightAIPlayer_havePlayedcard3.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 4:
                    pictureBox_rightAIPlayer_havePlayedcard4.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 5:
                    pictureBox_rightAIPlayer_havePlayedcard5.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 6:
                    pictureBox_rightAIPlayer_havePlayedcard6.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 7:
                    pictureBox_rightAIPlayer_havePlayedcard7.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 8:
                    pictureBox_rightAIPlayer_havePlayedcard8.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 9:
                    pictureBox_rightAIPlayer_havePlayedcard9.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 10:
                    pictureBox_rightAIPlayer_havePlayedcard10.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 11:
                    pictureBox_rightAIPlayer_havePlayedcard11.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 12:
                    pictureBox_rightAIPlayer_havePlayedcard12.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 13:
                    pictureBox_rightAIPlayer_havePlayedcard13.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 14:
                    pictureBox_rightAIPlayer_havePlayedcard14.Name = pai;
                    pictureBox_rightAIPlayer_havePlayedcard14.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                default:
                    break;
            }
            //sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\" + pai + ".wav");
            //sp.PlaySync();
            ask();
        }

        public void oppositeAIPlayer_chupai(string pai, int N)
        {
            switch (N)
            {
                case 1:
                    pictureBox_oppositeAIPlayer_havePlayedcard1.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 2:
                    pictureBox_oppositeAIPlayer_havePlayedcard2.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 3:
                    pictureBox_oppositeAIPlayer_havePlayedcard3.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 4:
                    pictureBox_oppositeAIPlayer_havePlayedcard4.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 5:
                    pictureBox_oppositeAIPlayer_havePlayedcard5.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 6:
                    pictureBox_oppositeAIPlayer_havePlayedcard6.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 7:
                    pictureBox_oppositeAIPlayer_havePlayedcard7.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 8:
                    pictureBox_oppositeAIPlayer_havePlayedcard8.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 9:
                    pictureBox_oppositeAIPlayer_havePlayedcard9.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 10:
                    pictureBox_oppositeAIPlayer_havePlayedcard10.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 11:
                    pictureBox_oppositeAIPlayer_havePlayedcard11.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 12:
                    pictureBox_oppositeAIPlayer_havePlayedcard12.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 13:
                    pictureBox_oppositeAIPlayer_havePlayedcard13.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 14:
                    pictureBox_oppositeAIPlayer_havePlayedcard14.Name = pai;
                    pictureBox_oppositeAIPlayer_havePlayedcard14.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                default:
                    break;
            }
            //sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\" + pai + ".wav");
            //sp.PlaySync();
            ask();
        }

        public void leftAIPlayer_chupai(string pai, int N)
        {
            switch (N)
            {
                case 1:
                    pictureBox_leftAIPlayer_havePlayedcard1.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard1.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 2:
                    pictureBox_leftAIPlayer_havePlayedcard2.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard2.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 3:
                    pictureBox_leftAIPlayer_havePlayedcard3.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard3.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 4:
                    pictureBox_leftAIPlayer_havePlayedcard4.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard4.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 5:
                    pictureBox_leftAIPlayer_havePlayedcard5.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard5.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 6:
                    pictureBox_leftAIPlayer_havePlayedcard6.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard6.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 7:
                    pictureBox_leftAIPlayer_havePlayedcard7.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard7.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 8:
                    pictureBox_leftAIPlayer_havePlayedcard8.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard8.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 9:
                    pictureBox_leftAIPlayer_havePlayedcard9.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard9.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 10:
                    pictureBox_leftAIPlayer_havePlayedcard10.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard10.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 11:
                    pictureBox_leftAIPlayer_havePlayedcard11.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard11.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 12:
                    pictureBox_leftAIPlayer_havePlayedcard12.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard12.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 13:
                    pictureBox_leftAIPlayer_havePlayedcard13.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard13.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                case 14:
                    pictureBox_leftAIPlayer_havePlayedcard14.Name = pai;
                    pictureBox_leftAIPlayer_havePlayedcard14.Image = Image.FromFile("C:\\Users\\lenovo\\Desktop\\mahjong\\picture\\" + pai + ".jpg");
                    break;
                default:
                    break;
            }
            //sp = new SoundPlayer("C:\\Users\\lenovo\\Desktop\\mahjong\\sound\\" + pai + ".wav");
            //sp.PlaySync();
            ask();
        }

        public void ask()//询问是否碰，杠
        {
            if (true)//碰
            {
                if (MessageBox.Show("是否碰","",MessageBoxButtons.OKCancel)==DialogResult.OK)
                {
                    //碰
                }
                else
                {
                    //不碰
                }
            }
            else
            {
                if (MessageBox.Show("是否杠", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //杠
                }
                else
                {
                    //不杠
                }
            }
        }

        public void hupai()//判断是否和牌
        {
            if (MessageBox.Show("是否和牌","", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //计算倍率
                if (true)//如果赢
                {
                    MessageBox.Show("you win","",MessageBoxButtons.OK);
                }
                else//输
                {
                    MessageBox.Show("you lose", "", MessageBoxButtons.OK);
                }
                if(MessageBox.Show("是否重新开始游戏", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //初始化
                    my_initialize();                
                }
                else
                {
                    Application.Exit();//退出游戏
                }

                /*Form1_1 child1 = new Form1_1();
                child1.MdiParent = this;
                child1.Text = "是否和牌";
                child1.ShowDialog();*/     
            }
            else
            {
                //不和牌
            }
        }

        public void my_show()//整理手牌并显示图片
        {
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
            my_initialize();//自定义的初始化内容           
        }

        private void pictureBox_humanPlayer_card_Click(object sender, EventArgs e)//点击picturebox事件
        {
            PictureBox pb = (PictureBox)sender;
            humanPlayer_havePlayedcard_num++;
            humanPlayer_chupai(pb.Name, humanPlayer_havePlayedcard_num);
            pb.Name = "blank";
            my_show();
            Thread.Sleep(500);

            rightAIPlayer_havePlayedcard_num++;
            rightAIPlayer_chupai("t1", rightAIPlayer_havePlayedcard_num);

            oppositeAIPlayer_havePlayedcard_num++;
            oppositeAIPlayer_chupai("t1", oppositeAIPlayer_havePlayedcard_num);

            leftAIPlayer_havePlayedcard_num++;
            leftAIPlayer_chupai("t1", leftAIPlayer_havePlayedcard_num);

            Thread.Sleep(200);
            Thread.Sleep(200);
            human_mopai();
            my_show();
            hupai();
        }

        private void game_start_Click(object sender, EventArgs e)//点击start事件
        {
            game_start.Visible = false;
            pictureBox_humanPlayer_card1.Enabled = true;//start之后可响应
            pictureBox_humanPlayer_card2.Enabled = true;
            pictureBox_humanPlayer_card3.Enabled = true;
            pictureBox_humanPlayer_card4.Enabled = true;
            pictureBox_humanPlayer_card5.Enabled = true;
            pictureBox_humanPlayer_card6.Enabled = true;
            pictureBox_humanPlayer_card7.Enabled = true;
            pictureBox_humanPlayer_card8.Enabled = true;
            pictureBox_humanPlayer_card9.Enabled = true;
            pictureBox_humanPlayer_card10.Enabled = true;
            pictureBox_humanPlayer_card12.Enabled = true;
            pictureBox_humanPlayer_card13.Enabled = true;
            pictureBox_humanPlayer_card14.Enabled = true;

            whostart();
            fapai();
            my_show();
            Thread.Sleep(200);
            if (rightAIPlayer_start == true)
            {
                rightAIPlayer_havePlayedcard_num++;
                rightAIPlayer_chupai("t1", rightAIPlayer_havePlayedcard_num);

                oppositeAIPlayer_havePlayedcard_num++;
                oppositeAIPlayer_chupai("t1", oppositeAIPlayer_havePlayedcard_num);

                leftAIPlayer_havePlayedcard_num++;
                leftAIPlayer_chupai("t1", leftAIPlayer_havePlayedcard_num);
            }
            else
            {
                if (oppositeAIPlayer_start == true)
                {
                    oppositeAIPlayer_havePlayedcard_num++;
                    oppositeAIPlayer_chupai("t1", oppositeAIPlayer_havePlayedcard_num);

                    leftAIPlayer_havePlayedcard_num++;
                    leftAIPlayer_chupai("t1", leftAIPlayer_havePlayedcard_num);
                }
                else
                {
                    if (leftAIPlayer_start == true)
                    {
                        leftAIPlayer_havePlayedcard_num++;
                        leftAIPlayer_chupai("t1", leftAIPlayer_havePlayedcard_num);
                    }
                    else
                    {
                        if (humanPlayer_start == true)
                        {
                            //
                        }
                    }
                }
            }
            human_mopai();
            my_show();
            hupai();
        }
    }
}
