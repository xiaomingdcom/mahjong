using Microsoft.VisualStudio.TestTools.UnitTesting;
using mahjong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mahjong.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        Form1 fo1 = new Form1();//实例化Form1,名字为fo1

        [TestMethod()]
        public void fapaiTest()
        {
            fo1.fapai();//先调用发牌函数
            Assert.IsTrue(fo1.gethumanpb1().Name == "t1", "第1张牌发错");//如果发的牌和预期不同，结束程序并输出第1张牌发错
            Assert.IsTrue(fo1.gethumanpb2().Name == "t1", "第2张牌发错");//以下类似
            Assert.IsTrue(fo1.gethumanpb3().Name == "t1", "第3张牌发错");
            Assert.IsTrue(fo1.gethumanpb4().Name == "t1", "第4张牌发错");
            Assert.IsTrue(fo1.gethumanpb5().Name == "t1", "第5张牌发错");
            Assert.IsTrue(fo1.gethumanpb6().Name == "t1", "第6张牌发错");
            Assert.IsTrue(fo1.gethumanpb7().Name == "t1", "第7张牌发错");
            Assert.IsTrue(fo1.gethumanpb8().Name == "t1", "第8张牌发错");
            Assert.IsTrue(fo1.gethumanpb9().Name == "t1", "第9张牌发错");
            Assert.IsTrue(fo1.gethumanpb10().Name == "t1", "第10张牌发错");
            Assert.IsTrue(fo1.gethumanpb11().Name == "t1", "第11张牌发错");
            Assert.IsTrue(fo1.gethumanpb12().Name == "t1", "第12张牌发错");
            Assert.IsTrue(fo1.gethumanpb13().Name == "t1", "第13张牌发错");
            Assert.IsTrue(fo1.gethumanpb14().Name == "blank", "第14张牌发错");
        }

        [TestMethod()]
        public void whostartTest()
        {
            fo1.whostart();//先调用指定谁先开始的程序
            Assert.IsTrue(fo1.humanPlayer_start == true, "开始失败");//如果先开始的人与预期不同，结束程序并输出开始失败
        }

        [TestMethod()]
        public void human_mopaiTest()
        {
            fo1.human_mopai();//先调用人类玩家摸牌的程序
            Assert.IsTrue(fo1.gethumanpb14().Name == "w1", "摸牌失败");//如果摸牌与预期不同，结束程序并输出摸牌失败
        }

        [TestMethod()]
        public void humanPlayer_chupaiTest()
        {
            fo1.humanPlayer_chupai("t1",1);//先调用人类玩家出牌的程序
            Assert.IsTrue(fo1.gethumanhaveplayedpb1().Name=="t1","出第1张牌失败");//如果出出来的牌与预期不同，结束程序并输出出第1张牌失败
            fo1.humanPlayer_chupai("t1", 2);
            Assert.IsTrue(fo1.gethumanhaveplayedpb2().Name == "t1", "出第1张牌失败");//以下类似
            fo1.humanPlayer_chupai("t1", 3);
            Assert.IsTrue(fo1.gethumanhaveplayedpb3().Name == "t1", "出第1张牌失败");
            fo1.humanPlayer_chupai("t1", 4);
            Assert.IsTrue(fo1.gethumanhaveplayedpb4().Name == "t1", "出第1张牌失败");
            fo1.humanPlayer_chupai("t1", 5);
            Assert.IsTrue(fo1.gethumanhaveplayedpb5().Name == "t1", "出第1张牌失败");
            fo1.humanPlayer_chupai("t1", 6);
            Assert.IsTrue(fo1.gethumanhaveplayedpb6().Name == "t1", "出第1张牌失败");
            fo1.humanPlayer_chupai("t1", 7);
            Assert.IsTrue(fo1.gethumanhaveplayedpb7().Name == "t1", "出第1张牌失败");
            fo1.humanPlayer_chupai("t1", 8);
            Assert.IsTrue(fo1.gethumanhaveplayedpb8().Name == "t1", "出第1张牌失败");
            fo1.humanPlayer_chupai("t1", 9);
            Assert.IsTrue(fo1.gethumanhaveplayedpb9().Name == "t1", "出第1张牌失败");
            fo1.humanPlayer_chupai("t1", 10);
            Assert.IsTrue(fo1.gethumanhaveplayedpb10().Name == "t1", "出第1张牌失败");
            fo1.humanPlayer_chupai("t1", 11);
            Assert.IsTrue(fo1.gethumanhaveplayedpb11().Name == "t1", "出第1张牌失败");
            fo1.humanPlayer_chupai("t1", 12);
            Assert.IsTrue(fo1.gethumanhaveplayedpb12().Name == "t1", "出第1张牌失败");
            fo1.humanPlayer_chupai("t1", 13);
            Assert.IsTrue(fo1.gethumanhaveplayedpb13().Name == "t1", "出第1张牌失败");
            fo1.humanPlayer_chupai("t1", 14);
            Assert.IsTrue(fo1.gethumanhaveplayedpb14().Name == "t1", "出第1张牌失败");
        }
    }
}