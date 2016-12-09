using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using ManageClass;
/// <summary>
///提醒时间可调
///又能碰又能杠怎么破
///switch超过14有错
///还是不能杠自己
///直接摸的时候能杠的情况
/// </summary>
namespace mahjong
{
    public partial class Form1 : Form
    {
        #region//变量定义    
        CTABLE table;
        CAI right_ai;
        CAI opposite_ai;
        CAI left_ai;

        protected bool God_perspective = true;//上帝视角
        protected bool AI_card_visible_true = true;
        protected string table_realize;
        protected string AI_want_realize;

        protected SoundPlayer sp;
        protected bool background_music_on = false;
        protected static int TIME_MAX = 100;

        System.Timers.Timer timer = new System.Timers.Timer(1);
        protected Point target_point = new Point(0, 0);//目标点
        protected Point target_size = new Point(0, 0);//目标大小
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

        /// <summary>
        /// 下面是要初始化的
        /// </summary>
        protected bool humanPlayer_gameover = false;
        protected bool rightAIPlayer_gameover = false;
        protected bool oppositeAIPlayer_gameover = false;
        protected bool leftAIPlayer_gameover = false;
        protected int intgameover = 0;//gameover=3时游戏结束，三个人胡了
        protected int all_haveplayer_card = 0;

        protected bool humanPlayerdone = false;
        protected bool rightAIPlayerdone = false;
        protected bool oppositeAIPlayerdone = false;
        protected bool leftAIPlayerdone = false;

        int humanPlayer_havePlayedcard_num = 0;//玩家已出牌计数
        int leftAIPlayer_havePlayedcard_num = 0;
        int rightAIPlayer_havePlayedcard_num = 0;
        int oppositeAIPlayer_havePlayedcard_num = 0;

        protected bool humanPlayer_start = false;//从哪位玩家开始
        bool rightAIPlayer_start = false;
        bool oppositeAIPlayer_start = false;
        bool leftAIPlayer_start = false;
        #endregion

        #region//get方法
        public PictureBox gethumanpb(int i)//返回return pictureBox_humanPlayer_cardi
        {
            return humanPlayer_card_switch(i);
        }

        public PictureBox gethumanhaveplayedpb(int i)
        {
            return humanPlayer_havePlayedcard_switch(i);
        }

        #endregion

        #region//系统函数
        protected PictureBox humanPlayer_havePlayedcard_switch(int num)
        {
            #region//switch
            switch (num)
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
                case 15:
                    return pictureBox_humanPlayer_havePlayedcard15;
                case 16:
                    return pictureBox_humanPlayer_havePlayedcard16;
                case 17:
                    return pictureBox_humanPlayer_havePlayedcard17;
                case 18:
                    return pictureBox_humanPlayer_havePlayedcard18;
                case 19:
                    return pictureBox_humanPlayer_havePlayedcard19;
                case 20:
                    return pictureBox_humanPlayer_havePlayedcard20;
                case 21:
                    return pictureBox_humanPlayer_havePlayedcard21;
                case 22:
                    return pictureBox_humanPlayer_havePlayedcard22;
                case 23:
                    return pictureBox_humanPlayer_havePlayedcard23;
                default:
                    return pictureBox_humanPlayer_havePlayedcard24;
            }
            #endregion
        }

        protected PictureBox humanPlayer_card_switch(int num)
        {
            #region//switch
            switch (num)
            {
                case 1:
                    return pictureBox_humanPlayer_card1;
                case 2:
                    return pictureBox_humanPlayer_card2;
                case 3:
                    return pictureBox_humanPlayer_card3;
                case 4:
                    return pictureBox_humanPlayer_card4;
                case 5:
                    return pictureBox_humanPlayer_card5;
                case 6:
                    return pictureBox_humanPlayer_card6;
                case 7:
                    return pictureBox_humanPlayer_card7;
                case 8:
                    return pictureBox_humanPlayer_card8;
                case 9:
                    return pictureBox_humanPlayer_card9;
                case 10:
                    return pictureBox_humanPlayer_card10;
                case 11:
                    return pictureBox_humanPlayer_card11;
                case 12:
                    return pictureBox_humanPlayer_card12;
                case 13:
                    return pictureBox_humanPlayer_card13;
                default:
                    return pictureBox_humanPlayer_card14;
            }
            #endregion
        }

        protected PictureBox rightAIPlayer_havePlayedcard_switch(int num)//超过24逗显示在24里面
        {
            #region//switch
            switch (num)
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
                case 15:
                    return pictureBox_rightAIPlayer_havePlayedcard15;
                case 16:
                    return pictureBox_rightAIPlayer_havePlayedcard16;
                case 17:
                    return pictureBox_rightAIPlayer_havePlayedcard17;
                case 18:
                    return pictureBox_rightAIPlayer_havePlayedcard18;
                case 19:
                    return pictureBox_rightAIPlayer_havePlayedcard19;
                case 20:
                    return pictureBox_rightAIPlayer_havePlayedcard20;
                case 21:
                    return pictureBox_rightAIPlayer_havePlayedcard21;
                case 22:
                    return pictureBox_rightAIPlayer_havePlayedcard22;
                case 23:
                    return pictureBox_rightAIPlayer_havePlayedcard23;
                default:
                    return pictureBox_rightAIPlayer_havePlayedcard24;
            }
            #endregion
        }

        protected PictureBox rightAIPlayer_card_switch(int num)
        {
            switch (num)
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
                    return pictureBox_rightAIPlayer_card9;
                case 10:
                    return pictureBox_rightAIPlayer_card10;
                case 11:
                    return pictureBox_rightAIPlayer_card11;
                case 12:
                    return pictureBox_rightAIPlayer_card12;
                case 13:
                    return pictureBox_rightAIPlayer_card13;
                default:
                    return pictureBox_rightAIPlayer_card14;
            }
        }

        protected PictureBox oppositeAIPlayer_havePlayedcard_switch(int num)
        {
            #region//switch
            switch (num)
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
                case 15:
                    return pictureBox_oppositeAIPlayer_havePlayedcard15;
                case 16:
                    return pictureBox_oppositeAIPlayer_havePlayedcard16;
                case 17:
                    return pictureBox_oppositeAIPlayer_havePlayedcard17;
                case 18:
                    return pictureBox_oppositeAIPlayer_havePlayedcard18;
                case 19:
                    return pictureBox_oppositeAIPlayer_havePlayedcard19;
                case 20:
                    return pictureBox_oppositeAIPlayer_havePlayedcard20;
                case 21:
                    return pictureBox_oppositeAIPlayer_havePlayedcard21;
                case 22:
                    return pictureBox_oppositeAIPlayer_havePlayedcard22;
                case 23:
                    return pictureBox_oppositeAIPlayer_havePlayedcard23;
                default:
                    return pictureBox_oppositeAIPlayer_havePlayedcard24;
            }
            #endregion
        }

        protected PictureBox oppositeAIPlayer_card_switch(int num)
        {
            switch (num)
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
                    return pictureBox_oppositeAIPlayer_card14;
            }
        }

        protected PictureBox leftAIPlayer_havePlayedcard_switch(int num)
        {
            #region//switch
            switch (num)
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
                case 15:
                    return pictureBox_leftAIPlayer_havePlayedcard15;
                case 16:
                    return pictureBox_leftAIPlayer_havePlayedcard16;
                case 17:
                    return pictureBox_leftAIPlayer_havePlayedcard17;
                case 18:
                    return pictureBox_leftAIPlayer_havePlayedcard18;
                case 19:
                    return pictureBox_leftAIPlayer_havePlayedcard19;
                case 20:
                    return pictureBox_leftAIPlayer_havePlayedcard20;
                case 21:
                    return pictureBox_leftAIPlayer_havePlayedcard21;
                case 22:
                    return pictureBox_leftAIPlayer_havePlayedcard22;
                case 23:
                    return pictureBox_leftAIPlayer_havePlayedcard23;
                default:
                    return pictureBox_leftAIPlayer_havePlayedcard24;
            }
            #endregion
        }

        protected PictureBox leftAIPlayer_card_switch(int num)
        {
            switch (num)
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
                    return pictureBox_leftAIPlayer_card14;
            }
        }


        protected void whostart()//从哪个玩家开始
        {
            humanPlayer_start = true;
        }

        protected void fapai()//发牌程序
        {
            PictureBox pb;
            string order;
            for (int i = 1; i < 13; i++)
            {
                pb = humanPlayer_card_switch(i);
                order = table.Deal(1);
                pb.Name = order.Substring(1, 2);

                pb = rightAIPlayer_card_switch(i);
                order = table.Deal(2);
                pb.Name = order.Substring(1, 2);
                right_ai.respond_table(order);

                pb = oppositeAIPlayer_card_switch(i);
                order = table.Deal(3);
                pb.Name = order.Substring(1, 2);
                opposite_ai.respond_table(order);

                pb = leftAIPlayer_card_switch(i);
                order = table.Deal(4);
                pb.Name = order.Substring(1, 2);
                left_ai.respond_table(order);
            }

            pictureBox_humanPlayer_card13.Name = table.Deal(1).Substring(1, 2);
            string str;
            str = table.Deal(2);
            str = str.Remove(3);
            str = str.Insert(3, "o");
            right_ai.respond_table(str);
            pictureBox_rightAIPlayer_card13.Name = str.Substring(1, 2);
            str = table.Deal(3);
            str = str.Remove(3);
            str = str.Insert(3, "o");
            opposite_ai.respond_table(str);
            pictureBox_oppositeAIPlayer_card13.Name = str.Substring(1, 2);
            str = table.Deal(4);
            str = str.Remove(3);
            str = str.Insert(3, "o");
            left_ai.respond_table(str);
            pictureBox_leftAIPlayer_card13.Name = str.Substring(1, 2);

            pictureBox_humanPlayer_card14.Name = "blank";
            pictureBox_rightAIPlayer_card14.Name = "blank";
            pictureBox_oppositeAIPlayer_card14.Name = "blank";
            pictureBox_leftAIPlayer_card14.Name = "blank";

            rightAIPlayer_show();
            oppositeAIPlayer_show();
            leftAIPlayer_show();
            my_show();
            all_haveplayer_card = 52;
        }

        protected void gameover()//游戏结束要执行的操作
        {
            humanPlayer_cancel = true;
            rightAIPlayer_cancel = true;
            oppositeAIPlayer_cancel = true;
            leftAIPlayer_cancel = true;
            card_haveused = true;
            //this.table.Dispose();
            //this.right_ai.Dispose();
            //this.opposite_ai.Dispose();
            //this.left_ai.Dispose();

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
            PictureBox pb;
            Image picture_ro;
            current_card = "blank";

            //出过得牌数置零
            all_haveplayer_card = 0;
            humanPlayer_havePlayedcard_num = 0;
            leftAIPlayer_havePlayedcard_num = 0;
            rightAIPlayer_havePlayedcard_num = 0;
            oppositeAIPlayer_havePlayedcard_num = 0;

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
            pictureBox_human_move.Visible = false;

            #region//AI牌的visible
            if (AI_card_visible_true)
            {
                for (int i = 0; i < 14; i++)
                {
                    pb = rightAIPlayer_card_switch(i);
                    pb.Visible = true;
                    pb = oppositeAIPlayer_card_switch(i);
                    pb.Visible = true;
                    pb = leftAIPlayer_card_switch(i);
                    pb.Visible = true;
                }
            }
            else
            {
                for (int i = 0; i < 14; i++)
                {
                    pb = rightAIPlayer_card_switch(i);
                    pb.Visible = false;
                    pb = oppositeAIPlayer_card_switch(i);
                    pb.Visible = false;
                    pb = leftAIPlayer_card_switch(i);
                    pb.Visible = false;
                }
            }
            #endregion

            #region//四个Player手牌只显示背面
            for (int i = 1; i <= 13; i++)
            {
                pb = humanPlayer_card_switch(i);
                pb.Image = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");

                pb = rightAIPlayer_card_switch(i);
                picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");
                picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                pb.Image = picture_ro;

                pb = oppositeAIPlayer_card_switch(i);
                picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");
                picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                pb.Image = picture_ro;

                pb = leftAIPlayer_card_switch(i);
                picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");
                picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                pb.Image = picture_ro;
            }
            #endregion

            #region//第十四张逗为blank
            picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\blank.jpg");
            pictureBox_humanPlayer_card14.Image = picture_ro;

            picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\blank.jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
            pictureBox_rightAIPlayer_card14.Image = picture_ro;

            picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\blank.jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);//旋转
            pictureBox_oppositeAIPlayer_card14.Image = picture_ro;

            picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\blank.jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate90FlipNone);//旋转
            pictureBox_leftAIPlayer_card14.Image = picture_ro;
            #endregion

            #region//四位玩家已打出的牌清零
            for (int i = 1; i <= 24; i++)
            {
                pb = humanPlayer_havePlayedcard_switch(i);
                pb.Visible = false;

                pb = rightAIPlayer_havePlayedcard_switch(i);
                pb.Visible = false;

                pb = oppositeAIPlayer_havePlayedcard_switch(i);
                pb.Visible = false;

                pb = leftAIPlayer_havePlayedcard_switch(i);
                pb.Visible = false;
            }
            #endregion
        }

        protected void my_show()//整理手牌并显示图片
        {
            string pb_name;
            PictureBox pb1;
            PictureBox pb2;
            for (int i = 1; i < 14; i++)
            {
                for (int j = 1; j <= 14 - i; j++)
                {
                    pb1 = humanPlayer_card_switch(j);
                    pb2 = humanPlayer_card_switch(j + 1);
                    if (my_compare(pb1.Name, pb2.Name))
                    {
                        pb_name = pb1.Name;
                        pb1.Name = pb2.Name;
                        pb2.Name = pb_name;
                    }
                }
            }

            for (int i = 1; i <= 14; i++)
            {
                pb1 = humanPlayer_card_switch(i);
                pb_name = pb1.Name;
                if (pb_name[0] == 'a')
                {
                    pb_name = pb_name.Remove(0, 2);
                }
                pb1.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_name + ".jpg");
            }
        }
        #endregion

        #region//human
        protected void human_mopai()//摸牌程序
        {
            if (all_haveplayer_card < 108)
            {
                all_haveplayer_card++;
                current_card = table.Deal(1).Substring(1, 2);
                table_realize = table.Realize();
                card_haveused = false;
                pictureBox_humanPlayer_card14.Name = current_card;
                pictureBox_humanPlayer_card14.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + current_card + ".jpg");
            }
            else
            {
                gameover();
            }
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
            table.Get("1" + current_card + "1");//告诉table出牌
            table_realize = table.Realize();

            card_haveused = false;//只要刚出牌，牌肯定没用过    
            humanPlayer_havePlayedcard_num++;
            PictureBox pb = humanPlayer_havePlayedcard_switch(humanPlayer_havePlayedcard_num);

            pictureBox_human_move.Height = pictureBox_humanPlayer_card1.Height;
            pictureBox_human_move.Width = pictureBox_humanPlayer_card1.Width;
            pictureBox_human_move.Name = current_card;
            pictureBox_human_move.Location = target_point;
            target_point = pb.Location;
            target_size.X = pb.Width;
            target_size.Y = pb.Height;

            pictureBox_human_move.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pictureBox_human_move.Name + ".jpg");
            pictureBox_human_move.Visible = true;
            D_MOVE_X = (target_point.X - pictureBox_human_move.Location.X) / 5;
            D_MOVE_Y = (target_point.Y - pictureBox_human_move.Location.Y) / 5;
            timer.Start();

            humanPlayer_movedone.WaitOne();

            #region//出牌
            pb.Name = current_card;
            pb.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + current_card + ".jpg");
            pb.Visible = true;
            sp = new SoundPlayer(Application.StartupPath + "\\sound\\humanPlayer\\" + current_card + ".wav");
            sp.PlaySync();
            my_show();
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

        protected void humanPlayer_peng_change()
        {
            PictureBox pb;
            int j = 0;
            for (int i = 1; i <= 14 && j < 2; i++)
            {
                pb = humanPlayer_card_switch(i);
                if (pb.Name == current_card)
                {
                    pb.Name = "ap" + pb.Name;
                    j++;
                }
            }
        }

        protected void humanPlayer_gang_change()
        {
            PictureBox pb;
            int samecard = 0;
            for (int i = 1; i <= 14; i++)
            {
                pb = humanPlayer_card_switch(i);
                if (pb.Name == current_card || pb.Name == "ap" + current_card)
                {
                    samecard++;
                    pb.Name = "ag" + current_card;
                    if (samecard == 4)
                    {
                        pb.Name = "blank";
                    }
                }
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

        protected int humanPlayer_havefoursamecard_true()
        {
            PictureBox pb;
            int i = 1;
            int j = 1;
            int human_gang_num = 0;
            int human_same_card = 0;
            string current_card_peng;
            for (i = 1; i <= 14; i++)
            {
                human_same_card = 0;
                pb = humanPlayer_card_switch(i);
                current_card_peng = pb.Name;
                for (j = i; j <= 14; j++)
                {
                    if (humanPlayer_card_switch(j).Name == pb.Name)
                    {
                        human_same_card++;
                        if (human_same_card == 4)
                        {
                            human_gang_num++;
                        }
                    }
                }
            }
            return human_gang_num;
        }

        protected void humanPlayer_havefoursamecard()
        {
            PictureBox pb;
            PictureBox pb_c;
            int i = 1;
            int j = 1;
            int human_gang_num = 0;
            int human_same_card = 0;
            string current_card_peng;
            //
            for (i = 1; i <= 14; i++)
            {
                human_same_card = 0;
                pb = humanPlayer_card_switch(i);
                current_card_peng = pb.Name;
                for (j = i; j <= 14; j++)
                {
                    if (humanPlayer_card_switch(j).Name == pb.Name)
                    {
                        human_same_card++;
                        if (human_same_card == 4)
                        {
                            for (int k = 1; k <= 14; k++)
                            {
                                pb_c = humanPlayer_card_switch(k);
                                if (pb_c.Name == current_card_peng)
                                {
                                    pb_c.Enabled = true;
                                    human_guo.Enabled = true;
                                }
                            }
                            human_gang_num++;
                        }
                    }
                }
            }
            for (i = 0; i < TIME_MAX; i++)
            {
                Thread.Sleep(500);
                if (human_gang.Name == "no" || human_guo.Name == "yes")
                {
                    break;
                }
                if (i % 10 == 0 && i > 10)//一段时间不点，提醒
                {
                    remind_play();
                }
            }
            if (i == TIME_MAX)//长时间不出即为过
            {
                human_gang.Name = "no";
                human_guo.Enabled = false;
                human_picturebox_enablef();
            }
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

        protected void humanPlayer_num_sub()
        {
            PictureBox pb = humanPlayer_havePlayedcard_switch(humanPlayer_havePlayedcard_num);
            humanPlayer_havePlayedcard_num--;
            pb.Visible = false;
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
                    humanPlayer_peng_change();
                    pictureBox_humanPlayer_card14.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + current_card + ".jpg");
                    pictureBox_humanPlayer_card14.Name = "ap" + current_card;//碰的牌先放在14   
                    my_show();//之后要加指示那张牌是碰的/杠的                
                }
                if (human_gang.Name == "yes")
                {
                    human_gang.Name = "no";
                    humanPlayer_gang_change();
                    my_show();//之后要加指示那张牌是碰的/杠的                
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
                //
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
            if (all_haveplayer_card < 108)
            {
                all_haveplayer_card++;
                current_card = table.Deal(2).Substring(1, 2);
                table_realize = table.Realize();//摸的牌
                card_haveused = false;
                pictureBox_rightAIPlayer_card14.Name = current_card;
                if (God_perspective == true)
                {
                    Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + current_card + ".jpg");
                    picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                    pictureBox_rightAIPlayer_card14.Image = picture_ro;
                }
                else
                {
                    Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");
                    picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                    pictureBox_rightAIPlayer_card14.Image = picture_ro;
                }
            }
            else
            {
                gameover();
            }
        }

        protected void rightAIPlayer_chupai()
        {
            card_haveused = false;//只要刚出牌，牌肯定没用过
            table.Get(AI_want_realize);
            table_realize = table.Realize();
            current_card = table_realize.Substring(1, 2);//要出的牌

            PictureBox pb;
            PictureBox pb_haveplayed;
            Image picture_ro;
            for (int i = 14; i >= 1; i--)
            {
                pb = rightAIPlayer_card_switch(i);
                if (pb.Name == current_card)
                {
                    pb.Name = "blank";
                    if (humanPlayer_gameover == false)//human和牌之后不再显示任何动画
                    {
                        picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb.Name + ".jpg");
                        picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                        pb.Image = picture_ro;

                        pictureBox_human_move.Location = pb.Location;
                        pictureBox_human_move.Height = pb.Height;
                        pictureBox_human_move.Width = pb.Width;
                    }
                    break;
                }
            }

            rightAIPlayer_havePlayedcard_num++;
            pb_haveplayed = rightAIPlayer_havePlayedcard_switch(rightAIPlayer_havePlayedcard_num);
            if (humanPlayer_gameover == false)//human和牌之后不再显示任何动画
            {
                pictureBox_human_move.Name = current_card;
                picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pictureBox_human_move.Name + ".jpg");
                picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                pictureBox_human_move.Image = picture_ro;
                pictureBox_human_move.Visible = true;

                target_point = pb_haveplayed.Location;
                target_size.X = pb_haveplayed.Width;
                target_size.Y = pb_haveplayed.Height;

                D_MOVE_X = (target_point.X - pictureBox_human_move.Location.X) / 10;
                D_MOVE_Y = (target_point.Y - pictureBox_human_move.Location.Y) / 10;
                timer.Start();

                rightAIPlayer_movedone.WaitOne();
            }
            rightAIPlayer_show();
            pb_haveplayed.Name = current_card;
            picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_haveplayed.Name + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
            pb_haveplayed.Image = picture_ro;
            pb_haveplayed.Visible = true;
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
            string pb_name;
            PictureBox pb1;
            PictureBox pb2;
            for (int i = 1; i < 14; i++)
            {
                for (int j = 1; j <= 14 - i; j++)
                {
                    pb1 = rightAIPlayer_card_switch(j);
                    pb2 = rightAIPlayer_card_switch(j + 1);
                    if (my_compare(pb1.Name, pb2.Name))
                    {
                        pb_name = pb1.Name;
                        pb1.Name = pb2.Name;
                        pb2.Name = pb_name;
                    }
                }
            }

            for (int i = 1; i <= 14; i++)
            {
                pb1 = rightAIPlayer_card_switch(i);
                pb_name = pb1.Name;
                if (God_perspective == true)
                {
                    if (pb_name[0] == 'a')
                    {
                        pb_name = pb_name.Remove(0, 2);
                    }
                    Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_name + ".jpg");
                    picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                    pb1.Image = picture_ro;
                }
                else
                {
                    if (pb_name[0] == 'a')
                    {
                        pb_name = pb_name.Remove(0, 2);
                        Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_name + ".jpg");
                        picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                        pb1.Image = picture_ro;
                    }
                    else
                    {
                        if (pb_name != "blank")
                        {
                            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");
                            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                            pb1.Image = picture_ro;
                        }
                        else
                        {
                            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\blank.jpg");
                            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                            pb1.Image = picture_ro;
                        }
                    }
                }

            }
        }

        protected void rightAIPlayer_peng_change()
        {
            PictureBox pb;
            int j = 0;
            for (int i = 1; i <= 14 && j <= 2; i++)
            {
                pb = rightAIPlayer_card_switch(i);
                if (pb.Name == current_card)
                {
                    pb.Name = "ap" + pb.Name;
                    j++;
                }
            }
        }

        protected void rightAIPlayer_gang_change()
        {
            PictureBox pb;
            for (int i = 1; i <= 14; i++)
            {
                pb = rightAIPlayer_card_switch(i);
                if (pb.Name == current_card)
                {
                    pb.Name = "ag" + pb.Name;
                }
            }
        }

        protected void rightAIPlayer_peng_gang()//根据right是碰还是杠执行的操作
        {
            if (rightAIPlayer_peng == true)
            {
                pictureBox_rightAIPlayer_card14.Name = current_card;
                rightAIPlayer_peng_change();//14张
                rightAIPlayer_peng = false;
                rightAIPlayer_show();
            }
            if (rightAIPlayer_gang == true)
            {
                rightAIPlayer_gang_change();//13张
                rightAIPlayer_show();
                rightAIPlayer_mopai();
                rightAIPlayer_gang = false;
            }
            if (rightAIPlayer_peng == false && rightAIPlayer_gang == false)
            {
                rightAIPlayer_mopai();
            }
        }

        protected void rightAIPlayer_num_sub()
        {
            PictureBox pb = rightAIPlayer_havePlayedcard_switch(rightAIPlayer_havePlayedcard_num);
            rightAIPlayer_havePlayedcard_num--;
            pb.Visible = false;
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
                if (card_haveused == false)
                {
                    rightAIPlayer_chupai();
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
            if (all_haveplayer_card < 108)
            {
                all_haveplayer_card++;
                current_card = table.Deal(3).Substring(1, 2);
                table_realize = table.Realize();
                card_haveused = false;
                pictureBox_oppositeAIPlayer_card14.Name = current_card;
                if (God_perspective == true)
                {
                    Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + current_card + ".jpg");
                    picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);//旋转
                    pictureBox_oppositeAIPlayer_card14.Image = picture_ro;
                }
                else
                {
                    Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");
                    picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);//旋转
                    pictureBox_oppositeAIPlayer_card14.Image = picture_ro;
                }
            }
            else
            {
                gameover();
            }
        }

        protected void oppositeAIPlayer_chupai()
        {
            card_haveused = false;//只要刚出牌，牌肯定没用过
            table.Get(AI_want_realize);
            table_realize = table.Realize();
            current_card = table_realize.Substring(1, 2);

            PictureBox pb;
            PictureBox pb_haveplayed;
            Image picture_ro;
            for (int i = 14; i >= 1; i--)
            {
                pb = oppositeAIPlayer_card_switch(i);
                if (pb.Name == current_card)
                {
                    pb.Name = "blank";
                    if (humanPlayer_gameover == false)
                    {
                        picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb.Name + ".jpg");
                        picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);//旋转
                        pb.Image = picture_ro;
                        pictureBox_human_move.Location = pb.Location;
                        pictureBox_human_move.Height = pb.Height;
                        pictureBox_human_move.Width = pb.Width;
                    }
                    break;
                }
            }

            oppositeAIPlayer_havePlayedcard_num++;
            pb_haveplayed = oppositeAIPlayer_havePlayedcard_switch(oppositeAIPlayer_havePlayedcard_num);
            if (humanPlayer_gameover == false)
            {
                pictureBox_human_move.Name = current_card;
                picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pictureBox_human_move.Name + ".jpg");
                picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pictureBox_human_move.Image = picture_ro;
                pictureBox_human_move.Visible = true;

                target_point = pb_haveplayed.Location;
                target_size.X = pb_haveplayed.Width;
                target_size.Y = pb_haveplayed.Height;


                D_MOVE_X = (target_point.X - pictureBox_human_move.Location.X) / 10;
                D_MOVE_Y = (target_point.Y - pictureBox_human_move.Location.Y) / 10;
                timer.Start();

                oppositeAIPlayer_movedone.WaitOne();
            }
            oppositeAIPlayer_show();
            pb_haveplayed.Name = current_card;
            picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_haveplayed.Name + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pb_haveplayed.Image = picture_ro;
            pb_haveplayed.Visible = true;
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
            string pb_name;
            PictureBox pb1;
            PictureBox pb2;
            for (int i = 1; i < 14; i++)
            {
                for (int j = 1; j <= 14 - i; j++)
                {
                    pb1 = oppositeAIPlayer_card_switch(j);
                    pb2 = oppositeAIPlayer_card_switch(j + 1);
                    if (my_compare(pb1.Name, pb2.Name))
                    {
                        pb_name = pb1.Name;
                        pb1.Name = pb2.Name;
                        pb2.Name = pb_name;
                    }
                }
            }

            for (int i = 1; i <= 14; i++)
            {
                pb1 = oppositeAIPlayer_card_switch(i);
                pb_name = pb1.Name;
                if (God_perspective == true)
                {
                    if (pb_name[0] == 'a')
                    {
                        pb_name = pb_name.Remove(0, 2);
                    }
                    Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_name + ".jpg");
                    picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);//旋转
                    pb1.Image = picture_ro;
                }
                else
                {
                    if (pb_name[0] == 'a')
                    {
                        pb_name = pb_name.Remove(0, 2);
                        Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_name + ".jpg");
                        picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);//旋转
                        pb1.Image = picture_ro;
                    }
                    else
                    {
                        if (pb_name != "blank")
                        {
                            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");
                            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                            pb1.Image = picture_ro;
                        }
                        else
                        {
                            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\blank.jpg");
                            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                            pb1.Image = picture_ro;
                        }
                    }
                }
            }
        }

        protected void oppositeAIPlayer_peng_change()
        {
            PictureBox pb;
            int j = 0;
            for (int i = 1; i <= 14 && j <= 2; i++)
            {
                pb = oppositeAIPlayer_card_switch(i);
                if (pb.Name == current_card)
                {
                    pb.Name = "ap" + pb.Name;
                    j++;
                }
            }
        }

        protected void oppositeAIPlayer_gang_change()
        {
            PictureBox pb;
            for (int i = 1; i <= 14; i++)
            {
                pb = oppositeAIPlayer_card_switch(i);
                if (pb.Name == current_card)
                {
                    pb.Name = "ag" + pb.Name;
                }
            }
        }

        protected void oppositeAIPlayer_peng_gang()
        {
            if (oppositeAIPlayer_peng == true)
            {
                pictureBox_oppositeAIPlayer_card14.Name = current_card;
                oppositeAIPlayer_peng_change();
                oppositeAIPlayer_peng = false;
                oppositeAIPlayer_show();
            }
            if (oppositeAIPlayer_gang == true)
            {
                oppositeAIPlayer_gang_change();
                oppositeAIPlayer_gang = false;
                oppositeAIPlayer_show();
                oppositeAIPlayer_mopai();
            }
            if (oppositeAIPlayer_peng == false && oppositeAIPlayer_gang == false)
            {
                oppositeAIPlayer_mopai();
            }
        }

        protected void oppositeAIPlayer_num_sub()
        {
            PictureBox pb = oppositeAIPlayer_havePlayedcard_switch(oppositeAIPlayer_havePlayedcard_num);
            oppositeAIPlayer_havePlayedcard_num--;
            pb.Visible = false;
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
                if (card_haveused == false)
                {
                    oppositeAIPlayer_chupai();

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
            if (all_haveplayer_card < 108)
            {
                all_haveplayer_card++;
                current_card = table.Deal(4).Substring(1, 2);
                table_realize = table.Realize();
                card_haveused = false;
                pictureBox_leftAIPlayer_card14.Name = current_card;
                if (God_perspective == true)
                {
                    Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + current_card + ".jpg");
                    picture_ro.RotateFlip(RotateFlipType.Rotate90FlipNone);//旋转
                    pictureBox_leftAIPlayer_card14.Image = picture_ro;
                }
                else
                {
                    Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");
                    picture_ro.RotateFlip(RotateFlipType.Rotate90FlipNone);//旋转
                    pictureBox_leftAIPlayer_card14.Image = picture_ro;
                }
            }
            else
            {
                gameover();
            }
        }

        protected void leftAIPlayer_chupai()
        {
            card_haveused = false;//只要刚出牌，牌肯定没用过
            table.Get(AI_want_realize);
            table_realize = table.Realize();
            current_card = table_realize.Substring(1, 2);

            PictureBox pb;
            PictureBox pb_haveplayed;
            Image picture_ro;
            for (int i = 14; i >= 1; i--)
            {
                pb = leftAIPlayer_card_switch(i);
                if (pb.Name == current_card)
                {
                    pb.Name = "blank";
                    if (humanPlayer_gameover == false)
                    {
                        picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb.Name + ".jpg");
                        picture_ro.RotateFlip(RotateFlipType.Rotate180FlipNone);//旋转
                        pb.Image = picture_ro;
                        pictureBox_human_move.Location = pb.Location;
                        pictureBox_human_move.Height = pb.Height;
                        pictureBox_human_move.Width = pb.Width;
                    }
                    break;
                }
            }

            leftAIPlayer_havePlayedcard_num++;
            pb_haveplayed = leftAIPlayer_havePlayedcard_switch(leftAIPlayer_havePlayedcard_num);
            if (humanPlayer_gameover == false)
            {
                pictureBox_human_move.Name = current_card;
                picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pictureBox_human_move.Name + ".jpg");
                picture_ro.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox_human_move.Image = picture_ro;
                pictureBox_human_move.Visible = true;

                target_point = pb_haveplayed.Location;
                target_size.X = pb_haveplayed.Width;
                target_size.Y = pb_haveplayed.Height;

                D_MOVE_X = (target_point.X - pictureBox_human_move.Location.X) / 10;
                D_MOVE_Y = (target_point.Y - pictureBox_human_move.Location.Y) / 10;
                timer.Start();

                leftAIPlayer_movedone.WaitOne();
            }
            leftAIPlayer_show();
            pb_haveplayed.Name = current_card;
            picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_haveplayed.Name + ".jpg");
            picture_ro.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pb_haveplayed.Image = picture_ro;
            pb_haveplayed.Visible = true;
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
            string pb_name;
            PictureBox pb1;
            PictureBox pb2;
            for (int i = 1; i < 14; i++)
            {
                for (int j = 1; j <= 14 - i; j++)
                {
                    pb1 = leftAIPlayer_card_switch(j);
                    pb2 = leftAIPlayer_card_switch(j + 1);
                    if (my_compare(pb1.Name, pb2.Name))
                    {
                        pb_name = pb1.Name;
                        pb1.Name = pb2.Name;
                        pb2.Name = pb_name;
                    }
                }
            }

            for (int i = 1; i <= 14; i++)
            {
                pb1 = leftAIPlayer_card_switch(i);
                pb_name = pb1.Name;
                if (God_perspective == true)
                {
                    if (pb_name[0] == 'a')
                    {
                        pb_name = pb_name.Remove(0, 2);
                    }
                    Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_name + ".jpg");
                    picture_ro.RotateFlip(RotateFlipType.Rotate90FlipNone);//旋转
                    pb1.Image = picture_ro;
                }
                else
                {
                    if (pb_name[0] == 'a')
                    {
                        pb_name = pb_name.Remove(0, 2);
                        Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_name + ".jpg");
                        picture_ro.RotateFlip(RotateFlipType.Rotate90FlipNone);//旋转
                        pb1.Image = picture_ro;
                    }
                    else
                    {
                        if (pb_name != "blank")
                        {
                            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");
                            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                            pb1.Image = picture_ro;
                        }
                        else
                        {
                            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\blank.jpg");
                            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                            pb1.Image = picture_ro;
                        }
                    }
                }
            }
        }

        protected void leftAIPlayer_peng_change()
        {
            PictureBox pb;
            int j = 0;
            for (int i = 1; i <= 14 && j <= 2; i++)
            {
                pb = leftAIPlayer_card_switch(i);
                if (pb.Name == current_card)
                {
                    pb.Name = "ap" + pb.Name;
                    j++;
                }
            }
        }

        protected void leftAIPlayer_gang_change()
        {
            PictureBox pb;
            for (int i = 1; i <= 14; i++)
            {
                pb = oppositeAIPlayer_card_switch(i);
                if (pb.Name == current_card)
                {
                    pb.Name = "ag" + pb.Name;
                }
            }
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

        protected void leftAIPlayer_num_sub()
        {
            PictureBox pb = leftAIPlayer_havePlayedcard_switch(leftAIPlayer_havePlayedcard_num);
            leftAIPlayer_havePlayedcard_num--;
            pb.Visible = false;
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
                if (card_haveused == false)
                {
                    leftAIPlayer_chupai();

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
            AI_want_realize = right_ai.respond_table(table_realize);//告诉ai出牌，返回ai想法

            #region//胡
            if (AI_want_realize[3] == '2') //胡
            {
                card_haveused = true;
                pictureBox_rightAIPlayer_card14.Name = current_card;
                rightAIPlayer_show();
                table.Get(AI_want_realize);
                table_realize = table.Realize();

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

            #region//碰/杠
            if (AI_want_realize[3] == '4')//选择碰
            {
                card_haveused = true;
                pictureBox_rightAIPlayer_card14.Name = current_card;
                table.Get(AI_want_realize);
                table_realize = table.Realize();

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\peng.wav");
                sp.PlaySync();
                rightAIPlayer_peng = true;

                //自己线程的话不出牌，相当于摸牌
                if (leftAIPlayerdone == true)//当前是主线程（human）
                {
                    humanPlayer_num_sub();
                }
                if (rightAIPlayerdone == true)//当前是opposite线程
                {
                    oppositeAIPlayer_num_sub();

                    rightAIPlayer_play();
                    oppositeAIPlayer_play(); ;
                }
                if (oppositeAIPlayerdone == true)//当前是left线程
                {
                    leftAIPlayer_num_sub();

                    rightAIPlayer_play();
                    oppositeAIPlayer_play();
                    leftAIPlayer_play();
                }
            }

            if (AI_want_realize[3] == '3' || AI_want_realize[3] == '5' || AI_want_realize[3] == '6')//选择杠
            {
                card_haveused = true;
                table.Get(AI_want_realize);
                table_realize = table.Realize();

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\rightAIPlayer\\gang.wav");
                sp.PlaySync();
                rightAIPlayer_gang = true;

                if (leftAIPlayerdone == true)//当前是主线程（human）
                {
                    humanPlayer_num_sub();
                }
                if (humanPlayerdone == true)//right回合
                {
                    rightAIPlayer_play();
                }
                if (rightAIPlayerdone == true)//当前是opposite线程
                {
                    oppositeAIPlayer_num_sub();

                    rightAIPlayer_play();
                    oppositeAIPlayer_play(); ;
                }
                if (oppositeAIPlayerdone == true)//当前是left线程
                {
                    leftAIPlayer_num_sub();

                    rightAIPlayer_play();
                    oppositeAIPlayer_play();
                    leftAIPlayer_play();
                }
            }

            #endregion
        }

        protected void ask_oppositeAIPlayer()
        {
            AI_want_realize = opposite_ai.respond_table(table_realize);//告诉ai出牌，返回ai想法

            #region//胡
            if (AI_want_realize[3] == '2')//胡
            {
                card_haveused = true;
                pictureBox_oppositeAIPlayer_card14.Name = current_card;
                oppositeAIPlayer_show();
                table.Get(AI_want_realize);
                table_realize = table.Realize();

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

            if (AI_want_realize[3] == '4')//选择碰
            {
                card_haveused = true;
                pictureBox_oppositeAIPlayer_card14.Name = current_card;
                table.Get(AI_want_realize);
                table_realize = table.Realize();

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\peng.wav");
                sp.PlaySync();
                oppositeAIPlayer_peng = true;

                if (leftAIPlayerdone == true)//当前是主线程（human）
                {
                    humanPlayer_num_sub();
                    rightAIPlayer_cancel = true;
                }
                if (humanPlayerdone == true)//当前是right线程
                {
                    rightAIPlayer_num_sub();
                }
                if (oppositeAIPlayerdone == true)//当前是left线程
                {
                    leftAIPlayer_num_sub();

                    oppositeAIPlayer_play();
                    leftAIPlayer_play();
                }
            }

            if (AI_want_realize[3] == '3' || AI_want_realize[3] == '5' || AI_want_realize[3] == '6')//选择杠
            {
                card_haveused = true;
                table.Get(AI_want_realize);
                table_realize = table.Realize();

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\oppositeAIPlayer\\gang.wav");
                sp.PlaySync();
                oppositeAIPlayer_gang = true;
                oppositeAIPlayer_mopai();

                if (leftAIPlayerdone == true)//当前是主线程（human）
                {
                    humanPlayer_num_sub();
                    rightAIPlayer_cancel = true;
                }
                if (humanPlayerdone == true)//当前是right线程
                {
                    rightAIPlayer_num_sub();
                }
                if (oppositeAIPlayerdone == true)//当前是left线程
                {
                    leftAIPlayer_num_sub();

                    oppositeAIPlayer_play();
                    leftAIPlayer_play();
                }
                if (rightAIPlayerdone == true)//opposite回合
                {
                    oppositeAIPlayer_play();
                }
            }
            #endregion
        }

        protected void ask_leftAIPlayer()
        {
            AI_want_realize = left_ai.respond_table(table_realize);//告诉ai出牌，返回ai想法

            #region//胡
            if (AI_want_realize[3] == '2')//胡
            {
                card_haveused = true;
                pictureBox_leftAIPlayer_card14.Name = current_card;
                leftAIPlayer_show();
                table.Get(AI_want_realize);
                table_realize = table.Realize();

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
            if (AI_want_realize[3] == '4')//选择碰
            {
                card_haveused = true;
                pictureBox_leftAIPlayer_card14.Name = current_card;
                leftAIPlayer_show();
                table.Get(AI_want_realize);
                table_realize = table.Realize();

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\peng.wav");
                sp.PlaySync();
                leftAIPlayer_peng = true;

                if (leftAIPlayerdone == true)//当前是主线程（human）
                {
                    humanPlayer_num_sub();
                    rightAIPlayer_cancel = true;
                    oppositeAIPlayer_cancel = true;

                }
                if (humanPlayerdone == true)//当前是right线程
                {
                    rightAIPlayer_num_sub();
                    oppositeAIPlayer_cancel = true;
                }
                if (rightAIPlayerdone == true)//当前是opposite线程
                {
                    oppositeAIPlayer_num_sub();
                }
            }

            if (AI_want_realize[3] == '3' || AI_want_realize[3] == '5' || AI_want_realize[3] == '6')//选择杠
            {
                card_haveused = true;
                table.Get(AI_want_realize);
                table_realize = table.Realize();

                sp = new SoundPlayer(Application.StartupPath + "\\sound\\leftAIPlayer\\gang.wav");
                sp.PlaySync();
                leftAIPlayer_gang = true;
                leftAIPlayer_mopai();

                if (leftAIPlayerdone == true)//当前是主线程（human）
                {
                    humanPlayer_num_sub();
                    rightAIPlayer_cancel = true;
                    oppositeAIPlayer_cancel = true;

                }
                if (humanPlayerdone == true)//当前是right线程
                {
                    rightAIPlayer_num_sub();

                    oppositeAIPlayer_cancel = true;
                }
                if (rightAIPlayerdone == true)//当前是opposite线程
                {
                    oppositeAIPlayer_num_sub();
                }
                if (oppositeAIPlayerdone == true)//left回合
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

            bool ishu = table.HumanIsHu(1, current_card);
            if (ishu)//能胡
            {
                human_hu.Enabled = true;
                human_guo.Enabled = true;
            }

            if (leftAIPlayerdone == false && samecard == 2)//&&自己摸牌不能碰&&能杠,>=
            {
                human_peng.Enabled = true;
                human_guo.Enabled = true;
            }

            if (samecard == 3)//能直杠或暗杠或碰
            {
                if (leftAIPlayerdone == false)
                {
                    human_peng.Enabled = true;
                }
                human_gang.Enabled = true;
                human_guo.Enabled = true;

            }
            if (peng_samecard == 3 || humanPlayer_havefoursamecard_true()>0)
            {
                human_gang.Enabled = true;
                human_guo.Enabled = true;
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
                card_haveused = true;
                pictureBox_humanPlayer_card14.Name = current_card;
                my_show();

                table.Get("1" + current_card + "2");
                table_realize = table.Realize();
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
                        rightAIPlayer_play();
                        oppositeAIPlayer_play();
                        leftAIPlayer_play();
                        human_play();
                    }
                }
            }
            #endregion

            #region//碰 杠
            if (human_peng.Name == "yes")//碰
            {
                card_haveused = true;
                if (human_peng.Name == "yes")
                {
                    table.Get("1" + current_card + "7");
                    table_realize = table.Realize();
                    sp = new SoundPlayer(Application.StartupPath + "\\sound\\humanPlayer\\peng.wav");
                    sp.PlaySync();
                }
                if (humanPlayerdone == true)//当前是right线程
                {
                    rightAIPlayer_num_sub();

                    oppositeAIPlayer_cancel = true;
                    leftAIPlayer_cancel = true;
                }
                if (rightAIPlayerdone == true)//opposite
                {
                    oppositeAIPlayer_num_sub();

                    leftAIPlayer_cancel = true;
                }
                if (oppositeAIPlayerdone == true)//left
                {
                    leftAIPlayer_num_sub();
                }
                if (leftAIPlayerdone == true)//human回合
                {
                    human_play();
                }
            }

            if (human_gang.Name == "yes")
            {
                card_haveused = true;
                if (leftAIPlayerdone == true)//human回合,暗杠
                {
                    if (peng_samecard == 3)
                    {
                        table.Get("1" + current_card + "8");//弯杠
                        table_realize = table.Realize();
                    }
                    if (humanPlayer_havefoursamecard_true()>0)
                    {
                        if (humanPlayer_havefoursamecard_true() > 1)
                        {
                            humanPlayer_havefoursamecard();//让能杠的能点
                        }
                        table.Get("1" + current_card + "3");
                        table_realize = table.Realize();
                    }
                }
                else
                {
                    table.Get("1" + current_card + "9");//杠直
                    table_realize = table.Realize();
                }
                sp = new SoundPlayer(Application.StartupPath + "\\sound\\humanPlayer\\gang.wav");
                sp.PlaySync();

                if (humanPlayerdone == true)//当前是right线程
                {
                    rightAIPlayer_num_sub();

                    oppositeAIPlayer_cancel = true;
                    leftAIPlayer_cancel = true;
                }
                if (rightAIPlayerdone == true)//opposite
                {
                    oppositeAIPlayer_num_sub();

                    leftAIPlayer_cancel = true;
                }
                if (oppositeAIPlayerdone == true)//left
                {
                    leftAIPlayer_num_sub();
                }
                if (leftAIPlayerdone == true)//human回合
                {
                    human_play();
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
            if (human_gang.Name == "no")
            {
                current_card = pb.Name;
                target_point = pb.Location;
                pb.Name = "blank";
                human_picturebox_enablef();
                pb.Image = Image.FromFile(Application.StartupPath + "\\picture\\" + pb.Name + ".jpg");

                Thread t = new Thread(Player_Play);
                t.Start();
            }
            else
            {
                human_gang.Name = "no";
                current_card = pb.Name;
                humanPlayer_gang_change();
                my_show();
            }
        }

        private void game_start_Click(object sender, EventArgs e)//点击start事件
        {
            game_start.Visible = false;
            game_exit.Visible = false;
            my_initialize();
            this.table = new CTABLE();
            this.right_ai = new CAI(2);
            this.opposite_ai = new CAI(3);
            this.left_ai = new CAI(4);

            whostart();
            fapai();

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

        private void background_music_Click(object sender, EventArgs e)
        {
            if (background_music_on == false)
            {
                background_music_on = true;
                mediaplayer_backgroundmusic.Ctlcontrols.play();
                background_music.Text = "on";
            }
            else
            {
                background_music_on = false;
                background_music.Text = "off";
                mediaplayer_backgroundmusic.Ctlcontrols.stop();
            }
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

        private void background_music_MouseEnter(object sender, EventArgs e)
        {
            background_music.FlatStyle = FlatStyle.Standard;
            if (background_music_on == false)
            {
                background_music.Text = "off";
            }
            else
            {
                background_music.Text = "on";
            }
        }

        private void background_music_MouseLeave(object sender, EventArgs e)
        {
            background_music.FlatStyle = FlatStyle.Flat;
            background_music.Text = "";
        }
        #endregion

        private void timer_Tick(object sender, EventArgs e)//动画效果
        {
            System.Timers.Timer timer = (System.Timers.Timer)sender;
            timer.Stop();//开始的时候计时停止，防止出错

            pictureBox_human_move.Location = new Point(pictureBox_human_move.Location.X + D_MOVE_X, pictureBox_human_move.Location.Y + D_MOVE_Y);
            //pictureBox_human_move
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