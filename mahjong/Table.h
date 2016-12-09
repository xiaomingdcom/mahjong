#pragma once
#include<string>
#include<vector>
#include<stdlib.h>
using namespace std;
class Table
{
public:
	Table();                           //���ƽ��г�ʼ��
	~Table();
	string Deal(int who);              //����
	string Get(string behavior);
    int Result(int who);
	int GetHasHandout();
	void Restart();
	string Realize();
	bool HumanIsHu(int who, string pai_);
	bool IsHu(int who, string pai_);
private:
	vector<string> m_Mahjong_Init;        //������е���
	struct Information
	{
		vector<string> m_Pai;//���ڼ�¼����
		vector<string> m_HasPeng;//��������,����2λ,��һλ��ɫ,�ڶ�λ����
		vector<string> m_HasGang;//�ܹ�����,����4λ,��һλ��ɫ,�ڶ�λ����,����λ�ܵ�˭����,����λ�ܵ�����,0���ܣ�1ֱ�ܣ�2��ܣ����ܺ���ܵ����д��Լ�
		int m_iPai[30] = { 0 };//1-9��ʾͲ��b��11-19��ʾ����t��21-29��ʾ����w,���ڼ�¼����
		int m_Money = 0;	//������Ӯ
		int m_ZiMo = 0;//���ڼ�¼�Ƿ�����
		string m_LastDeal;
		bool m_Ontable = true;
	}m_Player[4];
	int m_HasHandout = 0;                     //���ڼ�¼�ƶѷ��˼�����
	int m_Di = 1;
	struct struct_paidui
	{
		int who;
		string pai;
	};
	vector<struct_paidui> m_PaiDui;//���ڼ�¼����ʲô��
	int m_Hua = 0;//���ڼ�¼�м�����
	bool m_boolHua = false;//���ڼ�¼�Ƿ�ոո�����δ��
	int IsQing(int who);
	int IsBigPeng(int who);
	int IsDaiYao(int who);
	int IsQiDui(int who);
	int NumGang(int who);
	int IsHuaZhu(int who);
	string m_output;
};