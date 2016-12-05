﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using ManageClass;
/// <summary>
///提醒时间可调
///又能碰又能杠怎么破
///switch超过14有错
/// </summary>
namespace mahjong
{
    public partial class Form1 : Form
    {
        #region//变量定义    
        CTABLE table = new CTABLE();
        CAI right_ai = new CAI(2);
        CAI opposite_ai = new CAI(3);
        CAI left_ai = new CAI(4);
        protected SoundPlayer sp;
        protected static int TIME_MAX = 100;

        System.Timers.Timer timer = new System.Timers.Timer(10);
        protected Point target_point = new Point(0, 0);//目标点
        protected Point initial_point = new Point(0, 0);

        private AutoResetEvent humanPlayer_movedone = new AutoResetEvent(false);
        private AutoResetEvent rightAIPlayer_movedone = new AutoResetEvent(false);
        private AutoResetEvent oppositeAIPlayer_movedone = new AutoResetEvent(false);
        private AutoResetEvent leftAIPlayer_movedone = new AutoResetEvent(false);

        protected bool rightAIPlayer_peng = false;//暂定不初始化
        protected bool rightAIPlayer_gang = false;
        protected bool leftAIPlayer_peng = false;
        protected bool leftAIPlayer_gang = false;
        protected bool oppositeAIPlayer_peng = false;
        protected bool oppositeAIPlayer_gang = false;

        protected bool game_goon = true;//是否向下进行

        protected bool humanPlayer_cancel = false;
        protected bool rightAIPlayer_cancel = false;
        protected bool oppositeAIPlayer_cancel = false;
        protected bool leftAIPlayer_cancel = false;

        protected bool card_haveused = false;//当前牌用过了没有

        protected static int D_X = 2;//location.x的改变
        protected static int D_Y = 6;//location.y的改变
        protected static int D_WIDTH = 4;//width的改变
        protected static int D_HEIGHT = 6;//height的改变 不用初始化的变量      

        protected int D_MOVE_X = 1;
        protected int D_MOVE_Y = 1;

        protected string current_card = "blank";
        protected bool humanPlayer_gameover = false;
        protected bool rightAIPlayer_gameover = false;
        protected bool oppositeAIPlayer_gameover = false;
        protected bool leftAIPlayer_gameover = false;
        protected int intgameover = 0;//gameover=3时游戏结束，三个人胡了

        protected bool humanPlayerdone = false;
        protected bool rightAIPlayerdone = false;
        protected bool oppositeAIPlayerdone = false;
        protected bool leftAIPlayerdone = false;

        int humanPlayer_havePlayedcard_num = 0;//玩家已出牌计数
        int humanPlayer_haveshowedcard_num = 0;//已碰/杠牌计数
        int leftAIPlayer_havePlayedcard_num = 0;
        int leftAIPlayer_haveshowedcard_num = 0;
        int rightAIPlayer_havePlayedcard_num = 0;
        int rightAIPlayer_haveshowedcard_num = 0;
        int oppositeAIPlayer_havePlayedcard_num = 0;
        int oppositeAIPlayer_haveshowedcard_num = 0;

        protected bool humanPlayer_start = false;//从哪位玩家开始
        bool rightAIPlayer_start = false;
        bool oppositeAIPlayer_start = false;
        bool leftAIPlayer_start = false;
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

        #region//系统函数
        /*protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }*/

        protected PictureBox humanPlayer_switch()//超过14有错
        {
            #region//switch
            switch (humanPlayer_havePlayedcard_num)
            {
                case 1:
                    return pictureBox_humanPlayer_havePlayedcard1;
                case 2:
                    return pictureBox_humanPlayer_havePlayedcard2;
                case 3:
                    return pictureBox_humanPlayer_havePlayedcard3;
                case 4:
                    return pictureBox_humanPlayer_havePlayedcard4;
                case 5:
                    return pictureBox_humanPlayer_havePlayedcard5;
                case 6:
                    return pictureBox_humanPlayer_havePlayedcard6;
                case 7:
                    return pictureBox_humanPlayer_havePlayedcard7;
                case 8:
                    return pictureBox_humanPlayer_havePlayedcard8;
                case 9:
                    return pictureBox_humanPlayer_havePlayedcard9;
                case 10:
                    return pictureBox_humanPlayer_havePlayedcard10;
                case 11:
                    return pictureBox_humanPlayer_havePlayedcard11;
                case 12:
                    return pictureBox_humanPlayer_havePlayedcard12;
                case 13:
                    return pictureBox_humanPlayer_havePlayedcard13;
                case 14:
                    return pictureBox_humanPlayer_havePlayedcard14;
                default:
                    return pictureBox_human_move;
            }
            #endregion
        }

        protected PictureBox rightAIPlayer_switch()//超过14有错
        {
            #region//switch
            switch (rightAIPlayer_havePlayedcard_num)
            {
                case 1:
                    return pictureBox_rightAIPlayer_havePlayedcard1;
                case 2:
                    return pictureBox_rightAIPlayer_havePlayedcard2;
                case 3:
                    return pictureBox_rightAIPlayer_havePlayedcard3;
                case 4:
                    return pictureBox_rightAIPlayer_havePlayedcard4;
                case 5:
                    return pictureBox_rightAIPlayer_havePlayedcard5;
                case 6:
                    return pictureBox_rightAIPlayer_havePlayedcard6;
                case 7:
                    return pictureBox_rightAIPlayer_havePlayedcard7;
                case 8:
                    return pictureBox_rightAIPlayer_havePlayedcard8;
                case 9:
                    return pictureBox_rightAIPlayer_havePlayedcard9;
                case 10:
                    return pictureBox_rightAIPlayer_havePlayedcard10;
                case 11:
                    return pictureBox_rightAIPlayer_havePlayedcard11;
                case 12:
                    return pictureBox_rightAIPlayer_havePlayedcard12;
                case 13:
                    return pictureBox_rightAIPlayer_havePlayedcard13;
                case 14:
                    return pictureBox_rightAIPlayer_havePlayedcard14;
                default:
                    return pictureBox_human_move;
            }
            #endregion
        }

        protected PictureBox rightAIPlayer_haveshowedcard_switch()
        {
            switch (rightAIPlayer_haveshowedcard_num)
            {
                case 1:
                    return pictureBox_rightAIPlayer_card1;
                case 2:
                    return pictureBox_rightAIPlayer_card2;
                case 3:
                    return pictureBox_rightAIPlayer_card3;
                case 4:
                    return pictureBox_rightAIPlayer_card4;
                case 5:
                    return pictureBox_rightAIPlayer_card5;
                case 6:
                    return pictureBox_rightAIPlayer_card6;
                case 7:
                    return pictureBox_rightAIPlayer_card7;
                case 8:
                    return pictureBox_rightAIPlayer_card8;
                case 9:
                    return pictureBox_oppositeAIPlayer_card9;
                case 10:
                    return pictureBox_rightAIPlayer_card10;
                case 11:
                    return pictureBox_rightAIPlayer_card11;
                case 12:
                    return pictureBox_rightAIPlayer_card12;
                case 13:
                    return pictureBox_rightAIPlayer_card13;
                default:
                    return pictureBox_human_move;
            }
        }

        protected PictureBox oppositeAIPlayer_switch()//超过14有错
        {
            #region//switch
            switch (oppositeAIPlayer_havePlayedcard_num)
            {
                case 1:
                    return pictureBox_oppositeAIPlayer_havePlayedcard1;
                case 2:
                    return pictureBox_oppositeAIPlayer_havePlayedcard2;
                case 3:
                    return pictureBox_oppositeAIPlayer_havePlayedcard3;
                case 4:
                    return pictureBox_oppositeAIPlayer_havePlayedcard4;
                case 5:
                    return pictureBox_oppositeAIPlayer_havePlayedcard5;
                case 6:
                    return pictureBox_oppositeAIPlayer_havePlayedcard6;
                case 7:
                    return pictureBox_oppositeAIPlayer_havePlayedcard7;
                case 8:
                    return pictureBox_oppositeAIPlayer_havePlayedcard8;
                case 9:
                    return pictureBox_oppositeAIPlayer_havePlayedcard9;
                case 10:
                    return pictureBox_oppositeAIPlayer_havePlayedcard10;
                case 11:
                    return pictureBox_oppositeAIPlayer_havePlayedcard11;
                case 12:
                    return pictureBox_oppositeAIPlayer_havePlayedcard12;
                case 13:
                    return pictureBox_oppositeAIPlayer_havePlayedcard13;
                case 14:
                    return pictureBox_oppositeAIPlayer_havePlayedcard14;
                default:
                    return pictureBox_human_move;
            }
            #endregion
        }

        protected PictureBox oppositeAIPlayer_haveshowedcard_switch()
        {
            switch (oppositeAIPlayer_haveshowedcard_num)
            {
                case 1:
                    return pictureBox_oppositeAIPlayer_card1;
                case 2:
                    return pictureBox_oppositeAIPlayer_card2;
                case 3:
                    return pictureBox_oppositeAIPlayer_card3;
                case 4:
                    return pictureBox_oppositeAIPlayer_card4;
                case 5:
                    return pictureBox_oppositeAIPlayer_card5;
                case 6:
                    return pictureBox_oppositeAIPlayer_card6;
                case 7:
                    return pictureBox_oppositeAIPlayer_card7;
                case 8:
                    return pictureBox_oppositeAIPlayer_card8;
                case 9:
                    return pictureBox_oppositeAIPlayer_card9;
                case 10:
                    return pictureBox_oppositeAIPlayer_card10;
                case 11:
                    return pictureBox_oppositeAIPlayer_card11;
                case 12:
                    return pictureBox_oppositeAIPlayer_card12;
                case 13:
                    return pictureBox_oppositeAIPlayer_card13;
                default:
                    return pictureBox_human_move;
            }
        }

        protected PictureBox leftAIPlayer_switch()//超过14有错
        {
            #region//switch
            switch (leftAIPlayer_havePlayedcard_num)
            {
                case 1:
                    return pictureBox_leftAIPlayer_havePlayedcard1;
                case 2:
                    return pictureBox_leftAIPlayer_havePlayedcard2;
                case 3:
                    return pictureBox_leftAIPlayer_havePlayedcard3;
                case 4:
                    return pictureBox_leftAIPlayer_havePlayedcard4;
                case 5:
                    return pictureBox_leftAIPlayer_havePlayedcard5;
                case 6:
                    return pictureBox_leftAIPlayer_havePlayedcard6;
                case 7:
                    return pictureBox_leftAIPlayer_havePlayedcard7;
                case 8:
                    return pictureBox_leftAIPlayer_havePlayedcard8;
                case 9:
                    return pictureBox_leftAIPlayer_havePlayedcard9;
                case 10:
                    return pictureBox_leftAIPlayer_havePlayedcard10;
                case 11:
                    return pictureBox_leftAIPlayer_havePlayedcard11;
                case 12:
                    return pictureBox_leftAIPlayer_havePlayedcard12;
                case 13:
                    return pictureBox_leftAIPlayer_havePlayedcard13;
                case 14:
                    return pictureBox_leftAIPlayer_havePlayedcard14;
                default:
                    return pictureBox_human_move;
            }
            #endregion
        }

        protected PictureBox leftAIPlayer_haveshowedcard_switch()
        {
            switch (leftAIPlayer_haveshowedcard_num)
            {
                case 1:
                    return pictureBox_leftAIPlayer_card1;
                case 2:
                    return pictureBox_leftAIPlayer_card2;
                case 3:
                    return pictureBox_leftAIPlayer_card3;
                case 4:
                    return pictureBox_leftAIPlayer_card4;
                case 5:
                    return pictureBox_leftAIPlayer_card5;
                case 6:
                    return pictureBox_leftAIPlayer_card6;
                case 7:
                    return pictureBox_leftAIPlayer_card7;
                case 8:
                    return pictureBox_leftAIPlayer_card8;
                case 9:
                    return pictureBox_leftAIPlayer_card9;
                case 10:
                    return pictureBox_leftAIPlayer_card10;
                case 11:
                    return pictureBox_leftAIPlayer_card11;
                case 12:
                    return pictureBox_leftAIPlayer_card12;
                case 13:
                    return pictureBox_leftAIPlayer_card13;
                default:
                    return pictureBox_human_move;
            }
        }

        protected void whostart()//从哪个玩家开始
        {
            humanPlayer_start = true;
        }

        protected void AI_mopai()
        {
            right_ai.respond_table(table.Deal(1));
            opposite_ai.respond_table(table.Deal(2));
            left_ai.respond_table(table.Deal(3));
        }

        protected void fapai()//发牌程序
        {
            pictureBox_humanPlayer_card1.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card2.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card3.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card4.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card5.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card6.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card7.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card8.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card9.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card10.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card11.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card12.Name = table.Deal(0).Substring(1, 2);
            AI_mopai();
            pictureBox_humanPlayer_card13.Name = table.Deal(0).Substring(1, 2);
            string str;
            str = table.Deal(1);
            str = str.Remove(3);
            str = str.Insert(3, "o");
            right_ai.respond_table(str);
            str = table.Deal(2);
            str = str.Remove(3);
            str = str.Insert(3, "o");
            opposite_ai.respond_table(str);
            str = table.Deal(3);
            str = str.Remove(3);
            str = str.Insert(3, "o");
            left_ai.respond_table(str);
            pictureBox_humanPlayer_card14.Name = table.Deal(0).Substring(1, 2);//根据谁先开始不同
            //AI_mopai();
        }

        protected void gameover()//游戏结束要执行的操作
        {
            humanPlayer_cancel = true;
            rightAIPlayer_cancel = true;
            oppositeAIPlayer_cancel = true;
            leftAIPlayer_cancel = true;
            //table.Dispose();

            if (humanPlayer_gameover)
            {
                humanPlayer_money.Text = "胡啦！money:" + table.Result(0);//赢/输多少钱
            }
            else
            {
                humanPlayer_money.Text = "没胡,money:" + table.Result(0);
            }
            if (rightAIPlayer_gameover)
            {
                rightAIPlayer_money.Text = "胡啦!money:" + table.Result(1);//赢/输多少钱
            }
            else
            {
                rightAIPlayer_money.Text = "没胡,money:" + table.Result(1);
            }
            if (oppositeAIPlayer_gameover)
            {
                oppositeAIPlayer_money.Text = "胡啦!money:" + table.Result(2);//赢/输多少钱
            }
            else
            {
                oppositeAIPlayer_money.Text = "没胡,money:" + table.Result(2);
            }
            if (leftAIPlayer_gameover)
            {
                leftAIPlayer_money.Text = "胡啦!money:" + table.Result(3);//赢/输多少钱
            }
            else
            {
                leftAIPlayer_money.Text = "没胡,money:" + table.Result(3);
            }

            humanPlayer_money.Visible = true;
            rightAIPlayer_money.Visible = true;
            oppositeAIPlayer_money.Visible = true;
            leftAIPlayer_money.Visible = true;

            if (true)//如果赢
            {
                //MessageBox.Show("you win", "", MessageBoxButtons.OK);
            }
            else//输
            {
                MessageBox.Show("you lose", "", MessageBoxButtons.OK);
            }
            game_start.Visible = true;
            game_exit.Visible = true;
        }

        protected void remind_play()//长时间不出牌提醒
        {
            human_guo.BackColor = Color.Green;
            Thread.Sleep(500);
            human_guo.BackColor = Color.Transparent;
            if (humanPlayerdone == true)
            {
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\remind_play.wav");
                sp.PlaySync();
            }
            if (rightAIPlayerdone == true)
            {
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\remind_play.wav");
                sp.PlaySync();
            }
            if (oppositeAIPlayerdone == true)
            {
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\remind_play.wav");
                sp.PlaySync();
            }
            if (leftAIPlayerdone == true)
            {
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\humanPlayer\\remind_play.wav");
                sp.PlaySync();
            }
            //兵贵神速
            //soundplay
        }

        protected void human_picturebox_enablef()
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

        protected void human_picturebox_enablet()
        {
            if (pictureBox_humanPlayer_card1.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card1.Enabled = true;//start之前不可响应
            }
            if (pictureBox_humanPlayer_card2.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card2.Enabled = true;
            }
            if (pictureBox_humanPlayer_card3.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card3.Enabled = true;
            }
            if (pictureBox_humanPlayer_card4.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card4.Enabled = true;
            }
            if (pictureBox_humanPlayer_card5.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card5.Enabled = true;
            }
            if (pictureBox_humanPlayer_card6.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card6.Enabled = true;
            }
            if (pictureBox_humanPlayer_card7.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card7.Enabled = true;
            }
            if (pictureBox_humanPlayer_card8.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card8.Enabled = true;
            }
            if (pictureBox_humanPlayer_card9.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card9.Enabled = true;
            }
            if (pictureBox_humanPlayer_card10.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card10.Enabled = true;
            }
            if (pictureBox_humanPlayer_card11.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card11.Enabled = true;
            }
            if (pictureBox_humanPlayer_card12.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card12.Enabled = true;
            }
            if (pictureBox_humanPlayer_card13.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card13.Enabled = true;
            }
            if (pictureBox_humanPlayer_card14.Name[0] != 'a')
            {
                pictureBox_humanPlayer_card14.Enabled = true;
            }
        }
        #endregion

        #region//my
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

        protected void my_initialize()//自定义初始化内容
        {
            current_card = "blank";

            //出过得牌数置零
            humanPlayer_havePlayedcard_num = 0;
            humanPlayer_haveshowedcard_num = 0;
            leftAIPlayer_havePlayedcard_num = 0;
            leftAIPlayer_haveshowedcard_num = 0;
            rightAIPlayer_havePlayedcard_num = 0;
            rightAIPlayer_haveshowedcard_num = 0;
            oppositeAIPlayer_havePlayedcard_num = 0;
            oppositeAIPlayer_haveshowedcard_num = 0;

            humanPlayer_cancel = false;
            rightAIPlayer_cancel = false;
            oppositeAIPlayer_cancel = false;
            leftAIPlayer_cancel = false;

            humanPlayer_gameover = false;
            rightAIPlayer_gameover = false;
            oppositeAIPlayer_gameover = false;
            leftAIPlayer_gameover = false;
            intgameover = 0;

            humanPlayer_money.Visible = false;
            humanPlayer_money.BackColor = Color.White;
            rightAIPlayer_money.Visible = false;
            rightAIPlayer_money.BackColor = Color.White;
            oppositeAIPlayer_money.Visible = false;
            oppositeAIPlayer_money.BackColor = Color.White;
            leftAIPlayer_money.Visible = false;
            leftAIPlayer_money.BackColor = Color.White;

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

            human_picturebox_enablef();

            //三个AIPlayer手牌只显示背面
            pictureBox_leftAIPlayer_card1.Visible = false;
            pictureBox_leftAIPlayer_card2.Visible = false;
            pictureBox_leftAIPlayer_card3.Visible = false;
            pictureBox_leftAIPlayer_card4.Visible = false;
            pictureBox_leftAIPlayer_card5.Visible = false;
            pictureBox_leftAIPlayer_card6.Visible = false;
            pictureBox_leftAIPlayer_card7.Visible = false;
            pictureBox_leftAIPlayer_card8.Visible = false;
            pictureBox_leftAIPlayer_card9.Visible = false;
            pictureBox_leftAIPlayer_card10.Visible = false;
            pictureBox_leftAIPlayer_card11.Visible = false;
            pictureBox_leftAIPlayer_card12.Visible = false;
            pictureBox_leftAIPlayer_card13.Visible = false;

            pictureBox_rightAIPlayer_card1.Visible = false;
            pictureBox_rightAIPlayer_card2.Visible = false;
            pictureBox_rightAIPlayer_card3.Visible = false;
            pictureBox_rightAIPlayer_card4.Visible = false;
            pictureBox_rightAIPlayer_card5.Visible = false;
            pictureBox_rightAIPlayer_card6.Visible = false;
            pictureBox_rightAIPlayer_card7.Visible = false;
            pictureBox_rightAIPlayer_card8.Visible = false;
            pictureBox_rightAIPlayer_card9.Visible = false;
            pictureBox_rightAIPlayer_card10.Visible = false;
            pictureBox_rightAIPlayer_card11.Visible = false;
            pictureBox_rightAIPlayer_card12.Visible = false;
            pictureBox_rightAIPlayer_card13.Visible = false;

            pictureBox_oppositeAIPlayer_card1.Visible = false;
            pictureBox_oppositeAIPlayer_card2.Visible = false;
            pictureBox_oppositeAIPlayer_card3.Visible = false;
            pictureBox_oppositeAIPlayer_card4.Visible = false;
            pictureBox_oppositeAIPlayer_card5.Visible = false;
            pictureBox_oppositeAIPlayer_card6.Visible = false;
            pictureBox_oppositeAIPlayer_card7.Visible = false; ;
            pictureBox_oppositeAIPlayer_card8.Visible = false;
            pictureBox_oppositeAIPlayer_card9.Visible = false;
            pictureBox_oppositeAIPlayer_card10.Visible = false;
            pictureBox_oppositeAIPlayer_card11.Visible = false;
            pictureBox_oppositeAIPlayer_card12.Visible = false;
            pictureBox_oppositeAIPlayer_card13.Visible = false;

            //humanPlayer手牌初始为cardbcak
            Image pb = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");
            pictureBox_human_move.Image = Image.FromFile(Application.StartupPath + "\\picture\\blank.jpg");
            pictureBox_humanPlayer_card1.Image = pb;
            pictureBox_humanPlayer_card2.Image = pb;
            pictureBox_humanPlayer_card3.Image = pb;
            pictureBox_humanPlayer_card4.Image = pb;
            pictureBox_humanPlayer_card5.Image = pb;
            pictureBox_humanPlayer_card6.Image = pb;
            pictureBox_humanPlayer_card7.Image = pb;
            pictureBox_humanPlayer_card8.Image = pb;
            pictureBox_humanPlayer_card9.Image = pb;
            pictureBox_humanPlayer_card10.Image = pb;
            pictureBox_humanPlayer_card11.Image = pb;
            pictureBox_humanPlayer_card12.Image = pb;
            pictureBox_humanPlayer_card13.Image = pb;
            pictureBox_humanPlayer_card14.Image = pb;

            //四位玩家已打出的牌初始化
            pictureBox_humanPlayer_havePlayedcard1.Visible = false;
            pictureBox_humanPlayer_havePlayedcard2.Visible = false;
            pictureBox_humanPlayer_havePlayedcard3.Visible = false;
            pictureBox_humanPlayer_havePlayedcard4.Visible = false;
            pictureBox_humanPlayer_havePlayedcard5.Visible = false;
            pictureBox_humanPlayer_havePlayedcard6.Visible = false;
            pictureBox_humanPlayer_havePlayedcard7.Visible = false;
            pictureBox_humanPlayer_havePlayedcard8.Visible = false;
            pictureBox_humanPlayer_havePlayedcard9.Visible = false;
            pictureBox_humanPlayer_havePlayedcard10.Visible = false;
            pictureBox_humanPlayer_havePlayedcard11.Visible = false;
            pictureBox_humanPlayer_havePlayedcard12.Visible = false;
            pictureBox_humanPlayer_havePlayedcard13.Visible = false;
            pictureBox_humanPlayer_havePlayedcard14.Visible = false;

            pictureBox_rightAIPlayer_havePlayedcard1.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard2.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard3.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard4.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard5.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard6.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard7.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard8.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard9.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard10.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard11.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard12.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard13.Visible = false;
            pictureBox_rightAIPlayer_havePlayedcard14.Visible = false;

            pictureBox_oppositeAIPlayer_havePlayedcard1.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard2.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard3.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard4.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard5.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard6.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard7.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard8.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard9.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard10.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard11.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard12.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard13.Visible = false;
            pictureBox_oppositeAIPlayer_havePlayedcard14.Visible = false;

            pictureBox_leftAIPlayer_havePlayedcard1.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard2.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard3.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard4.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard5.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard6.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard7.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard8.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard9.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard10.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard11.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard12.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard13.Visible = false;
            pictureBox_leftAIPlayer_havePlayedcard14.Visible = false;
        }

        protected void my_show()//整理手牌并显示图片
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
            pb = pictureBox_humanPlayer_card1.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card1.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card2.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card2.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card3.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card3.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card4.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card4.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card5.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card5.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card6.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card6.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card7.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card7.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card8.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card8.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card9.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card9.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card10.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card10.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card11.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card11.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card12.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card12.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card13.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card13.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
            pb = pictureBox_humanPlayer_card14.Name;
            if (pb[0] == 'a')
            {
                pb.Remove(0, 2);
            }
            pictureBox_humanPlayer_card14.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb + ".jpg");
        }
        #endregion

        #region//human
        protected void human_mopai()//摸牌程序
        {
            current_card = table.Deal(0).Substring(1, 2);
            pictureBox_humanPlayer_card14.Name = current_card;
        }

        protected void humanPlayer_next()
        {
            humanPlayerdone = true;
            leftAIPlayerdone = false;
            oppositeAIPlayerdone = false;
            rightAIPlayerdone = false;
        }

        protected void humanPlayer_chupai()//出牌程序
        {

            card_haveused = false;//只要刚出牌，牌肯定没用过    
            humanPlayer_havePlayedcard_num++;
            PictureBox pb = humanPlayer_switch();

            pictureBox_human_move.Height = pictureBox_humanPlayer_card1.Height;
            pictureBox_human_move.Width = pictureBox_humanPlayer_card1.Width;
            pictureBox_human_move.Name = current_card;
            pictureBox_human_move.Location = target_point;
            target_point = pb.Location;
            pictureBox_human_move.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pictureBox_human_move.Name + ".jpg");
            pictureBox_human_move.Visible = true;
            D_MOVE_X = (target_point.X - pictureBox_human_move.Location.X) / 10;
            D_MOVE_Y = (target_point.Y - pictureBox_human_move.Location.Y) / 10;
            timer.Start();

            humanPlayer_movedone.WaitOne();

            #region//出牌
            pb.Name = current_card;
            pb.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + current_card + ".jpg");
            pb.Visible = true;
            sp = new SoundPlayer(Application.StartupPath + "\\sound\\humanPlayer\\" + current_card + ".wav");
            sp.PlaySync();
            #endregion

            #region//ask           
            if (rightAIPlayer_gameover == false && card_haveused == false)
            {
                ask_rightAIPlayer();
            }
            if (oppositeAIPlayer_gameover == false && card_haveused == false)
            {
                ask_oppositeAIPlayer();
            }
            if (leftAIPlayer_gameover == false && card_haveused == false)
            {
                ask_leftAIPlayer();
            }
            #endregion

            humanPlayer_next();
        }

        protected void human_peng_change()
        {
            if (pictureBox_humanPlayer_card1.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card2.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card3.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card4.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card5.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card6.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card7.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card8.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card9.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card10.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card11.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card12.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
            if (pictureBox_humanPlayer_card13.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ap" + current_card;
            }
        }

        protected void human_gang_change()
        {
            if (pictureBox_humanPlayer_card1.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card2.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card3.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card4.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card5.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card6.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card7.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card8.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card9.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card10.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card11.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card12.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
            if (pictureBox_humanPlayer_card13.Name == current_card)
            {
                pictureBox_humanPlayer_card1.Name = "ag" + current_card;
            }
        }

        protected int human_samecard()
        {
            int i = 0;
            if (pictureBox_humanPlayer_card1.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card2.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card3.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card4.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card5.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card6.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card7.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card8.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card9.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card10.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card11.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card12.Name == current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card13.Name == current_card)
            {
                i++;
            }
            return i;
        }

        protected int human_peng_samecard()//碰的个数
        {
            int i = 0;
            if (pictureBox_humanPlayer_card1.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card2.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card3.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card4.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card5.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card6.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card7.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card8.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card9.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card10.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card11.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card12.Name == "ap" + current_card)
            {
                i++;
            }
            if (pictureBox_humanPlayer_card13.Name == "ap" + current_card)
            {
                i++;
            }
            return i;
        }
        #endregion
        protected void human_play()
        {
            leftAIPlayer_next();
            if (humanPlayer_gameover == false && humanPlayer_cancel == false)
            {
                if (human_peng.Name == "yes")//碰
                {
                    human_peng.Name = "no";
                    human_peng_change();
                    pictureBox_humanPlayer_card14.Name = "ap" + current_card;//碰的牌先放在14                
                }
                if (human_gang.Name == "yes")
                {
                    human_gang.Name = "no";
                    human_gang_change();
                    human_mopai();
                }
                if (human_peng.Name == "no" && human_gang.Name == "no")
                {
                    human_mopai();
                }
                if (card_haveused == false)
                {
                    ask_humanPlayer();
                }
                my_show();//之后要加指示那张牌是碰的/杠的                
                human_picturebox_enablet();
            }
            else
            {
                humanPlayer_cancel = false;
            }
        }

        #region//right
        protected void rightAIPlayer_mopai()
        {
            current_card = table.Deal(1);
            current_card = right_ai.respond_table(current_card).Substring(1, 2);
        }

        protected void rightAIPlayer_chupai(string pai)
        {
            rightAIPlayer_havePlayedcard_num++;
            card_haveused = false;//只要刚出牌，牌肯定没用过
            PictureBox pb = rightAIPlayer_switch();

            pictureBox_human_move.Height = pictureBox_rightAIPlayer_card1.Height;
            pictureBox_human_move.Width = pictureBox_rightAIPlayer_card1.Width;
            target_point = pictureBox_rightAIPlayer_card1.Location;
            pictureBox_human_move.Name = current_card;
            pictureBox_human_move.Location = target_point;
            target_point = pb.Location;

            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pai + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
            pictureBox_human_move.Image = picture_ro;
            pictureBox_human_move.Visible = true;

            D_MOVE_X = (target_point.X - pictureBox_human_move.Location.X) / 10;
            D_MOVE_Y = (target_point.Y - pictureBox_human_move.Location.Y) / 10;
            timer.Start();

            rightAIPlayer_movedone.WaitOne();

            pb.Name = pai;
            pb.Image = picture_ro;
            pb.Visible = true;
        }

        protected void rightAIPlayer_next()
        {
            rightAIPlayerdone = true;
            humanPlayerdone = false;
            oppositeAIPlayerdone = false;
            leftAIPlayerdone = false;
        }

        protected void rightAIPlayer_show()
        {
            rightAIPlayer_haveshowedcard_num++;
            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + current_card + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);
            PictureBox pb = rightAIPlayer_haveshowedcard_switch();
            pb.Name = current_card;
            pb.Image = picture_ro;
            pb.Visible = true;
        }

        protected void rightAIPlayer_peng_gang()//根据right是碰还是杠执行的操作
        {
            if (rightAIPlayer_peng == true)
            {
                rightAIPlayer_peng = false;
                rightAIPlayer_show();
            }
            if (rightAIPlayer_gang == true)
            {
                rightAIPlayer_mopai();
                rightAIPlayer_gang = false;
                rightAIPlayer_show();
            }
            if (rightAIPlayer_peng == false && rightAIPlayer_gang == false)
            {
                rightAIPlayer_mopai();
            }
        }
        #endregion
        protected void rightAIPlayer_play()
        {
            humanPlayer_next();
            if (rightAIPlayer_gameover == false && rightAIPlayer_cancel == false)
            {
                rightAIPlayer_peng_gang();
                if (card_haveused == false)
                {
                    ask_rightAIPlayer();
                }
                rightAIPlayer_chupai(current_card);
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\" + current_card + ".wav");
                sp.PlaySync();

                #region//ask
                if (oppositeAIPlayer_gameover == false && card_haveused == false)
                {
                    ask_oppositeAIPlayer();
                }
                if (leftAIPlayer_gameover == false && card_haveused == false)
                {
                    ask_leftAIPlayer();
                }
                if (humanPlayer_gameover == false && card_haveused == false)
                {
                    ask_humanPlayer();
                }
                #endregion
            }
            else
            {
                rightAIPlayer_cancel = false;
            }
            rightAIPlayer_next();
        }

        #region//opposite
        protected void oppositeAIPlayer_mopai()
        {
            current_card = table.Deal(2);
            current_card = opposite_ai.respond_table(current_card).Substring(1, 2);
        }

        protected void oppositeAIPlayer_chupai(string pai)
        {
            oppositeAIPlayer_havePlayedcard_num++;
            card_haveused = false;//只要刚出牌，牌肯定没用过
            PictureBox pb = oppositeAIPlayer_switch();

            pictureBox_human_move.Height = pictureBox_oppositeAIPlayer_card1.Height;
            pictureBox_human_move.Width = pictureBox_oppositeAIPlayer_card1.Width;
            target_point = pictureBox_oppositeAIPlayer_card1.Location;
            pictureBox_human_move.Name = current_card;
            pictureBox_human_move.Location = target_point;
            target_point = pb.Location;
            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pai + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox_human_move.Image = picture_ro;
            pictureBox_human_move.Visible = true;

            D_MOVE_X = (target_point.X - pictureBox_human_move.Location.X) / 10;
            D_MOVE_Y = (target_point.Y - pictureBox_human_move.Location.Y) / 10;
            timer.Start();

            oppositeAIPlayer_movedone.WaitOne();

            pb.Name = pai;
            pb.Image = picture_ro;
            pb.Visible = true;
        }

        protected void oppositeAIPlayer_next()
        {
            oppositeAIPlayerdone = true;
            rightAIPlayerdone = false;
            leftAIPlayerdone = false;
            humanPlayerdone = false;
        }

        protected void oppositeAIPlayer_show()
        {
            oppositeAIPlayer_haveshowedcard_num++;
            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + current_card + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);
            PictureBox pb = rightAIPlayer_haveshowedcard_switch();
            pb.Name = current_card;
            pb.Image = picture_ro;
            pb.Visible = true;          
        }

        protected void oppositeAIPlayer_peng_gang()
        {
            if (oppositeAIPlayer_peng == true)
            {
                oppositeAIPlayer_peng = false;
                oppositeAIPlayer_show();
            }
            if (oppositeAIPlayer_gang == true)
            {
                oppositeAIPlayer_gang = false;
                oppositeAIPlayer_show();
                oppositeAIPlayer_mopai();
            }
            if (oppositeAIPlayer_peng == false && oppositeAIPlayer_gang == false)
            {
                oppositeAIPlayer_mopai();
            }
        }
        #endregion
        protected void oppositeAIPlayer_play()
        {
            rightAIPlayer_next();
            if (oppositeAIPlayer_gameover == false && oppositeAIPlayer_cancel == false)
            {
                oppositeAIPlayer_peng_gang();
                if (card_haveused == false)
                {
                    ask_oppositeAIPlayer();
                }
                oppositeAIPlayer_chupai(current_card);

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\" + current_card + ".wav");
                sp.PlaySync();

                #region//ask
                if (leftAIPlayer_gameover == false && card_haveused == false)
                {
                    ask_leftAIPlayer();
                }
                if (humanPlayer_gameover == false && card_haveused == false)
                {
                    ask_humanPlayer();
                }
                if (rightAIPlayer_gameover == false && card_haveused == false)
                {
                    ask_rightAIPlayer();
                }
                #endregion
            }
            else
            {
                oppositeAIPlayer_cancel = false;
            }
            oppositeAIPlayer_next();
        }

        #region//left
        protected void leftAIPlayer_mopai()
        {
            current_card = table.Deal(3);
            current_card = left_ai.respond_table(current_card).Substring(1, 2);
        }

        protected void leftAIPlayer_chupai(string pai)
        {
            leftAIPlayer_havePlayedcard_num++;
            card_haveused = false;//只要刚出牌，牌肯定没用过
            PictureBox pb = leftAIPlayer_switch();

            pictureBox_human_move.Height = pictureBox_leftAIPlayer_card1.Height;
            pictureBox_human_move.Width = pictureBox_leftAIPlayer_card1.Width;
            target_point = pictureBox_leftAIPlayer_card1.Location;
            pictureBox_human_move.Name = current_card;
            pictureBox_human_move.Location = target_point;
            target_point = pb.Location;
            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pai + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox_human_move.Image = picture_ro;
            pictureBox_human_move.Visible = true;

            D_MOVE_X = (target_point.X - pictureBox_human_move.Location.X) / 10;
            D_MOVE_Y = (target_point.Y - pictureBox_human_move.Location.Y) / 10;
            timer.Start();

            leftAIPlayer_movedone.WaitOne();

            pb.Name = pai;
            pb.Image = picture_ro;
            pb.Visible = true;
        }

        protected void leftAIPlayer_next()
        {
            leftAIPlayerdone = true;
            oppositeAIPlayerdone = false;
            humanPlayerdone = false;
            rightAIPlayerdone = false;
        }

        protected void leftAIPlayer_show()
        {
            leftAIPlayer_haveshowedcard_num++;
            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + current_card + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate90FlipNone);
            PictureBox pb = rightAIPlayer_haveshowedcard_switch();
            pb.Name = current_card;
            pb.Image = picture_ro;
            pb.Visible = true;
        }

        protected void leftAIPlayer_peng_gang()
        {
            if (leftAIPlayer_peng == true)
            {
                leftAIPlayer_peng = false;
                leftAIPlayer_show();
            }
            if (leftAIPlayer_gang == true)
            {
                leftAIPlayer_gang = false;
                leftAIPlayer_show();
                leftAIPlayer_mopai();
            }
            if (leftAIPlayer_peng == false && leftAIPlayer_gang == false)
            {
                leftAIPlayer_mopai();
            }
        }
        #endregion
        protected void leftAIPlayer_play()
        {
            oppositeAIPlayer_next();
            if (leftAIPlayer_gameover == false && leftAIPlayer_cancel == false)
            {
                leftAIPlayer_peng_gang();
                if (card_haveused == false)
                {
                    ask_leftAIPlayer();//leftAIPlayer可能胡
                }
                leftAIPlayer_chupai(current_card);

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\" + current_card + ".wav");
                sp.PlaySync();

                #region//ask
                if (humanPlayer_gameover == false && card_haveused == false)
                {
                    ask_humanPlayer();
                }
                if (rightAIPlayer_gameover == false && card_haveused == false)
                {
                    ask_rightAIPlayer();
                }
                if (oppositeAIPlayer_gameover == false && card_haveused == false)
                {
                    ask_oppositeAIPlayer();
                }
                #endregion
            }
            else
            {
                leftAIPlayer_cancel = false;
            }
            leftAIPlayer_next();
        }

        #region//play and start        
        protected void Player_Play()
        {
            humanPlayer_chupai();
            my_show();
            rightAIPlayer_play();
            oppositeAIPlayer_play();
            leftAIPlayer_play();
            human_play();
            Thread.CurrentThread.Abort();
        }

        protected void rightAIPlayer_gamestart()
        {
            rightAIPlayer_play();
            oppositeAIPlayer_play();
            leftAIPlayer_play();
            human_play();
            Thread.CurrentThread.Abort();
        }

        protected void oppositeAIPlayer_gamestart()
        {
            oppositeAIPlayer_play();
            leftAIPlayer_play();
            human_play();
            Thread.CurrentThread.Abort();
        }

        protected void leftAIPlayer_gamestart()
        {
            leftAIPlayer_play();
            human_play();
            Thread.CurrentThread.Abort();
        }

        protected void humanPlayer_gamestart()
        {
            human_play();
            Thread.CurrentThread.Abort();
        }
        #endregion

        #region//ask
        protected void ask_rightAIPlayer()
        {
            string str = right_ai.respond_table(table.Realize());//告诉ai出牌，返回ai想法
            table.Get(str);
            string str_realize = table.Realize();

            #region//胡
            if (str_realize[3] == '2') //胡
            {
                card_haveused = true;
                rightAIPlayer_money.Text = "胡啦";
                rightAIPlayer_money.BackColor = Color.Red;
                rightAIPlayer_money.Visible = true;

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\hu.wav");
                sp.PlaySync();

                intgameover++;
                rightAIPlayer_gameover = true;//已胡
                if (intgameover == 3)
                {
                    gameover();//游戏结束
                }
                else
                {
                    if (humanPlayerdone == true)//自摸胡的
                    {

                    }
                    if (leftAIPlayerdone == true)//human玩家问胡的（上家）
                    {

                    }
                    if (rightAIPlayerdone == true)//opposite玩家问胡的（下家）
                    {
                        oppositeAIPlayer_play();
                    }
                    if (oppositeAIPlayerdone == true)//left玩家问胡的（下下家）
                    {
                        oppositeAIPlayer_play();
                        leftAIPlayer_play();
                    }
                }
            }
            #endregion

            #region//碰//杠

            if (str_realize[3] == '4')//选择碰
            {
                card_haveused = true;
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\peng.wav");
                sp.PlaySync();
                rightAIPlayer_peng = true;

                if (leftAIPlayerdone == true)//当前是主线程（human）
                {

                }
                if (rightAIPlayerdone == true)//当前是opposite线程
                {
                    rightAIPlayer_play();
                    oppositeAIPlayer_play(); ;
                }
                if (oppositeAIPlayerdone == true)//当前是left线程
                {
                    rightAIPlayer_play();
                    oppositeAIPlayer_play();
                    leftAIPlayer_play();
                }
            }

            if (str_realize[3] == '3' || str_realize[3] == '5' || str_realize[3] == '6')//选择杠
            {
                card_haveused = true;
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\gang.wav");
                sp.PlaySync();
                rightAIPlayer_gang = true;
                rightAIPlayer_mopai();

                if (leftAIPlayerdone == true)//当前是主线程（human）
                {

                }
                if (rightAIPlayerdone == true)//当前是opposite线程
                {
                    rightAIPlayer_play();
                    oppositeAIPlayer_play(); ;
                }
                if (oppositeAIPlayerdone == true)//当前是left线程
                {
                    rightAIPlayer_play();
                    oppositeAIPlayer_play();
                    leftAIPlayer_play();
                }
            }

            #endregion
        }

        protected void ask_oppositeAIPlayer()
        {
            string str = opposite_ai.respond_table(table.Realize());//告诉ai出牌，返回ai想法
            table.Get(str);
            string str_realize = table.Realize();

            #region//胡
            if (str_realize[3] == '2')//胡
            {
                card_haveused = true;
                oppositeAIPlayer_money.Text = "胡啦";
                oppositeAIPlayer_money.BackColor = Color.Red;
                oppositeAIPlayer_money.Visible = true;

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\hu.wav");
                sp.PlaySync();

                intgameover++;
                oppositeAIPlayer_gameover = true;//已胡
                if (intgameover == 3)
                {
                    gameover();//游戏结束
                }
                else
                {
                    if (rightAIPlayerdone == true)//自摸胡的
                    {

                    }
                    if (leftAIPlayerdone == true)//human玩家问胡的（上上家）
                    {
                        rightAIPlayer_cancel = true;//rightAIPlayer出牌线程取消
                    }
                    if (humanPlayerdone == true)//right玩家问胡的（上家）
                    {

                    }
                    if (oppositeAIPlayerdone == true)//left玩家问胡的（下家）
                    {
                        leftAIPlayer_play();
                    }
                }
            }
            #endregion

            #region//碰/杠

            if (str_realize[3] == '4')//选择碰
            {
                card_haveused = true;
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\peng.wav");
                sp.PlaySync();
                oppositeAIPlayer_peng = true;

                if (leftAIPlayerdone == true)//当前是主线程（human）
                {
                    rightAIPlayer_cancel = true;
                }
                if (humanPlayerdone == true)//当前是right线程
                {

                }
                if (oppositeAIPlayerdone == true)//当前是left线程
                {
                    oppositeAIPlayer_play();
                    leftAIPlayer_play();
                }
            }

            if (str_realize[3] == '3' || str_realize[3] == '5' || str_realize[3] == '6')//选择杠
            {
                card_haveused = true;
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\gang.wav");
                sp.PlaySync();
                oppositeAIPlayer_gang = true;
                oppositeAIPlayer_mopai();

                if (leftAIPlayerdone == true)//当前是主线程（human）
                {
                    rightAIPlayer_cancel = true;
                }
                if (humanPlayerdone == true)//当前是right线程
                {

                }
                if (oppositeAIPlayerdone == true)//当前是left线程
                {
                    oppositeAIPlayer_play();
                    leftAIPlayer_play();
                }
            }
            #endregion
        }

        protected void ask_leftAIPlayer()
        {
            string str = left_ai.respond_table(table.Realize());//告诉ai出牌，返回ai想法
            table.Get(str);
            string str_realize = table.Realize();

            #region//胡
            if (str_realize[3] == '2')//胡
            {
                card_haveused = true;
                leftAIPlayer_money.Text = "胡啦";
                leftAIPlayer_money.BackColor = Color.Red;
                leftAIPlayer_money.Visible = true;

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\hu.wav");
                sp.PlaySync();

                intgameover++;
                leftAIPlayer_gameover = true;//已胡
                if (intgameover == 3)
                {
                    gameover();//游戏结束
                }
                else
                {
                    if (oppositeAIPlayerdone == true)//自摸胡的
                    {

                    }
                    if (leftAIPlayerdone == true)//human玩家问胡的(下家）
                    {
                        rightAIPlayer_cancel = true;
                        oppositeAIPlayer_cancel = true;
                        leftAIPlayer_cancel = true;
                    }
                    if (humanPlayerdone == true)//right玩家问胡的（上上家）
                    {
                        oppositeAIPlayer_cancel = true;//oppositeAIPlayer出牌线程取消
                    }
                    if (rightAIPlayerdone == true)//opposite玩家问胡的（上家）
                    {

                    }
                }
            }
            #endregion

            #region//碰/杠               
            if (str_realize[3] == '4')//选择碰
            {
                card_haveused = true;
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\peng.wav");
                sp.PlaySync();
                leftAIPlayer_peng = true;

                if (leftAIPlayerdone == true)//当前是主线程（human）
                {
                    rightAIPlayer_cancel = true;
                    oppositeAIPlayer_cancel = true;

                }
                if (humanPlayerdone == true)//当前是right线程
                {
                    oppositeAIPlayer_cancel = true;
                }
                if (rightAIPlayerdone == true)//当前是opposite线程
                {

                }
            }

            if (str_realize[3] == '3' || str_realize[3] == '5' || str_realize[3] == '6')//选择杠
            {
                card_haveused = true;
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\gang.wav");
                sp.PlaySync();
                leftAIPlayer_gang = true;
                leftAIPlayer_mopai();

                if (leftAIPlayerdone == true)//当前是主线程（human）
                {
                    rightAIPlayer_cancel = true;
                    oppositeAIPlayer_cancel = true;

                }
                if (humanPlayerdone == true)//当前是right线程
                {
                    oppositeAIPlayer_cancel = true;
                }
                if (rightAIPlayerdone == true)//当前是opposite线程
                {

                }
            }

            //碰了           
            #endregion

        }

        protected void ask_humanPlayer()
        {
            int i = 0;
            int samecard = human_samecard();
            int peng_samecard = human_peng_samecard();
            #region//响应

            if (table.IsHu(0))//能胡
            {
                human_hu.Enabled = true;
                human_guo.Enabled = true;
                table.Get("0" + current_card + "2");
            }

            if (leftAIPlayerdone == false && samecard == 2)//&&自己摸牌不能碰&&能碰,>=
            {
                human_peng.Enabled = true;
                human_guo.Enabled = true;
                table.Get("0" + current_card + "7");
            }

            if (samecard == 3)//能直杠或暗杠或碰
            {
                //human_peng.Enabled = true;
                human_gang.Enabled = true;
                human_guo.Enabled = true;
                if (leftAIPlayerdone == true)//human回合,暗杠
                {
                    table.Get("0" + current_card + "3");
                }
                else
                {
                    table.Get("0" + current_card + "9");//直杠
                }
            }
            else
            {
                if (peng_samecard == 3)
                {
                    human_gang.Enabled = true;
                    human_guo.Enabled = true;
                    table.Get("0" + current_card + "8");//弯杠
                }
            }


            for (i = 0; i < TIME_MAX; i++)
            {
                Thread.Sleep(500);
                if (human_hu.Name == "yes" || human_guo.Name == "yes" || human_peng.Name == "yes" || human_gang.Name == "yes" || human_guo.Enabled == false)
                {
                    break;
                }
                if (i % 100 == 0 && i > 100)//一段时间不点，提醒
                {
                    remind_play();
                }
            }
            if (i == TIME_MAX)//长时间不出即为过
            {
                human_guo.Name = "yes";
            }
            human_peng.Enabled = false;
            human_gang.Enabled = false;
            human_hu.Enabled = false;
            human_guo.Enabled = false;
            #endregion

            #region//胡
            if (human_hu.Name == "yes")//胡
            {
                table.Realize();
                card_haveused = true;
                humanPlayer_money.Text = "胡啦";
                humanPlayer_money.BackColor = Color.Red;
                humanPlayer_money.Visible = true;

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\humanPlayer\\hu.wav");
                sp.PlaySync();

                intgameover++;
                humanPlayer_gameover = true;

                if (intgameover == 3)
                {
                    gameover();
                }
                else
                {
                    for (i = 0; ; i++)
                    {
                        #region//right回合
                        if (rightAIPlayer_gameover == false && rightAIPlayer_cancel == false)//right
                        {
                            rightAIPlayer_peng_gang();
                            #region//right_ask_right_humandone()
                            if (true)//能胡,自摸
                            {
                                if (true)//胡
                                {
                                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\hu.wav");
                                    sp.PlaySync();

                                    rightAIPlayer_gameover = true;
                                    intgameover++;
                                    if (intgameover == 3)
                                    {
                                        gameover();
                                        break;
                                    }
                                    else
                                    {
                                        rightAIPlayer_cancel = true;//游戏未结束跳过出牌
                                    }
                                }
                            }
                            #endregion
                            if (rightAIPlayer_cancel == false)
                            {
                                current_card = "t1";
                                rightAIPlayer_chupai(current_card);

                                #region//ask
                                if (oppositeAIPlayer_gameover == false && card_haveused == false)
                                {
                                    #region//right_ask_opposite_humandone()
                                    if (true)//能胡/碰/杠
                                    {
                                        #region//胡
                                        if (true)//胡
                                        {
                                            sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\hu.wav");
                                            sp.PlaySync();

                                            card_haveused = true;
                                            oppositeAIPlayer_gameover = true;
                                            intgameover++;
                                            if (intgameover == 3)
                                            {
                                                gameover();
                                                break;
                                            }
                                            else
                                            {

                                            }
                                        }
                                        #endregion

                                        #region//碰/杠
                                        if (true)//碰/杠
                                        {
                                            card_haveused = true;
                                            if (true)//选择碰
                                            {
                                                sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\peng.wav");
                                                sp.PlaySync();
                                                oppositeAIPlayer_peng = true;
                                            }
                                            else
                                            {
                                                if (true)//选择杠
                                                {
                                                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\gang.wav");
                                                    sp.PlaySync();
                                                    oppositeAIPlayer_gang = true;
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }

                                if (leftAIPlayer_gameover == false && card_haveused == false)
                                {
                                    #region//right_ask_left_humandone()
                                    if (true)//能胡/碰/杠
                                    {
                                        #region//胡
                                        if (true)//胡
                                        {
                                            sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\hu.wav");
                                            sp.PlaySync();
                                            card_haveused = true;
                                            leftAIPlayer_gameover = true;
                                            intgameover++;
                                            if (intgameover == 3)
                                            {
                                                gameover();
                                                break;
                                            }
                                            else
                                            {
                                                oppositeAIPlayer_cancel = true;
                                                leftAIPlayer_cancel = true;
                                            }
                                        }
                                        #endregion

                                        #region//碰/杠
                                        if (true)//碰/杠
                                        {
                                            card_haveused = true;
                                            if (true)//选择碰
                                            {
                                                sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\peng.wav");
                                                sp.PlaySync();
                                                leftAIPlayer_peng = true;
                                            }
                                            else
                                            {
                                                if (true)//选择杠
                                                {
                                                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\gang.wav");
                                                    sp.PlaySync();
                                                    leftAIPlayer_gang = true;
                                                }
                                            }
                                            oppositeAIPlayer_cancel = true;
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                rightAIPlayer_cancel = false;
                            }
                        }
                        else
                        {
                            rightAIPlayer_cancel = false;
                        }
                        #endregion

                        #region//opposite回合
                        if (oppositeAIPlayer_gameover == false && oppositeAIPlayer_cancel == false)//opposite
                        {
                            oppositeAIPlayer_peng_gang();
                            #region//opposite_ask_opposite_humandone
                            if (true)//自摸能胡
                            {
                                if (true)//胡
                                {
                                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\hu.wav");
                                    sp.PlaySync();
                                    oppositeAIPlayer_gameover = true;
                                    intgameover++;
                                    if (intgameover == 3)
                                    {
                                        gameover();
                                        break;
                                    }
                                    else
                                    {
                                        oppositeAIPlayer_cancel = true;
                                    }
                                }
                            }
                            #endregion
                            if (oppositeAIPlayer_cancel == false)
                            {
                                current_card = "t1";
                                oppositeAIPlayer_chupai(current_card);

                                #region//ask
                                if (leftAIPlayer_gameover == false && card_haveused == false)
                                {
                                    #region//opposite_ask_left_humandone
                                    if (true)//能胡/碰/杠
                                    {
                                        #region//胡
                                        if (true)//胡
                                        {
                                            sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\hu.wav");
                                            sp.PlaySync();
                                            card_haveused = true;
                                            leftAIPlayer_gameover = true;
                                            intgameover++;
                                            if (intgameover == 3)
                                            {
                                                gameover();
                                                break;
                                            }
                                            else
                                            {
                                                leftAIPlayer_cancel = true;
                                            }
                                        }
                                        #endregion

                                        #region//碰/杠
                                        if (true)//碰/杠
                                        {
                                            card_haveused = true;
                                            if (true)//选择碰
                                            {
                                                sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\hu.wav");
                                                sp.PlaySync();
                                                leftAIPlayer_peng = true;
                                            }
                                            else
                                            {
                                                if (true)//选择杠
                                                {
                                                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\hu.wav");
                                                    sp.PlaySync();
                                                    leftAIPlayer_gang = true;
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }

                                if (rightAIPlayer_gameover == false && card_haveused == false)
                                {
                                    #region//opposite_ask_right_humandone
                                    if (true)//能胡/碰/杠
                                    {
                                        #region//胡
                                        if (true)//胡
                                        {
                                            sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\hu.wav");
                                            sp.PlaySync();
                                            card_haveused = true;
                                            rightAIPlayer_gameover = true;
                                            intgameover++;
                                            if (intgameover == 3)
                                            {
                                                gameover();
                                                break;
                                            }
                                            else
                                            {
                                                leftAIPlayer_cancel = true;
                                            }
                                        }
                                        #endregion

                                        #region//碰/杠
                                        if (true)//碰/杠
                                        {
                                            card_haveused = true;
                                            if (true)//选择碰
                                            {
                                                sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\peng.wav");
                                                sp.PlaySync();
                                                rightAIPlayer_peng = true;
                                            }
                                            else
                                            {
                                                if (true)//选择杠
                                                {
                                                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\gang.wav");
                                                    sp.PlaySync();
                                                    rightAIPlayer_gang = true;
                                                }
                                            }
                                            leftAIPlayer_cancel = true;
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                oppositeAIPlayer_cancel = false;
                            }
                        }
                        else
                        {
                            oppositeAIPlayer_cancel = false;
                        }
                        #endregion

                        #region//left回合
                        if (leftAIPlayer_gameover == false && leftAIPlayer_cancel == false)//left
                        {
                            leftAIPlayer_peng_gang();
                            #region//left_ask_left_humandone
                            if (true)//自摸能胡
                            {
                                if (true)//胡
                                {
                                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\hu.wav");
                                    sp.PlaySync();
                                    leftAIPlayer_gameover = true;
                                    intgameover++;
                                    if (intgameover == 3)
                                    {
                                        gameover();
                                        break;
                                    }
                                    else
                                    {
                                        leftAIPlayer_cancel = true;
                                    }
                                }
                            }
                            #endregion
                            if (leftAIPlayer_cancel == false)
                            {
                                current_card = "t1";
                                leftAIPlayer_chupai(current_card);

                                #region//ask
                                if (rightAIPlayer_gameover == false && card_haveused == false)
                                {
                                    #region//left_ask_right_humandone
                                    if (true)//能胡/碰/杠
                                    {
                                        #region//胡
                                        if (true)//胡
                                        {
                                            sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\hu.wav");
                                            sp.PlaySync();

                                            card_haveused = true;
                                            rightAIPlayer_gameover = true;
                                            intgameover++;
                                            if (intgameover == 3)
                                            {
                                                gameover();
                                                break;
                                            }
                                            else
                                            {

                                            }
                                        }
                                        #endregion

                                        #region//碰/杠
                                        if (true)//碰/杠
                                        {
                                            card_haveused = true;
                                            if (true)//选择碰
                                            {
                                                sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\peng.wav");
                                                sp.PlaySync();
                                                rightAIPlayer_peng = true;
                                            }
                                            else
                                            {
                                                if (true)//选择杠
                                                {
                                                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\gang.wav");
                                                    sp.PlaySync();
                                                    rightAIPlayer_gang = true;
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }

                                if (oppositeAIPlayer_gameover == false && card_haveused == false)
                                {
                                    #region//left_ask_opposite_humandone
                                    if (true)//能胡/碰/杠
                                    {
                                        #region//胡
                                        if (true)//胡
                                        {
                                            sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\hu.wav");
                                            sp.PlaySync();

                                            card_haveused = true;
                                            oppositeAIPlayer_gameover = true;
                                            intgameover++;
                                            if (intgameover == 3)
                                            {
                                                gameover();
                                                break;
                                            }
                                            else
                                            {
                                                rightAIPlayer_cancel = true;
                                            }
                                        }
                                        #endregion

                                        #region//碰/杠
                                        if (true)//碰/杠
                                        {
                                            card_haveused = true;
                                            if (true)//选择碰
                                            {
                                                sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\peng.wav");
                                                sp.PlaySync();
                                                oppositeAIPlayer_peng = true;
                                            }
                                            else
                                            {
                                                if (true)//选择杠
                                                {
                                                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\gang.wav");
                                                    sp.PlaySync();
                                                    oppositeAIPlayer_gang = true;
                                                }
                                            }
                                            rightAIPlayer_cancel = true;
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                leftAIPlayer_cancel = false;
                            }
                        }
                        else
                        {
                            leftAIPlayer_cancel = false;
                        }
                        #endregion
                    }
                }
            }
            #endregion

            #region//碰 杠
            if (human_peng.Name == "yes" || human_gang.Name == "yes")//碰 杠
            {
                table.Realize();//报错
                card_haveused = true;
                humanPlayer_haveshowedcard_num++;
                if (human_peng.Name == "yes")
                {
                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\humanPlayer\\peng.wav");
                    sp.PlaySync();
                }
                if (human_gang.Name == "yes")
                {
                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\humanPlayer\\gang.wav");
                    sp.PlaySync();
                }

                if (humanPlayerdone == true)//当前是right线程
                {
                    oppositeAIPlayer_cancel = true;
                    leftAIPlayer_cancel = true;
                }
                if (rightAIPlayerdone == true)//opposite
                {
                    leftAIPlayer_cancel = true;
                }
                if (oppositeAIPlayerdone == true)//left
                {

                }
            }
            #endregion
            human_guo.Name = "no";//不能取消
        }

        #endregion

        public Form1()//初始化
        {
            //this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            //this.UpdateStyles();

            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//忽略跨线程错误
            my_initialize();//自定义的初始化内容   
            mediaplayer_backgroundmusic.URL = Application.StartupPath + "\\sound\\backgroundmusic.wav";
            mediaplayer_backgroundmusic.Ctlcontrols.stop();//默认不播放背景音乐
            mediaplayer_backgroundmusic.settings.setMode("loop", true);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Tick);
            timer.AutoReset = true;
            initial_point = pictureBox_human_move.Location;
            pictureBox_human_move.BringToFront();
        }

        #region//click
        private void pictureBox_humanPlayer_card_Click(object sender, EventArgs e)//点击picturebox事件
        {
            PictureBox pb = (PictureBox)sender;
            current_card = pb.Name;
            target_point = pb.Location;
            table.Get("1" + current_card + "1");//告诉table出牌
            pb.Name = "blank";
            human_picturebox_enablef();
            pb.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb.Name + ".jpg");

            Thread t = new Thread(Player_Play);
            t.Start();
        }

        private void game_start_Click(object sender, EventArgs e)//点击start事件
        {
            game_start.Visible = false;
            game_exit.Visible = false;
            my_initialize();

            whostart();
            fapai();
            my_show();
            Thread.Sleep(500);

            #region//根据谁开始初始化
            if (rightAIPlayer_start == true)
            {
                Thread tr = new Thread(leftAIPlayer_gamestart);
                tr.Start();
            }
            else
            {
                if (oppositeAIPlayer_start == true)
                {
                    Thread to = new Thread(oppositeAIPlayer_gamestart);
                    to.Start();
                }
                else
                {
                    if (leftAIPlayer_start == true)
                    {
                        Thread tl = new Thread(leftAIPlayer_gamestart);
                        tl.Start();
                    }
                    else
                    {
                        if (humanPlayer_start == true)
                        {
                            Thread t = new Thread(humanPlayer_gamestart);
                            t.Start();
                        }
                    }
                }
            }
            #endregion            
        }

        private void human_ask_Click(object sender, EventArgs e)//判断是碰杠胡过
        {
            Button button = (Button)sender;
            button.Name = "yes";
        }

        private void game_exit_Click(object sender, EventArgs e)
        {
            mediaplayer_backgroundmusic.Ctlcontrols.stop();
            Application.Exit();
        }
        #endregion

        #region//mouse enter leave
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
        #endregion

        private void timer_Tick(object sender, EventArgs e)//动画效果
        {
            System.Timers.Timer timer = (System.Timers.Timer)sender;
            timer.Stop();//开始的时候计时停止，防止出错

            pictureBox_human_move.Location = new Point(pictureBox_human_move.Location.X + D_MOVE_X, pictureBox_human_move.Location.Y + D_MOVE_Y);
            if (Math.Abs(pictureBox_human_move.Location.X - target_point.X) < 10)
            {
                pictureBox_human_move.Visible = false;
                pictureBox_human_move.Location = initial_point;
                timer.Stop();

                if (leftAIPlayerdone == true)
                {
                    humanPlayer_movedone.Set();
                }
                else
                {
                    if (humanPlayerdone == true)
                    {
                        rightAIPlayer_movedone.Set();
                    }
                    else
                    {
                        if (rightAIPlayerdone == true)
                        {
                            oppositeAIPlayer_movedone.Set();
                        }
                        else
                        {
                            if (oppositeAIPlayerdone == true)
                            {
                                leftAIPlayer_movedone.Set();
                            }
                        }
                    }
                }
            }
            else
            {
                timer.Start();
            }
        }

    }
}