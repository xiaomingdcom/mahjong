using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using ManageClass;

namespace mahjong
{
    class Player
    {
        #region //变量定义
        protected SoundPlayer sp;
        public AutoResetEvent movedone = new AutoResetEvent(false);
        public bool peng = false;//暂定不初始化
        public bool gang = false;
        public bool cancel = false;
        /// <summary>
        /// 下面是要初始化的
        /// </summary>
        public bool gameover = false;
        public int intgameover = 0;//gameover=3时游戏结束，三个人胡了
        public bool done = false;
        public int havePlayedcard_num = 0;//玩家已出牌计数
        public bool start = false;//从哪位玩家开始

        public PictureBox[] pb_card = new PictureBox[15];
        public PictureBox[] pb_havePlayed_card = new PictureBox[25];
        public Label money;
        #endregion

        public void picturebox_enablef()
        {
            for (int i = 1; i <= 14; i++)
            {
                pb_card[i].Enabled = false;
            }
        }

        public void picturebox_enablet()
        {
            for (int i = 1; i <= 14; i++)
            {
                if (pb_card[i].Name[0] != 'a')
                {
                    pb_card[i].Enabled = true;//start之前不可响应
                }
            }
        }

        private bool my_compare(string pb1, string pb2)//比较pb1和pb2，如果pb1>pb2，return true,小于等于return false                 
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

        public void show(int rangle, bool God_perspective)
        {
            string pb_name;
            for (int i = 1; i < 14; i++)
            {
                for (int j = 1; j <= 14 - i; j++)
                {
                    if (my_compare(pb_card[j].Name, pb_card[j + 1].Name))
                    {
                        pb_name = pb_card[j].Name;
                        pb_card[j].Name = pb_card[j + 1].Name;
                        pb_card[j + 1].Name = pb_name;
                    }
                }
            }

            for (int i = 1; i <= 14; i++)
            {
                pb_name = pb_card[i].Name;
                if (God_perspective == true)
                {
                    if (pb_name[0] == 'a')
                    {
                        pb_name = pb_name.Remove(0, 2);
                    }
                    Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_name + ".jpg");
                    picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                    pb_card[i].Image = picture_ro;
                }
                else
                {
                    if (pb_name[0] == 'a')
                    {
                        pb_name = pb_name.Remove(0, 2);
                        Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\" + pb_name + ".jpg");
                        picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                        pb_card[i].Image = picture_ro;
                    }
                    else
                    {
                        if (pb_name != "blank")
                        {
                            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\cardback.jpg");
                            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                            pb_card[i].Image = picture_ro;
                        }
                        else
                        {
                            Image picture_ro = Image.FromFile(Application.StartupPath + "\\picture\\blank.jpg");
                            picture_ro.RotateFlip(RotateFlipType.Rotate270FlipNone);//旋转
                            pb_card[i].Image = picture_ro;
                        }
                    }
                }

            }


        }

        public void peng_change(string current_card)
        {
            int j = 0;
            for (int i = 1; i <= 14 && j < 2; i++)
            {
                if (pb_card[i].Name == current_card)
                {
                    pb_card[i].Name = "ap" + pb_card[i].Name;
                    j++;
                }
            }
        }

        public void gang_change(string current_card)
        {
            int samecard = 0;
            for (int i = 1; i <= 14; i++)
            {
                if (pb_card[i].Name == current_card || pb_card[i].Name == "ap" + current_card)
                {
                    samecard++;
                    pb_card[i].Name = "ag" + current_card;
                    if (samecard == 4)
                    {
                        pb_card[i].Name = "blank";
                    }
                }
            }
        }

        public int samecard(string current_card)
        {
            int i = 0;
            for (i = 1; i <= 13; i++)
            {
                if (pb_card[i].Name == current_card)
                {
                    i++;
                }
            }
            return i;
        }

        public int havefoursamecard_true()
        {
            int i = 1;
            int j = 1;
            int human_gang_num = 0;
            int human_same_card = 0;
            string current_card_peng;
            for (i = 1; i <= 14; i++)
            {
                human_same_card = 0;
                current_card_peng = pb_card[i].Name;
                for (j = i; j <= 14; j++)
                {
                    if (pb_card[j].Name == pb_card[i].Name)
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

        public int peng_samecard(string current_card)//碰的个数
        {
            int i = 0;
            for (i = 1; i <= 13; i++)
            {
                if (pb_card[i].Name == "ap" + current_card)
                {
                    i++;
                }
            }
            return i;
        }

        public void havePlayed_cardnum_sub()
        {
            havePlayedcard_num--;
            pb_havePlayed_card[havePlayedcard_num].Visible = false;
        }

        public void havefoursamecard()
        {
            int i = 1;
            int j = 1;
            int human_gang_num = 0;
            int human_same_card = 0;
            string current_card_peng;
            //
            for (i = 1; i <= 14; i++)
            {
                human_same_card = 0;
                current_card_peng = pb_card[i].Name;
                for (j = i; j <= 14; j++)
                {
                    if (pb_card[j].Name == pb_card[i].Name)
                    {
                        human_same_card++;
                        if (human_same_card == 4)
                        {
                            for (int k = 1; k <= 14; k++)
                            {
                                if (pb_card[k].Name == current_card_peng)
                                {
                                    pb_card[k].Enabled = true;
                                    //human_guo.Enabled = true;
                                }
                            }
                            human_gang_num++;
                        }
                    }
                }
            }

        }
    }
}
