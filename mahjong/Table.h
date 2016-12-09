#pragma once
#include<string>
#include<vector>
#include<stdlib.h>
using namespace std;
class Table
{
public:
	Table();                           //对牌进行初始化
	~Table();
	string Deal(int who);              //发牌
	string Get(string behavior);
    int Result(int who);
	int GetHasHandout();
	void Restart();
	string Realize();
	bool HumanIsHu(int who, string pai_);
	bool IsHu(int who, string pai_);
private:
	vector<string> m_Mahjong_Init;        //存放所有的牌
	struct Information
	{
		vector<string> m_Pai;//用于记录手牌
		vector<string> m_HasPeng;//碰过的牌,长度2位,第一位花色,第二位数字
		vector<string> m_HasGang;//杠过的牌,长度4位,第一位花色,第二位数字,第三位杠的谁的牌,第四位杠的类型,0暗杠，1直杠，2弯杠，暗杠和弯杠第三列存自己
		int m_iPai[30] = { 0 };//1-9表示筒子b，11-19表示条子t，21-29表示万字w,用于记录手牌
		int m_Money = 0;	//当局输赢
		int m_ZiMo = 0;//用于记录是否自摸
		string m_LastDeal;
		bool m_Ontable = true;
	}m_Player[4];
	int m_HasHandout = 0;                     //用于记录牌堆发了几张牌
	int m_Di = 1;
	struct struct_paidui
	{
		int who;
		string pai;
	};
	vector<struct_paidui> m_PaiDui;//用于记录打了什么牌
	int m_Hua = 0;//用于记录有几个花
	bool m_boolHua = false;//用于记录是否刚刚杠完牌未打
	int IsQing(int who);
	int IsBigPeng(int who);
	int IsDaiYao(int who);
	int IsQiDui(int who);
	int NumGang(int who);
	int IsHuaZhu(int who);
	string m_output;
};